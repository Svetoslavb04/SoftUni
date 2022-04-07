const Trip = require('../models/Trip');

exports.getAll = (_id = false) => {
    if (_id) {
        return Trip.find({ creator: _id }).lean();
    }

    return Trip.find().lean();
}

exports.createTrip = (trip) => {
    return Trip.create(trip);
}

exports.getOne = (_id) => {
    return Trip.findById(_id).populate('buddies').populate('creator').lean();
}

exports.editTrip = (_id, trip) => {
    return Trip.findByIdAndUpdate(_id, trip, { runValidators: true }).populate('buddies').populate('creator').lean();
}

exports.deleteTrip = (_id) => {
    return Trip.findByIdAndDelete(_id);
}

exports.joinTrip = (user_id, trip_id) => {
    return Trip.findById(trip_id)
        .then(trip => {
            trip.buddies.push(user_id);
            trip.save();
        })
}