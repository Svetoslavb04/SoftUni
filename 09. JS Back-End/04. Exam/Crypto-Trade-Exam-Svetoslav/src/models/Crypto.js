const mongoose = require('mongoose');

const cryptoSchema = new mongoose.Schema({
    name: {
        type: String,
        required: [true, 'Name required'],
        minlength: [2, 'Name`s min length is 2']
    },
    price: {
        type: Number,
        required: [true, 'Price required'],
        min: [1, 'Price must be positive']
    },
    cryptoImage: {
        type: String,
        required: [true, 'Image required'],
    },
    description: {
        type: String,
        required: [true, 'Description required'],
        minLength: [10, 'Description`s min length is 10']
    },
    paymentMethod: {
        type: String,
        required: [true, 'Payment method required'],
        enum: {
            values: ['crypto-wallet', 'credit-card', 'debit-card', 'paypal']
        }
    },
    buyACrypto: {
        type: [{
            type: mongoose.Types.ObjectId,
            ref: 'User'
        }]
    },
    owner: {
        type: mongoose.Types.ObjectId,
        ref: 'User'
    },
})

cryptoSchema.path('cryptoImage').validate((value) => {
    if (value.startsWith('http://') || value.startsWith('https://')) {
        return true;
    }
    return false;
}, 'Invalid Image');

const Crypto = mongoose.model('Crypto', cryptoSchema);

module.exports = Crypto;