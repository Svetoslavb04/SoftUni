const User = require('../models/User');
const util = require('util');

const jwt = require('jsonwebtoken');
const bcrypt = require('bcrypt');

const signJWTPromisified = util.promisify(jwt.sign);
const verifyJWTPromisified = util.promisify(jwt.verify);

const config = require('../config/config.json');

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

            return signJWT(user._id, email, user.gender)
                .then(token => {
                    return token;
                });
        })
}

const register = (email, password, gender) => {
    return User.create({ email, password, gender })
        .then(user => {
            return signJWT(user._id, user.email, user.gender)
                .then(token => {
                    console.log(token);
                    return token
                })
        })
        .catch(err => console.log(err))
}

const signJWT = (_id, email, gender) => {
    return signJWTPromisified({ _id, email, gender }, config[process.env.NODE_ENV].jwtSecret)
}

const verifyJwt = (token) => {
    return verifyJWTPromisified(token, config[process.env.NODE_ENV].jwtSecret)
}

module.exports = {
    register,
    verifyJwt,
    login
}