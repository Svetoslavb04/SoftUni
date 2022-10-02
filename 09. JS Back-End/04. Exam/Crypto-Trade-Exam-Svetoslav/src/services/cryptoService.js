const Crypto = require('../models/Crypto');

exports.getAll = () => Crypto.find().lean()

exports.createCrypto = (crypto) => Crypto.create(crypto)

exports.getOne = (_id) =>
    Crypto.findById(_id).populate('buyACrypto').populate('owner').lean()

exports.editCrypto = (_id, crypto) =>
    Crypto.findByIdAndUpdate(_id, crypto, { runValidators: true }).populate('buyACrypto').populate('owner').lean()

exports.deleteCrypto = (_id) =>
    Crypto.findByIdAndDelete(_id)

exports.buyCrypto = (user_id, crypto_id) =>
    Crypto.findById(crypto_id)
        .then(trip => {

            if (trip.buyACrypto.some(u => u == user_id)) {
                throw Error;
            }

            trip.buyACrypto.push(user_id);
            trip.save();

        })

exports.searchCrypto = (name, paymentMethod) => {
    
    let searchQuery = {};

    if (name) {
        searchQuery.name = {
            $regex: new RegExp(name, 'i')
        }
    }

    if (paymentMethod) {
        searchQuery.paymentMethod = paymentMethod;
    }

    return Crypto.find(searchQuery).lean();

}
