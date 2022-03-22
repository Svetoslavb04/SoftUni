const express = require('express');
const router = express.Router();
const fs = require('fs');
const path = require('path');
var multer = require('multer');
var storage = multer.diskStorage({
    destination: function (req, file, cb) {
        cb(null, path.resolve(__dirname, '../public/images'))
    },
    filename: function (req, file, cb) {
        let ext = file.originalname.substring(file.originalname.lastIndexOf('.'), file.originalname.length);
        cb(null, Date.now() + ext)
    }
});
const upload = multer({
    storage: storage
});

router.get('/search', (req, res) => {
    fs.readFile(path.resolve(__dirname, '../database/cats.json'), 'utf8', (err, cats) => {
        const search = req.query.search.toLowerCase();

        cats = JSON.parse(cats).reduce((cats, currentCat) => {
            if (currentCat.name.toLowerCase().includes(search) || currentCat.breed.toLowerCase().includes(search) || currentCat.description.toLowerCase().includes(search)) {
                cats.push(currentCat);
            }

            return cats;
        },[]);

        res.render('home', {
            cats
        })
    })
});

router.get('', (req, res) => {
    fs.readFile(path.resolve(__dirname, '../database/breeds.json'), 'utf8', (err, breeds) => {
        res.render('addCat', {
            breeds: JSON.parse(breeds)
        });
    })
});

router.post('', upload.single('upload'), (req, res) => {
    const name = req.body.name;
    const description = req.body.description;
    const breed = req.body.breed;
    let img = null;

    if (req.file) {
        img = req.file.filename;
    }

    fs.readFile(path.resolve(__dirname, '../database/cats.json'), 'utf8', (err, cats) => {
        const catsArr = JSON.parse(cats);
        catsArr.push({
            id: catsArr.length + 1,
            name,
            description,
            breed,
            img 
        });

        const catsStream = fs.createWriteStream(path.resolve(__dirname, '../database/cats.json'));
        catsStream.write(JSON.stringify(catsArr, '' , 2));
        catsStream.end();

        res.redirect('/');
    });
});

router.get('/:id', (req, res) => {
    fs.readFile(path.resolve(__dirname, '../database/cats.json'), 'utf8', (err, cats) => {
        const catsArr = JSON.parse(cats);

        const cat = catsArr.find(c => c.id == req.params.id);

        fs.readFile(path.resolve(__dirname, '../database/breeds.json'), 'utf8', (err, breeds) => {
            const breedsArr =  JSON.parse(breeds);

            breedsArr.splice(breedsArr.findIndex(b => b == cat.breed), 1);
            breedsArr.unshift(cat.breed);
            
            res.render('editCat', {
                name: cat.name,
                breeds: breedsArr,
                description: cat.description,
            });
        });
    });
});

router.post('/:id', upload.single('upload'), (req, res) => {
    const name = req.body.name;
    const description = req.body.description;
    const breed = req.body.breed;
    let img = null;

    if (req.file) {
        img = req.file.filename;
    }

    fs.readFile(path.resolve(__dirname, '../database/cats.json'), 'utf8', (err, cats) => {
        const catsArr = JSON.parse(cats);

        catsArr.splice(catsArr.findIndex(c => c.id == req.params.id), 1, {
            id: req.params.id,
            name,
            description,
            breed,
            img
        });

        const catsStream = fs.createWriteStream(path.resolve(__dirname, '../database/cats.json'));
        catsStream.write(JSON.stringify(catsArr, '' , 2));
        catsStream.end();

        res.redirect('/');
    });
});

router.get('/shelter/:id', (req, res) => {
    fs.readFile(path.resolve(__dirname, '../database/cats.json'), 'utf8', (err, cats) => {
        const catsArr = JSON.parse(cats);

        const cat = catsArr.find(c => c.id == req.params.id);

        res.render('catShelter', {
            name: cat.name,
            description: cat.description,
            breed: cat.breed,
            img: cat.img
        });
    });
});

router.post('/shelter/:id', (req, res) => {
    fs.readFile(path.resolve(__dirname, '../database/cats.json'), 'utf8', (err, cats) => {
        const catsArr = JSON.parse(cats);

        catsArr.splice(catsArr.findIndex(c => c.id == req.params.id), 1);

        const catsStream = fs.createWriteStream(path.resolve(__dirname, '../database/cats.json'));
        catsStream.write(JSON.stringify(catsArr, '' , 2));
        catsStream.end();

        res.redirect('/');
    });
});

module.exports = router;
