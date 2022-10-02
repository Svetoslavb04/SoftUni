const mongoose = require('mongoose');

exports.initDatabase = async function () {
    await mongoose.connect('mongodb://localhost:27017/cryptoTrade');
}