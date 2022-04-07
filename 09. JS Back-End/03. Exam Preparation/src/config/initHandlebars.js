const handlebars = require('express-handlebars');

const path = require('path');

const engine = handlebars.create({
    extname: 'hbs',
    helpers: {
        isMale: function(gender) {
            return gender == 'male';
        },
        seatsLeft: function(trip) {
            return trip.seats - trip.buddies.length;
        },
        hasJoinedTrip: function(user_id, trip) {
            if (trip.buddies.find(b => b._id == user_id)) {
                return true
            }
            return false
        },
        isCreatorOfTrip: function(user_id, trip) {
            if (trip.creator._id == user_id) {
                return true
            }
            return false
        }
    }
})
.engine;

exports.initHandlebars = function(app) {
    app.engine('hbs', engine);
    app.set('view engine', 'hbs');
    app.set('views', path.resolve('../views'))
}