const mongoose = require('mongoose');

const validator = require('validator');
const bcrypt = require('bcrypt');

const userSchema = new mongoose.Schema({
    email: {
        type: String,
        unique: true,
        required: true
    },
    password: {
        type: String,
        required: true,
        minlength: [4, 'Passoword too short']
    },
    gender: {
        type: String,
        required: true,
        enum: {
            values: ['male', 'female'],
            message: '{VALUE} is not supported'
        },
        lowercase: true
    },
    tripHistory: [{
        type: mongoose.Types.ObjectId,
        ref: 'Trip'
    }]
})

userSchema.pre('save', function(next) {
    bcrypt.hash(this.password, 10)
        .then(hash => {
            this.password = hash;

            next();
        })
})

userSchema.path('email').validate((value) => {
    if (!validator.isEmail(value)) {
        return false;
    }
    return true;
}, 'Invalid Email!');

const User = mongoose.model('User', userSchema);

module.exports = User;