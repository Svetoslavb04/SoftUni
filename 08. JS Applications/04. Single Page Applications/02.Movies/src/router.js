import { displayHome } from './pages/home.js';
import { displayLogin } from './pages/login.js';
import { logout } from './pages/logout.js';
import { displayRegister } from './pages/register.js';
import { displayAddMovie } from './pages/addMovie.js';
import { displayEditMovie } from './pages/editMovie.js';

const containerDiv = document.querySelector('#container');

let routes = {
    '/': displayHome,
    '/login': displayLogin,
    '/logout': logout,
    '/register': displayRegister,
    '/add-movie': displayAddMovie
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