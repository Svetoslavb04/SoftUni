import { displayNavigation, displayFooter } from './layout.js';
import { isAuthenticated } from '../auth.js';
import { getAllMoviesPreviewElements } from '../services/movieService.js';

const containerDiv = document.getElementById('container');
const homeSection = containerDiv.querySelector('#home-page');
const moviesHeader = containerDiv.querySelector('#container > h1');
const addMovieButton = containerDiv.querySelector('#add-movie-button');
const moviesSection = containerDiv.querySelector('#movie');

export function displayHome() {
    displayNavigation();
    
    containerDiv.appendChild(homeSection);
    containerDiv.appendChild(moviesHeader);

    if (isAuthenticated) {
        containerDiv.appendChild(addMovieButton);
    }

    getAllMoviesPreviewElements()
        .then(movies => {
            let moviesCount = movies.length;

            let currentMoviesInRowCount = 0;
            let totalDecks = 0;
            let movieSubclassRow = moviesSection.children[0].children[0];

            movies.forEach(m => {
                if (currentMoviesInRowCount == 5 || totalDecks == 0) {

                    let carDeckDiv = document.createElement('div');
                    carDeckDiv.classList.add('card-deck', 'd-flex', 'justify-content-center');
                    movieSubclassRow.appendChild(carDeckDiv);

                    totalDecks++;
                    currentMoviesInRowCount = 0;
                }

                movieSubclassRow.children[totalDecks-1].appendChild(m);
                currentMoviesInRowCount++;
            })
        })
        .catch(err => alert(err.message));

    containerDiv.appendChild(moviesSection);
    displayFooter();
}