let loginSectionElement = document.getElementById('login-view');
let registerSectionElement = document.getElementById('register-view');
let homeSectionElement = document.getElementById('home-view');

let mainElement = document.querySelector('main');

let authToken = sessionStorage.getItem('authToken');
let username = sessionStorage.getItem('username');
let user_id = sessionStorage.getItem('_id');

let homeSectionMainElement = homeSectionElement.children[0];
let homeSectionAsideElement = homeSectionElement.children[1];

let greetingNameElement = document.querySelector('.email > span');

function SetUp() {
    loginSectionElement.remove();
    registerSectionElement.remove();
    homeSectionElement.remove();
    homeSectionElement.children[0].remove();

    mainElement.appendChild(homeSectionElement);   
    
    let homeButtonElement = document.getElementById('home');
    let loginButtonElement = document.getElementById('login');
    let registerButtonElement = document.getElementById('register');
    let logoutButtonElement = document.getElementById('logout');


    homeButtonElement.addEventListener('click', displayHome);
    loginButtonElement.addEventListener('click', displayLogin);
    registerButtonElement.addEventListener('click', displayRegister);
    logoutButtonElement.addEventListener('click', logout);

    let loadButtonElement = document.querySelector('.load');
    loadButtonElement.addEventListener('click', displayCatches);

    let addButtonElement = document.querySelector('.add');
    addButtonElement.addEventListener('click', addCatch);

    if (authToken) {
        greetingNameElement.textContent = username;
        loginButtonElement.style.display = 'none';
        registerButtonElement.style.display = 'none';
    } else {
        greetingNameElement.textContent = 'guest';
        logoutButtonElement.style.display = 'none';
    }
}

SetUp();

function displayLogin() {
    mainElement.innerHTML = '';
    mainElement.appendChild(loginSectionElement);

    let notificationElement = document.querySelector('.notification');
    notificationElement.textContent = '';

    let loginFormButton = document.querySelector('#login > button');
    loginFormButton.addEventListener('click', login);
}

function displayRegister() {
    mainElement.innerHTML = '';
    mainElement.appendChild(registerSectionElement);

    let notificationElement = document.querySelector('.notification');
    notificationElement.textContent = '';

    let registerForm = document.querySelector('#register > button');
    registerForm.addEventListener('click', register);
}

function displayHome() {
    mainElement.innerHTML = '';
    mainElement.appendChild(homeSectionElement);
    
    authToken = sessionStorage.getItem('authToken');
    username = sessionStorage.getItem('username');
    user_id = sessionStorage.getItem('_id');

    displayCatches();

    let loginButtonElement = document.getElementById('login');
    let registerButtonElement = document.getElementById('register');
    let logoutButtonElement = document.getElementById('logout');
    let addButtonElement = document.querySelector('.add');
    
    if (authToken) {
        greetingNameElement.textContent = username;

        loginButtonElement.style.display = 'none';
        registerButtonElement.style.display = 'none';
        logoutButtonElement.style.display = 'inline';
        addButtonElement.disabled = false;
    } else {
        greetingNameElement.textContent = 'guest';

        let logoutButtonElement = document.getElementById('logout');

        loginButtonElement.style.display = 'inline';
        registerButtonElement.style.display = 'inline';
        logoutButtonElement.style.display = 'none';
        addButtonElement.disabled = true;
    }
}

async function displayCatches() {
    homeSectionAsideElement.remove();
    homeSectionElement.appendChild(homeSectionMainElement);
    homeSectionElement.appendChild(homeSectionAsideElement);

    await fetch('http://localhost:3030/data/catches')
        .then((res) => res.json())
        .then((data) => {
            let catchesElement = document.getElementById('catches');
            catchesElement.innerHTML = '';
            data.forEach(c => {
                let catchElement = createCatchElement(c);

                catchesElement.appendChild(catchElement);
            });
        })
}

