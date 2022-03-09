import { displayHome } from './pages/home.js';
import { displayLogin } from './pages/login.js';
import { displayLogout } from './pages/logout.js';
import { displayRegister } from './pages/register.js';

let containerDiv = document.querySelector('#container');
let navbarNav = containerDiv.children[0];
let routes = {
    '/home': displayHome,
    '/login': displayLogin,
    '/logout': displayLogout,
    '/register': displayRegister,
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
    
    containerDiv.appendChild(navbarNav);
}