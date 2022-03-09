import { updateSession } from '../auth.js';
import { displayNavigation, displayFooter } from './layout.js';
import { navigateTo } from '../router.js';

const containerDiv = document.getElementById('container');
const loginSection = document.getElementById('form-login');

const loginForm = loginSection.children[0];

loginForm.addEventListener('submit', loginHandler);

export function displayLogin() {
    displayNavigation();

    containerDiv.appendChild(loginSection);

    displayFooter();
}

async function loginHandler(e) {
    e.preventDefault();

    const formdata = new FormData(e.currentTarget);
    const email = formdata.get('email');
    const password = formdata.get('password');

    try {
        const response = await fetch('http://localhost:3030/users/login', {
        method: 'POST',
        headers: { 'Content-type' : 'application/json'},
        body: JSON.stringify({
            'email': email,
            'password': password
        })
    });
    
    const data = await response.json();

    if (response.status != 200) {
        throw Error(data.message);
    }

    updateSession(data.email, data.username, data._id, data.accessToken);

    navigateTo('/');

    } catch (error) {
        alert(error.message);
        displayLogin();
    }
}

