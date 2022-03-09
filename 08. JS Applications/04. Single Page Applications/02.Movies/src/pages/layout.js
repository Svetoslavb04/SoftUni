import { updateAuth, isAuthenticated, username } from '../auth.js';
import { navigateTo } from '../router.js';

let containerElement = document.querySelector('#container');
let navbarNavElement = document.querySelector('#container > nav');
let navbarList = navbarNavElement.children[1];

let greetingAncher = navbarList.querySelector('#greeting');
let loginAncher = navbarList.querySelector('#login');
let logoutAncher = navbarList.querySelector('#logout');
let registerAncher = navbarList.querySelector('#register');

navbarNavElement.addEventListener('click', (e) => {
    if (e.target.tagName == 'A') {
        e.preventDefault();

        let url = new URL(e.target.href);

        navigateTo(url.pathname);
    }
});

let footerElement = document.querySelector('.page-footer');

export function displayNavigation() {
    containerElement.appendChild(navbarNavElement);

    updateAuth();

    greetingAncher.textContent = `Welcome, ${username}`;

    if (isAuthenticated) {
        loginAncher.remove();
        registerAncher.remove();

        navbarList.appendChild(logoutAncher);
    } else {
        logoutAncher.remove();

        navbarList.appendChild(loginAncher);
        navbarList.appendChild(registerAncher);
    }
}

export function displayFooter() {
    containerElement.appendChild(footerElement);
}