const handlebars = require('express-handlebars');

const path = require('path');

const engine = handlebars.create({
    extname: 'hbs',
    helpers: {
        isSelected: function (paymentMethod, value) {
            return paymentMethod == value;
        },
    }
})
    .engine;

exports.initHandlebars = function (app) {
    app.engine('hbs', engine);
    app.set('view engine', 'hbs');
    app.set('views', path.resolve('../views'))
}