function createCatchElement(jsonData) {
    let catchDivElement = document.createElement('div');
    catchDivElement.classList.add('catch');
    catchDivElement.setAttribute('_ownerId', jsonData._ownerId);

    let anglerLabel = document.createElement('label');
    anglerLabel.textContent = 'Angler';
    catchDivElement.appendChild(anglerLabel);

    let anglerInput= document.createElement('input');
    anglerInput.type = 'text';
    anglerInput.classList.add('angler');
    anglerInput.value = jsonData.angler;
    catchDivElement.appendChild(anglerInput);
    if (user_id != jsonData._ownerId) { anglerInput.disabled = true;}

    let weightLabel = document.createElement('label');
    weightLabel.textContent = 'Weight';
    catchDivElement.appendChild(weightLabel);

    let weightInput= document.createElement('input');
    weightInput.type = 'number';
    weightInput.classList.add('weight');
    weightInput.value = Number(jsonData.weight);
    catchDivElement.appendChild(weightInput);
    if (user_id != jsonData._ownerId) { weightInput.disabled = true;}

    let speciesLabel = document.createElement('label');
    speciesLabel.textContent = 'Species';
    catchDivElement.appendChild(speciesLabel);

    let speciesInput= document.createElement('input');
    speciesInput.type = 'text';
    speciesInput.classList.add('species');
    speciesInput.value = jsonData.species;
    catchDivElement.appendChild(speciesInput);
    if (user_id != jsonData._ownerId) { speciesInput.disabled = true;}

    let locationLabel = document.createElement('label');
    locationLabel.textContent = 'Location';
    catchDivElement.appendChild(locationLabel);

    let locationInput= document.createElement('input');
    locationInput.type = 'text';
    locationInput.classList.add('location');
    locationInput.value = jsonData.location;
    catchDivElement.appendChild(locationInput);
    if (user_id != jsonData._ownerId) { locationInput.disabled = true;}

    let baitLabel = document.createElement('label');
    baitLabel.textContent = 'Bait';
    catchDivElement.appendChild(baitLabel);

    let baitInput= document.createElement('input');
    baitInput.type = 'text';
    baitInput.classList.add('bait');
    baitInput.value = jsonData.bait;
    catchDivElement.appendChild(baitInput);
    if (user_id != jsonData._ownerId) { baitInput.disabled = true;}

    let captureTimeLabel = document.createElement('label');
    captureTimeLabel.textContent = 'Capture Time';
    catchDivElement.appendChild(captureTimeLabel);

    let captureTimeInput= document.createElement('input');
    captureTimeInput.type = 'number';
    captureTimeInput.classList.add('captureTime');
    captureTimeInput.value = jsonData.captureTime;
    catchDivElement.appendChild(captureTimeInput);
    if (user_id != jsonData._ownerId) { captureTimeInput.disabled = true;}

    let updateButton= document.createElement('button');
    updateButton.classList.add('update');
    updateButton.setAttribute('data-id', jsonData._id);
    updateButton.textContent = 'Update';
    catchDivElement.appendChild(updateButton);
    if (user_id != jsonData._ownerId) { updateButton.disabled = true;}

    let deleteButton= document.createElement('button');
    deleteButton.classList.add('delete');
    deleteButton.setAttribute('data-id', jsonData._id);
    deleteButton.textContent = 'Delete';
    catchDivElement.appendChild(deleteButton);
    if (user_id != jsonData._ownerId) { deleteButton.disabled = true;}

    return catchDivElement;
}

async function login(e) {
    e.preventDefault();
    
    let loginFormData = new FormData(e.currentTarget.parentNode);

    try {
        let response = await fetch('http://localhost:3030/users/login', {
        method: 'POST',
        headers: { 'Content-type' : 'application/json'},
        body: JSON.stringify({
            'email': loginFormData.get('email'),
            'password': loginFormData.get('password')
        })
    });
    
    let data = await response.json();

    if (response.status != 200) {
        throw Error(data.message);
    }
    else {
        sessionStorage.setItem('username', data.username);
        sessionStorage.setItem('_id', data._id);
        sessionStorage.setItem('authToken', data.accessToken);

        loginSectionElement.remove();
        displayHome();
    }
    } catch (error) {
        let notificationElement = document.querySelector('.notification');
        notificationElement.textContent = error.message;
    }
}

async function register(e) {
    e.preventDefault();
    
    let registerFormData = new FormData(e.currentTarget.parentNode);
    let email = registerFormData.get('email');
    let password = registerFormData.get('password');
    let rePassword = registerFormData.get('rePass');

    try {
        if (!email || !password || !rePassword) {
            throw Error('All fields are required');
        }
        if (password != rePassword) {
            throw Error('Passwords does not match!');
        }

        let username = email.substring(0, email.indexOf('@'));

        if (!username) {
            username = email;
        }

        let response = await fetch('http://localhost:3030/users/register', {
        method: 'POST',
        headers: { 'Content-type' : 'application/json'},
        body: JSON.stringify({
            'email': email,
            'password': password,
            'username': username
        })
    });
    
    let data = await response.json();

    if (response.status != 200) {
        throw Error(data.message);
    }
    else {
        sessionStorage.setItem('username', data.username);
        sessionStorage.setItem('_id', data._id);
        sessionStorage.setItem('authToken', data.accessToken);

        loginSectionElement.remove();
        displayHome();
    }
    } catch (error) {
        let notificationElement = document.querySelector('.notification');
        notificationElement.textContent = error.message;
    }
}

async function logout() {
    try {
        fetch('http://localhost:3030/users/logout', {
            method: 'GET',
            headers: {
                'X-Authorization': authToken
            }
        });
        sessionStorage.clear();
        displayHome();
    } catch (error) {
        console.log(error.message);
    }
}

async function addCatch(e) {
    e.preventDefault();
    //to fix undefined formdata
    let formData = e.currentTarget.parentNode.parentNode.formData;

    if (!authToken) {
        return;
    }

    let angler = formData.getItem('angler');
    let weight = formData.getItem('weight');
    let species = formData.getItem('species');
    let location = formData.getItem('location');
    let bait = formData.getItem('bait');
    let captureTime = formData.getItem('captureTime');

    try {
        fetch('http://localhost:3030/data/catches', {
            method: 'POST',
            headers: {
                'X-Authorization': authToken
            },
            body: JSON.stringify({
                '_ownerId': user_id,
                angler,
                weight,
                species,
                location,
                bait,
                captureTime
            })
        });

    } catch (error) {
        console.log(error.message);
    }
    
}
