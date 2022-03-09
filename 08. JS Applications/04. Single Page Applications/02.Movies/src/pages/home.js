import { displayNavigation, displayFooter } from './layout.js'
import { isAuthenticated } from '../auth.js'

let containerDiv = document.getElementById('container');
let homeSection = containerDiv.querySelector('#home-page');
let moviesHeader = containerDiv.querySelector('#container > h1');
let addMovieButton = containerDiv.querySelector('#add-movie-button');
let moviesSection = containerDiv.querySelector('#movie');

export function displayHome() {
    displayNavigation();
    
    containerDiv.appendChild(homeSection);
    containerDiv.appendChild(moviesHeader);

    if (isAuthenticated) {
        containerDiv.appendChild(addMovieButton);
    }

    containerDiv.appendChild(moviesSection);
    displayFooter();
}