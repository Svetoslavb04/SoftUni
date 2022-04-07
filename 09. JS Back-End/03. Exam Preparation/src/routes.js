const router = require('express').Router();

const authMiddleware = require('./middlewares/authMiddleware');

const authController = require('./controllers/authController');
const tripController = require('./controllers/tripController');

const tripService = require('./services/tripService');

router.use(authController);
router.use(tripController);

router.get('/profile', authMiddleware.isAuth, async (req, res) => {
    if (!res.locals.isAuth) {
        return res.redirect('/');
    }

    const trips = await tripService.getAll(res.locals.user._id);

    res.render('profile', {
        trips
    })
})
router.get('/', authMiddleware.isAuth, (req, res) => {
    res.render('home');
})

router.get('*', (req, res) => {
    res.render('404');
})

module.exports = router;