const authService = require('../services/authService');

const isAuth = async (req, res, next) => {
    const token = req.cookies['jwt'];

    let decodedToken;
    try {
        decodedToken = await authService.verifyJwt(token);
    } catch (error) {
    }

    if (decodedToken) {
        res.locals.isAuth = true;
        res.locals.user = decodedToken
    } else {
        res.locals.isAuth = false;
    }

    next();
}

module.exports = {
    isAuth
}