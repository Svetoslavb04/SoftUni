import { displayHome } from './pages/home.js';
import { displayLogin } from './pages/login.js';
import { displayLogout } from './pages/logout.js';
import { displayRegister } from './pages/register.js';
import { displayAddMovie } from './pages/addMovie.js';

let containerDiv = document.querySelector('#container');
let navbarNav = containerDiv.children[0];
let routes = {
    '/': displayHome,
    '/login': displayLogin,
    '/logout': displayLogout,
    '/register': displayRegister,
    '/addMovie': displayAddMovie
};

export function navigateTo(path) {
    hideAllSections();

    routes[path]();
}

function hideAllSections() {
    Array.from(containerDiv.children)
        .forEach(c => {
            c.remove();
        });
}