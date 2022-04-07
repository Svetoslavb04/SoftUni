const router = require('express').Router();

const authService = require('../services/authService');

router.get('/login', (req, res) => {
    res.render('auth/login');
});

router.post('/login', async (req, res) => {
    const userData = req.body;

    try {
        const token = await authService.login(userData.email, userData.password);

        res.cookie('jwt', token);

        res.redirect('/');
    } catch (error) {

        res.render('auth/login', {
            userData,
            error: error
        })
    }
});

router.get('/register', (req, res) => {
    res.render('auth/register');
});

router.post('/register', async (req, res) => {
    const userData = req.body;

    if (userData.password != userData.rePassword) {
        res.render('auth/register', {
            userData,
            error: 'Password does not match!!!'
        })
    }

    try {
        const token = await authService.register(userData.email, userData.password, userData.gender);

        res.cookie('jwt', token);

        res.redirect('/');
    } catch (error) {

        res.render('auth/register', {
            userData,
            error: error
        })
    }
});

router.get('/logout', (req, res) => {
    res.clearCookie('jwt');

    res.redirect('/');
})

module.exports = router;

