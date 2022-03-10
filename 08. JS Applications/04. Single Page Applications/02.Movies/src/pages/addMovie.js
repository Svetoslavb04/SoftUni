import { displayNavigation, displayFooter } from './layout.js';
import { authToken, _id } from '../auth.js';
import { navigateTo } from '../router.js';

const addMovieSection = document.getElementById('add-movie');
const containerDiv = document.getElementById('container');

const addMovieForm = addMovieSection.querySelector('form');
addMovieForm.addEventListener('submit', addMovie);

export function displayAddMovie() {
   displayNavigation();

   containerDiv.appendChild(addMovieSection);

   displayFooter();
}

async function addMovie(e) {
    e.preventDefault();

    const formData = new FormData(e.currentTarget);

    const title = formData.get('title');
    const description = formData.get('description');
    const img = formData.get('imageUrl');
    try {
    
        if (!title || !description || !img) {
            throw new Error('All fields are required');
        }
    
        await fetch('http://localhost:3030/data/movies', {
            method: 'POST',
            headers: {
                'Content-Type': 'application/json',
                'X-Authorization': authToken
            },
            body: JSON.stringify({
                '_ownerId': _id,
                title,
                description,
                img
            })
        });

        navigateTo('/');

    } catch (error) {
        alert(error.message);
    }
}