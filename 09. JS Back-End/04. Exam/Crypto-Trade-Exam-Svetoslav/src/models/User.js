const mongoose = require('mongoose');

const bcrypt = require('bcrypt');

const userSchema = new mongoose.Schema({
    username: {
        type: String,
        minlength: 5,
        required: true
    },
    email: {
        type: String,
        minlength: 10,
        required: true
    },
    password: {
        type: String,
        required: true,
        minlength: 4
    }
})

userSchema.pre('save', function(next) {
    bcrypt.hash(this.password, 10)
        .then(hash => {

            this.password = hash;

            next();
        })
})

const User = mongoose.model('User', userSchema);

module.exports = User;