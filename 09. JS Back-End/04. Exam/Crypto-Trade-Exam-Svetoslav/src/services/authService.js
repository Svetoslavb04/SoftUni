const User = require('../models/User');
const util = require('util');

const jwt = require('jsonwebtoken');
const bcrypt = require('bcrypt');

const signJWTPromisified = util.promisify(jwt.sign);
const verifyJWTPromisified = util.promisify(jwt.verify);

const jwtSecret = require('../config/config.json').jwtSecret;

const login = async (email, password) => {

    const user = await User.findOne({ email });

    if (!user) {
        throw new Error('Incorrect email or password!');
    }

    return bcrypt.compare(password, user.password)
        .then(res => {

            if (!res) {
                throw new Error('Incorrect email or password!');
            }

            return signJWT(user._id, email, user.username)
                .then(token => {
                    return token;
                });
        })
}

const register = (username, email, password) =>
    User.create({ username, email, password })
        .then(user => {
            return signJWT(user._id, user.email, user.username)
                .then(token => token)
        })

const signJWT = (_id, email, username) =>
    signJWTPromisified({ _id, email, username }, jwtSecret)

const verifyJwt = (token) =>
    verifyJWTPromisified(token, jwtSecret)


module.exports = {
    register,
    verifyJwt,
    login
}