const router = require('express').Router();

const { isAuth } = require('./middlewares/authMiddleware');

const authController = require('./controller/authController');
const cryptoController = require('./controller/cryptoController');

router.use(isAuth);
router.use('/user', authController);
router.use('/crypto', cryptoController);

router.get('/', (req, res) => {
    res.render('home');
});

router.all('*', (req, res) => {
    res.render('404');
});

module.exports = router;