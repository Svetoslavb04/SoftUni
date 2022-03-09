import { isAuthenticated, username, updateAuth } from '../auth.js';
import { navigateTo } from '../router.js';

const containerElement = document.querySelector('#container');
const navbarNavElement = document.querySelector('#container > nav');
const navbarList = navbarNavElement.children[1];

const greetingAncher = navbarList.querySelector('#greeting');
const loginAncher = navbarList.querySelector('#login');
const logoutAncher = navbarList.querySelector('#logout');
const registerAncher = navbarList.querySelector('#register');

navbarNavElement.addEventListener('click', (e) => {
    if (e.target.tagName == 'A') {
        e.preventDefault();

        let url = new URL(e.target.href);

        navigateTo(url.pathname);
    }
});

const footerElement = document.querySelector('.page-footer');

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