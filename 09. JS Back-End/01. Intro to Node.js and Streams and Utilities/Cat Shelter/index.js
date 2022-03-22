const http = require('http');
const port = 3030;

const path = require('path');
const fs = require('fs');
const formidable = require('formidable');
const url = require('url');

let cats = require('./data/cats.json');
let breeds = require('./data/breeds.json');

http.createServer((req, res) => {
   
    const pathName = req.url;
    let filePath;
    let body;

    let reversedPath = Array.from(pathName).reverse().join('');
    let indexOfSlash= reversedPath.indexOf('/');
    let reveresedId = reversedPath.slice(0, indexOfSlash);
    let id = Array.from(reveresedId).reverse().join('');

    const queryObject = url.parse(req.url, true).query;

    switch (pathName) {
        case `/content/images/${id}`:
            filePath = path.normalize(
                path.join(__dirname, `/content/images/${id}`)
            );

            let mimeType = 'image/';

            if (id.endsWith('jpg') || id.endsWith('jpeg') || id.endsWith('jpe')) {
                mimeType += 'jpeg';
            } else if (id.endsWith('png') || id.endsWith('ico')) { mimeType += 'png'}
            else if (id.endsWith('gif')) { mimeType += 'gif' }

            res.writeHead(200, {
                'Content-Type': mimeType
            });

            body = fs.createReadStream(filePath);
            body.pipe(res);
            break;
        case '/content/styles/site.css':
            filePath = path.normalize(
                path.join(__dirname, './content/styles/site.css')
            );
            
            res.writeHead(200, {
                'Content-type': 'text/css'
            });

            body = fs.createReadStream(filePath, 'utf8');
            body.pipe(res);
            break;
        case '/':
            filePath = path.normalize(
                path.join(__dirname, './views/home/index.html')
            );
            
            res.writeHead(200, {
                'Content-type': 'text/html'
            });

            body = fs.readFile(filePath, 'utf8', (err, data) => {
                let dataFilePath = path.normalize( path.join(__dirname, './data/cats.json'));

                fs.readFile(dataFilePath, 'utf8', (err, cats) => {
                    if (err) return;
                        
                    let catsArr = JSON.parse(cats);
                    
                    let mappedCats = catsArr.map(c => `
                        <li>
                            <img src="${c.image}" alt="Cat">
                            <h3>${c.name}</h3>
                            <p><span>Breed: </span>${c.breed}</p>
                            <p><span>Description: </span>${c.description}</p>
                            <ul class="buttons">
                                <li class="btn edit"><a href="/cat-edit/${c.id}">Change Info</a></li>
                                <li class="btn delete"><a href="/cat-find-new-home/${c.id}">New Home</a></li>
                            </ul>
                        </li>
                    `)

                    data = data.replace('{{AllCats}}', mappedCats)
                    
                    res.write(data);
                    res.end();
                });
            });
            
            
            break;
        case '/cats/add-cat':
            if (req.method == 'GET') {
                filePath = path.normalize(
                    path.join(__dirname, './views/addCat.html')
                );
                
                res.writeHead(200, {
                    'Content-type': 'text/html'
                });

                let dataFilePath = path.normalize( path.join(__dirname, './data/breeds.json'));
                fs.readFile(dataFilePath, 'utf8', (err, data) => {
                    if (err) return;
                    
                    let breeds = JSON.parse(data);
                    
                    fs.readFile(filePath, 'utf8', (err, data) => {
                        data = data.replace('{{breedPlaceholder}}', breeds.map(b => `<option value="${b}">${b}</option>`));
                        res.write(data);
                        res.end();
                    });
                });
            } else if(req.method == 'POST'){
                let form = new formidable.IncomingForm();
                
                let cat = {};

                form.parse(req, (err, fields, files) => {
                    if (err) return;
                    
                    if (files.upload.originalFilename != '') {
                        let oldPath = files.upload.filepath;
                        let newPath = path.normalize( path.join(__dirname, `./content/images/${files.upload.newFilename}${files.upload.originalFilename}`));

                        fs.rename(oldPath, newPath, err => {
                        if (err) {
                            return;
                        }
                        cat.image = `./content/images/${files.upload.newFilename}${files.upload.originalFilename}`;

                        });
                    } else { cat.image = null; }
                    
                    cat.name = fields.name;
                    cat.description = fields.description;
                    cat.breed = fields.breed;

                    let dataFilePath = path.normalize( path.join(__dirname, './data/cats.json'));

                    fs.readFile(dataFilePath, 'utf8', (err, data) => {
                        if (err) return;
                        
                        let currentData = JSON.parse(data);
                        cat.id = currentData.length + 1;
                        currentData.push(cat);

                        const stream = fs.createWriteStream(dataFilePath, 'utf8');
                        stream.write(JSON.stringify(currentData, '', 2));
                        stream.end();

                        res.writeHead(302, {
                            'Location': '/'
                        });
        
                        res.end();
                    });
                });
            }
            break;
        case '/cats/add-breed':
            if (req.method == 'GET') {
                filePath = path.normalize(
                    path.join(__dirname, './views/addBreed.html')
                );
                
                res.writeHead(200, {
                    'Content-type': 'text/html'
                });
    
                body = fs.createReadStream(filePath);
                body.pipe(res);
            } else if(req.method == 'POST'){
                let form = new formidable.IncomingForm();
                
                let breed;

                form.parse(req, (err, fields, files) => {
                    if (err) return;
                    breed = fields.breed;
                });

                let dataFilePath = path.normalize( path.join(__dirname, './data/breeds.json'));

                fs.readFile(dataFilePath, 'utf8', (err, data) => {
                    if (err) return;
                    
                    let currentData = JSON.parse(data);

                    currentData.push(breed);

                    const breedFile = fs.createWriteStream(dataFilePath, 'utf8');
                    breedFile.write(JSON.stringify(currentData, '', 2));
                    breedFile.end();
                });

                res.writeHead(302, {
                    'Location': '/'
                });

                res.end();
            }
            break;
        case `/cat-edit/${id}`:
            if (req.method == 'GET') {
                let filePath = path.normalize( path.join(__dirname, './views/editCat.html'))
                fs.readFile(filePath, 'utf8', (err, data) => {
                    if(err) return;

                    let dataFilePath = path.normalize( path.join(__dirname, './data/cats.json'));

                    fs.readFile(dataFilePath, 'utf8', (err, catData) => {
                        if (err) return;

                        let breedsFilePath = path.normalize( path.join(__dirname, './data/breeds.json'));

                        fs.readFile(breedsFilePath, 'utf8', (err, breeds) => {
                            if (err) return;
                            
                            let breedsArr = JSON.parse(breeds);

                            let cats = JSON.parse(catData);
                        
                            let index = cats.findIndex(c => c.id == id);

                            let name = cats[index].name;
                            let description = cats[index].description;

                            let indexOfBreed = breedsArr.indexOf(cats[index].breed);
                            breedsArr.splice(indexOfBreed, 1);
                            breedsArr.unshift(cats[index].breed);

                            data = data.replace('<input name="name" type="text" id="name" value="{{NAME}}">', `<input name="name" type="text" id="name" value="${name}">`);
                            data = data.replace('{{DESCRIPTION}}', description);
                            data = data.replace('{{BREEDS}}', breedsArr.map(b => `<option value="${b}">${b}</option>`));

                            res.write(data);
                            res.end();
                        });
                    });
                })
            } else if(req.method == 'POST') {
                let editform = new formidable.IncomingForm();
                
                let editedcat = {};

                editform.parse(req, (err, fields, files) => {
                    if (err) return;
                    
                    if (files.upload.originalFilename != '') {
                        let oldPath = files.upload.filepath;
                        let newPath = path.normalize( path.join(__dirname, `./content/images/${files.upload.newFilename}${files.upload.originalFilename}`));

                        fs.rename(oldPath, newPath, err => {
                        if (err) {
                            return;
                        }
                        editedcat.image = `./content/images/${files.upload.newFilename}${files.upload.originalFilename}`;

                        });
                    } else { editedcat.image = null; }
                    
                    editedcat.name = fields.name;
                    editedcat.description = fields.description;
                    editedcat.breed = fields.breed;

                    let dataFilePath = path.normalize( path.join(__dirname, './data/cats.json'));

                    fs.readFile(dataFilePath, 'utf8', (err, data) => {
                        if (err) return;
                        
                        let currentData = JSON.parse(data);
                        editedcat.id = id;

                        let indexOfCat = currentData.findIndex(c => c.id == id);

                        currentData.splice(indexOfCat, 1, editedcat);

                        const stream = fs.createWriteStream(dataFilePath, 'utf8');
                        stream.write(JSON.stringify(currentData, '', 2));
                        stream.end();

                        res.writeHead(302, {
                            'Location': '/'
                        });
        
                        res.end();
                    });
                });
            }
            break;
        case `/cat-find-new-home/${id}`:
            if (req.method == 'GET') {
                let filePath = path.normalize( path.join(__dirname, './views/catShelter.html'));

                fs.readFile(filePath, 'utf8', (err, data) => {
                    if(err) return;

                    let dataFilePath = path.normalize( path.join(__dirname, './data/cats.json'));

                    fs.readFile(dataFilePath, 'utf8', (err, catData) => {
                        if (err) return;

                        let cats = JSON.parse(catData);
                    
                        let index = cats.findIndex(c => c.id == id);

                        let name = cats[index].name;
                        let description = cats[index].description;
                        let breed = cats[index].breed;
                        let image = cats[index].image;

                        data = data.replace('<img src="" alt="Cat">', `<img src=".${image}" alt="Cat">`)
                        data = data.replace('<input type="text" id="name" value="Pretty Kitty" disabled>', `<input type="text" id="name" value="${name}" disabled>`);
                        data = data.replace('{{DESCRIPTION}}', description);
                        data = data.replace('{{BREEDS}}', `<option value="${breed}">${breed}</option>`);

                        res.write(data);
                        res.end();
                    });
                })
            } else {
                let dataFilePath = path.normalize( path.join(__dirname, './data/cats.json'));

                    fs.readFile(dataFilePath, 'utf8', (err, data) => {
                        if (err) return;
                        
                        let currentData = JSON.parse(data);

                        let indexOfCat = currentData.findIndex(c => c.id == id);

                        currentData.splice(indexOfCat, 1);

                        const stream = fs.createWriteStream(dataFilePath, 'utf8');
                        stream.write(JSON.stringify(currentData, '', 2));
                        stream.end();

                        res.writeHead(302, {
                            'Location': '/'
                        });
        
                        res.end();
                    });
            }
            break;
        case `/search?search=${queryObject.search}`:
            filePath = path.normalize(
                path.join(__dirname, './views/home/index.html')
            );
            
            res.writeHead(200, {
                'Content-type': 'text/html'
            });

            fs.readFile(filePath, 'utf8', (err, data) => {
                let dataFilePath = path.normalize( path.join(__dirname, './data/cats.json'));
                fs.readFile(dataFilePath, 'utf8', (err, cats) => {
                    if (err) return;
                        
                    let catsArr = JSON.parse(cats);
                    let filteredCats = catsArr.reduce((arr, c) => {
                        let name = c.name;
                        let breed = c.breed;
                        let description = c.description;

                        if (name.includes(queryObject.search) || breed.includes(queryObject.search) || description.includes(queryObject.search)) {
                            arr.push(c);
                        }
                        
                        return arr;
                    }, []);
                    
                    let mappedCats = filteredCats.map(c => `
                        <li>
                            <img src="${c.image}" alt="Cat">
                            <h3>${c.name}</h3>
                            <p><span>Breed: </span>${c.breed}</p>
                            <p><span>Description: </span>${c.description}</p>
                            <ul class="buttons">
                                <li class="btn edit"><a href="/cat-edit/${c.id}">Change Info</a></li>
                                <li class="btn delete"><a href="/cat-find-new-home/${c.id}">New Home</a></li>
                            </ul>
                        </li>
                    `)

                    data = data.replace('{{AllCats}}', mappedCats)
                    
                    res.write(data);
                    res.end();
                });
            });
            break;
        default: 
        res.writeHead(404, {
            'Content-Type': 'text/plain'
        });

        res.write('Sorry, bro! Resource not found');
        res.end();
        break;
}

}).listen(port);

console.log('Server listening for requests at 3030.');