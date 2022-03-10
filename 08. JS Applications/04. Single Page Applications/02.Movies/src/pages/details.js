import { displayNavigation, displayFooter } from './layout.js';
import { getMovieDetailsElement  } from '../services/movieService.js';

const containerDiv = document.querySelector('#container');
const movieSection = document.querySelector('#movie-example');


export async function displayDetails(_id) {
    hideAllSections();

    displayNavigation();

    containerDiv.appendChild(movieSection);

    while (movieSection.children[0]) {
        movieSection.removeChild(movieSection.children[0]);
    }

    await getMovieDetailsElement(_id)
        .then(element => {
            movieSection.appendChild(element);
        })

    displayFooter();
}

function hideAllSections() {
    Array.from(containerDiv.children)
        .forEach(c => {
            c.remove();
        });
}