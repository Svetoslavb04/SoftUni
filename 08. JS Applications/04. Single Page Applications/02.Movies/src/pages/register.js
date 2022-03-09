import { updateSession } from '../auth.js';
import { displayNavigation, displayFooter } from './layout.js';
import { navigateTo } from '../router.js';

let containerDiv = document.getElementById('container');
let registerSection = document.getElementById('form-sign-up');

let registerForm = registerSection.children[0];

registerForm.addEventListener('submit', registerHandler);

export function displayRegister() {
    displayNavigation();

    containerDiv.appendChild(registerSection);

    displayFooter();
}

async function registerHandler(e) {
    e.preventDefault();

    const formdata = new FormData(e.currentTarget);
    const email = formdata.get('email');
    const password = formdata.get('password');
    const rePassword = formdata.get('repeatPassword');

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
    
        updateSession(data.email, data.username, data._id, data.accessToken);

        navigateTo('/');

    } catch (error) {
        alert(error.message);
    }
}

