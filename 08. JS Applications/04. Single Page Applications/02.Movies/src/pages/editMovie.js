import { displayNavigation, displayFooter } from './layout.js';
import { editMovie } from '../services/movieService.js';
import { displayDetails } from './details.js';

const editMovieSection = document.getElementById('edit-movie');
const containerDiv = document.querySelector('#container');

export async function displayEditMovie(movie_id) {
    hideAllSections();

    displayNavigation();

    containerDiv.appendChild(editMovieSection);

    const movie = await fetch(`http://localhost:3030/data/movies/${movie_id}`)
    .then((res) => res.json())
    .then((data) => {
        return data;
    })
    .catch(err => alert(err.message));

    const form = editMovieSection.querySelector('form');

    form.querySelector('#title').value = movie.title;
    form.querySelector('textarea').value = movie.description;
    form.querySelector('#imageUrl').value = movie.img;

    form.addEventListener('submit', async (e) => {
        e.preventDefault();

        const formdata = new FormData(form);

        let title = formdata.get('title');
        let description = formdata.get('description');
        let img = formdata.get('imageUrl');

        await editMovie(movie_id, title, description, img, movie._ownerId);

        displayDetails(movie_id);
    });

    displayFooter();
}

function hideAllSections() {
    Array.from(containerDiv.children)
        .forEach(c => {
            c.remove();
        });
}