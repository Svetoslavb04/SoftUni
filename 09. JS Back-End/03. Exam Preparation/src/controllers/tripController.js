const router = require('express').Router();

const tripService = require('../services/tripService');

const authMiddleware = require('../middlewares/authMiddleware');

router.get('/trips/create', authMiddleware.isAuth, async (req, res) => {
    if (!res.locals.isAuth) {
        return res.redirect('/');
    }

    res.render('trip/trip-create');
});

router.post('/trips/create', authMiddleware.isAuth, async (req, res) => {
    if (!res.locals.isAuth) {
        return res.redirect('/');
    }

    const trip = {
        startPoint: req.body.startPoint,
        endPoint: req.body.endPoint,
        date: req.body.date,
        time: req.body.time,
        carImage: req.body.carImage,
        carBrand: req.body.carBrand,
        seats: req.body.seats,
        price: req.body.price,
        description: req.body.description,
        creator: res.locals.user._id,
        buddies: []
    }
    
    tripService.createTrip(trip)
        .then(trip => {
            res.redirect('/trips');
        })
        .catch(err => res.render('trip/trip-create', {
            error: err.message
        }))
})

router.get('/trips', authMiddleware.isAuth, async (req, res) => {
    const trips = await tripService.getAll();

    res.render('trip/shared-trips', {
        trips
    });
});

router.get('/trips/:_id', authMiddleware.isAuth, async (req, res) => {

    const trip = await tripService.getOne(req.params._id);

    if (res.locals.isAuth) {
        res.render('trip/trip-details', {
            user_id: res.locals.user._id,
            trip
        });
    } else {
        res.render('trip/trip-details', {
            trip
        });
    }
})

router.get('/trips/:_id/edit', authMiddleware.isAuth, async (req, res) => {
    if (!res.locals.isAuth) {
        return res.redirect('/');
    }

    const trip = await tripService.getOne(req.params._id);

    if (trip.creator._id != res.locals.user._id) {
        return res.redirect('/');
    }

    res.render('trip/trip-edit', {
        trip
    });
})

router.post('/trips/:_id/edit', authMiddleware.isAuth, async (req, res) => {
    if (!res.locals.isAuth) {
        return res.redirect('/');
    }

    const trip = await tripService.getOne(req.params._id);

    if (trip.creator._id != res.locals.user._id) {
        return res.redirect('/');
    }

    const editedtrip = {
        startPoint: req.body.startPoint,
        endPoint: req.body.endPoint,
        date: req.body.date,
        time: req.body.time,
        carImage: req.body.carImage,
        carBrand: req.body.carBrand,
        seats: req.body.seats,
        price: req.body.price,
        description: req.body.description,
        creator: res.locals.user._id,
        buddies: trip.buddies
    }
    
    tripService.editTrip(req.params._id, editedtrip)
        .then(trip => {
            res.redirect(`/trips/${req.params._id}`);
        })
        .catch(err => res.render('trip/trip-edit', {
            error: err.message
        }))
})

router.get('/trips/:_id/delete', authMiddleware.isAuth, async (req, res) => {
    if (!res.locals.isAuth) {
        return res.redirect('/');
    }

    const trip = await tripService.getOne(req.params._id);

    if (trip.creator._id != res.locals.user._id) {
        return res.redirect('/');
    }

    tripService.deleteTrip(req.params._id)
        .then(() => {
            res.redirect('/trips');
        })
        .catch(err => res.render(`trip/${req.params._id}`, {
            error: err.message
        }))
})

router.get('/trips/:_id/join', authMiddleware.isAuth, async (req, res) => {
    if (!res.locals.isAuth) {
        return res.redirect('/');
    }
    
    await tripService.joinTrip(res.locals.user._id, req.params._id);

    res.redirect(`/trips/${req.params._id}`);
})

module.exports = router;