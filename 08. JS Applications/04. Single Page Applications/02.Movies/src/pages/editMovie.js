import { displayNavigation, displayFooter } from './layout.js';
import { editMovie } from '../services/movieService.js';
import { displayDetails } from './details.js';

const editMovieSection = document.getElementById('edit-movie');
const containerDiv = document.querySelector('#container');
const form = editMovieSection.querySelector('form');

const submitButton = editMovieSection.querySelector('button');

form.addEventListener('submit', async (e) => {
    e.preventDefault();

    const formdata = new FormData(form);
    
    let movie_id = e.currentTarget.querySelector('button').getAttribute('movie_id');
    let owner_id = e.currentTarget.querySelector('button').getAttribute('owner_id');
    let title = formdata.get('title');
    let description = formdata.get('description');
    let img = formdata.get('imageUrl');

    await editMovie(movie_id, title, description, img, owner_id);

    displayDetails(movie_id);
});

export async function displayEditMovie(movie_id) {
    hideAllSections();

    displayNavigation();

    const movie = await fetch(`http://localhost:3030/data/movies/${movie_id}`)
    .then((res) => res.json())
    .then((data) => {
        return data;
    })
    .catch(err => alert(err.message));

    submitButton.setAttribute('movie_id', movie_id);
    submitButton.setAttribute('owner_id', movie._ownerId);

    containerDiv.appendChild(editMovieSection);

    form.querySelector('#title').value = movie.title;
    form.querySelector('textarea').value = movie.description;
    form.querySelector('#imageUrl').value = movie.img;

    displayFooter();
}

function hideAllSections() {
    Array.from(containerDiv.children)
        .forEach(c => {
            c.remove();
        });
}