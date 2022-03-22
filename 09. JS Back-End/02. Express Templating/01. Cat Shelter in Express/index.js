const fs = require('fs');
const path = require('path');

const express = require('express');
const app = express();

const port = 3030;

const exphbs = require('express-handlebars');
const handlebars = exphbs.create( {
    extname: 'hbs'
});

const catController = require('./controllers/catController');
const breedController = require('./controllers/breedController');

app.engine('hbs', handlebars.engine);
app.set('view engine', 'hbs');

app.use(express.static('public'));
app.use('/cats', catController);
app.use('/breeds', breedController);

app.get('/', (req, res) => {
    fs.readFile(path.resolve(__dirname, './database/cats.json'), 'utf8', (err, cats) => {
        res.render('home', {
            cats: JSON.parse(cats)
        });
    })
})

app.listen(port);