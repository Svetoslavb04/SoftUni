const mongoose = require('mongoose');

const tripSchema = new mongoose.Schema({
    startPoint: {
        type: String,
        required: true,
        minlength: [4, 'Start Point too short']
    },
    endPoint: {
        type: String,
        required: true,
        minlength: [4, 'End Point too short']
    },
    date: {
        type: String,
        required: true
    },
    time: {
        type: String,
        required: true
    },
    carImage: {
        type: String,
        required: true
    },
    carBrand: {
        type: String,
        required: true,
        minlength: [4, 'Car Brand too short']
    },
    seats: {
        type: Number,
        required: true,
        min: [0, 'Only greather than 0 seats are allowed'],
        max: [4, 'Max 4 seats are allowed'],
    },
    price: {
        type: Number,
        required: true,
        min: [1, "Price cannot be less than 1"],
        max: [50, "Price cannot greather than less than 50"],
    },
    description: {
        type: String,
        required: true,
        minlength: [10, 'Description too short']

    },
    creator: {
        type: mongoose.Types.ObjectId,
        ref: 'User'
    },
    buddies: [{
        type: mongoose.Types.ObjectId,
        ref: 'User'
    }]
})

const Trip = mongoose.model('Trip', tripSchema);

module.exports = Trip;