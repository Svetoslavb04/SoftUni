const express = require('express');
const app = express();

const config = require('./config/config.json');
const cookieParser = require('cookie-parser');

const port = config.port;

const { initHandlebars } = require('./config/initHandlebars');
const { initDatabase } = require('./config/initDatabase');

const router = require('./routes');

app.use('/static', express.static('static'));

// const { globalErrorHandler } = require('./middlewares/globalErrorhandler');
app.use(express.urlencoded({ extended: true }));
app.use(cookieParser());

initHandlebars(app);

app.use(router);
// app.use(globalErrorHandler);

initDatabase()
    .then(() => {
        app.listen(port, () => console.log(`Server is listening on port ${port}...`))
    })
    .catch(err => console.log(err))