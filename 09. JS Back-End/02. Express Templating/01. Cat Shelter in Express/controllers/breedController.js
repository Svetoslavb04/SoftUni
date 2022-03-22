const fs = require('fs');
const path = require('path');
const multer  = require('multer');
const upload = multer();

const express = require('express');
const router = express.Router();

router.get('', (req, res) => {
    res.render('addBreed');
});

router.post('', upload.none(), (req, res, next) => {
    fs.readFile(path.resolve(__dirname, '../database/breeds.json'), (err, breeds) => {
        const breedsArr = JSON.parse(breeds);

        breedsArr.push(req.body.breed);

        const breedsStream = fs.createWriteStream(path.resolve(__dirname, '../database/breeds.json'));
        breedsStream.write(JSON.stringify(breedsArr));
        breedsStream.end();

        res.redirect('/');
    })
})


module.exports = router;
