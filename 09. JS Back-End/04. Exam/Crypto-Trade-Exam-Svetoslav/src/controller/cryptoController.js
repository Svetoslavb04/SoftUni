const router = require('express').Router();

const cryptoService = require('../services/cryptoService');
const { onlyAuth } = require('../middlewares/authMiddleware');

router.get('/catalog', async (req, res) => {

    try {
        const cryptos = await cryptoService.getAll();

        res.render('crypto/catalog', {
            cryptos
        });

    } catch (error) {

        res.render('crypto/catalog', {
            cryptos: [],
            error
        });

    }

});

router.get('/create-offer', onlyAuth, async (req, res) =>
    res.render('crypto/create')
);

router.post('/create-offer', onlyAuth, async (req, res) => {

    const crypto = {
        name: req.body.name,
        price: req.body.price,
        cryptoImage: req.body.cryptoImage,
        description: req.body.description,
        paymentMethod: req.body.paymentMethod,
        buyACrypto: [],
        owner: req.user._id
    }

    try {

        await cryptoService.createCrypto(crypto);
        res.redirect('/crypto/catalog');

    } catch (error) {

        console.log(error);
        res.render('crypto/create', {
            error: error
        })
    }
})

router.get('/search', onlyAuth, async (req, res) => {

    try {

        const cryptos = await cryptoService.getAll();

        res.render('crypto/search', {
            cryptos,
            initialLoaded: true
        });
 
    } catch (error) {
        
    }

});

router.post('/search', onlyAuth, async (req, res) => {

    const name = req.body.name;
    const paymentMethod = req.body.paymentMethod;

    try {
        const cryptos = await cryptoService.searchCrypto(name, paymentMethod);

        res.render('crypto/search', {
            cryptos,
            initialLoaded: false,
            search: name,
            paymentMethod: paymentMethod
        });

    } catch (error) {

        const cryptos = await cryptoService.getAll();

        res.render('crypto/search', {
            cryptos,
            initialLoaded: true,
            search: '',
            paymentMethod: 'crypto-wallet'
        });
    }

});

router.get('/:_id/delete', onlyAuth, async (req, res) => {

    try {

        const crypto = await cryptoService.getOne(req.params._id);

        if (crypto.owner._id != res.locals.user._id) {
            res.redirect(`/crypto/${req.params._id}`);
        }

        await cryptoService.deleteCrypto(req.params._id);

        res.redirect('/crypto/catalog');

    } catch (error) {
        res.redirect(`/crypto/${req.params._id}`);
    }

});

router.get('/:_id/edit', onlyAuth, async (req, res) => {

    try {

        const crypto = await cryptoService.getOne(req.params._id);

        if (crypto.owner._id != res.locals.user._id) {
            res.redirect('/user/login');
        }

        res.render(`crypto/edit`, {
            crypto
        })

    } catch (error) {

        res.redirect(`/crypto/${req.params._id}`);

    }

});

router.post('/:_id/edit', onlyAuth, async (req, res) => {

    let crypto;

    try {

        crypto = await cryptoService.getOne(req.params._id);

    } catch (error) {

        res.redirect('/crypto/catalog');

    }

    if (crypto.owner._id != res.locals.user._id) {
        res.redirect('/user/login');
    }

    const newCrypto = {
        _id: crypto._id,
        name: req.body.name,
        price: req.body.price,
        cryptoImage: req.body.cryptoImage,
        description: req.body.description,
        paymentMethod: req.body.paymentMethod,
    }

    try {

        await cryptoService.editCrypto(req.params._id, newCrypto);

        res.redirect(`/crypto/${req.params._id}`);

    } catch (error) {

        res.render('crypto/edit', {
            error,
            crypto
        });

    }

});

router.get('/buy/:_id', onlyAuth, async (req, res) => {

    try {

        await cryptoService.buyCrypto(res.locals.user._id, req.params._id);
        res.redirect(`/crypto/${req.params._id}`);

    } catch (error) {

        res.redirect(`/crypto/${req.params._id}`);

    }

});

router.get('/:_id', async (req, res) => {

    try {

        const crypto = await cryptoService.getOne(req.params._id);

        const boughtCrypto = crypto.buyACrypto.some(u => u._id == res.locals.user._id);

        res.render('crypto/details', {
            crypto,
            isOwner: res.locals.user ? crypto.owner._id == res.locals.user._id : false,
            ableToPurchase: !boughtCrypto && !this.isOwner
        });

    } catch (error) {

        res.redirect('/crypto/catalog');
        
    }


});

module.exports = router;

