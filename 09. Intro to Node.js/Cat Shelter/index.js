const http = require('http');
const port = 3030;

const path = require('path');
const fs = require('fs');
const formidable = require('formidable');

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

    switch (pathName) {
        case `/content/images/${id}`:
            filePath = path.normalize(
                path.join(__dirname, `./content/images/${id}`)
            );
            
            res.writeHead(200, {
                'Content-type': 'image/jpeg'
            });

            body = fs.createReadStream(filePath, 'utf8');
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
                                <li class="btn edit"><a href="">Change Info</a></li>
                                <li class="btn delete"><a href="">New Home</a></li>
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
                    
                    letbreeds = JSON.parse(data);
                    
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

                    let oldPath = files.upload.filepath;
                    let newPath = path.normalize( path.join(__dirname, `./content/images/${files.upload.newFilename}${files.upload.originalFilename}`));

                    fs.rename(oldPath, newPath, err => {
                        if (err) {
                            return;
                        }
                    });

                    cat.name = fields.name;
                    cat.description = fields.description;
                    cat.breed = fields.breed;
                    cat.image = `./content/images/${files.upload.newFilename}${files.upload.originalFilename}`;

                    let dataFilePath = path.normalize( path.join(__dirname, './data/cats.json'));

                    fs.readFile(dataFilePath, 'utf8', (err, data) => {
                        if (err) return;
                        
                        let currentData = JSON.parse(data);

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