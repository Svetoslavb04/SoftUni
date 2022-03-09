import { updateAuth, isAuthenticated, username } from './auth.js';

let containerDiv = document.getElementById('container');
let navbarNavElement = document.querySelector('#container > nav');
let navbarNav = navbarNavElement.children[1];

let greetingAncher = navbarNav.querySelector('#greeting');
let loginAncher = navbarNav.querySelector('#login');
let logoutAncher = navbarNav.querySelector('#logout');
let registerAncher = navbarNav.querySelector('#register');

export function displayNav() {
    updateAuth();

    greetingAncher.textContent = username;

    if (isAuthenticated) {
        loginAncher.remove();
        registerAncher.remove();

        navbarNav.appendChild(logoutAncher);
    } else {
        logoutAncher.remove();

        navbarNav.appendChild(loginAncher);
        navbarNav.appendChild(registerAncher);
    }
}