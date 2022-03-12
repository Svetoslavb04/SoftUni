import { displayNavigation, displayFooter } from './layout.js';
import { likeMovie, dislikeMovie, deleteMovie } from '../services/movieService.js';
import { navigateTo } from '../router.js';
import { isAuthenticated, _id, authToken } from '../auth.js';
import { displayEditMovie } from './editMovie.js';

const containerDiv = document.querySelector('#container');
const movieSection = document.querySelector('#movie-example');


export async function displayDetails(_id) {
    hideAllSections();

    displayNavigation();

    containerDiv.appendChild(movieSection);


    await getMovieDetailsElement(_id)
        .then(element => {
            movieSection.innerHTML = '';
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

async function getMovieDetailsElement(movie_id) {
    
    let movie;
    
    await fetch(`http://localhost:3030/data/movies/${movie_id}`)
        .then((res) => res.json())
        .then((data) => {
            movie = data;
        })
        .catch(err => alert(err.message));
    
    const containerDiv = document.createElement('div');
    containerDiv.classList.add('container');
    containerDiv.setAttribute('movie_id', movie_id);

    //Data from server is valid
    containerDiv.innerHTML = `<div class="row bg-light text-dark">
    <h1>Movie title: ${movie.title}</h1>
    <div class="col-md-8">
        <img class="img-thumbnail" src="${movie.img}" alt="Movie">
    </div>
    <div class="col-md-4 text-center">
        <h3 class="my-3 ">Movie Description</h3>
        <p>${movie.description}</p>
    </div>
</div>`;
    
    const buttonsParent = containerDiv.children[0].children[2];

    const likes = await fetch(`http://localhost:3030/data/likes?where=movieId%3D%22${movie_id}%22&distinct=_ownerId&count `, {
            method: 'GET',
            headers: {
            }})
            .then(res => res.json())
            .then(data => {
                return data;
            });

    if (isAuthenticated) {
        if (movie._ownerId == _id) {
            buttonsParent.innerHTML += `<a class="btn btn-danger deleteBtn" href="/delete">Delete</a>
            <a class="btn btn-warning editBtn" href="/edit">Edit</a>
            <span class="enrolled-span likedSpan">Liked ${likes}</span>
            `;
    
            const editButton = containerDiv.querySelector('.editBtn');
            editButton.addEventListener('click', (e) => {
                e.preventDefault();

                displayEditMovie(movie_id);
            });

            const deleteButton = containerDiv.querySelector('.deleteBtn');
            deleteButton.addEventListener('click', async (e) => {
                e.preventDefault();

                await deleteMovie(movie_id);

                navigateTo('/');
            });
        } else {
            const res = await fetch(`http://localhost:3030/data/likes?where=movieId%3D%22${movie_id}%22%20and%20_ownerId%3D%22${_id}%22`, {
                method: 'GET',
                headers: {
                    'X-Authorization': authToken
                }});
    
            const userLikesForCurrentMovie = await res.json();

            if (userLikesForCurrentMovie.length == 0) {
                const likeButton = await getLikeButton(movie_id);
                buttonsParent.appendChild(likeButton);
            }
            else {
                const likedSpan = await getLikedSpan(movie_id);
                buttonsParent.appendChild(likedSpan);
            }
        }
    } else {
        buttonsParent.innerHTML += `<span class="enrolled-span likedSpan" href="#">Liked ${likes}</span>`;
    }
    
    return containerDiv;
}

async function getLikedSpan(movie_id) {
    const likes = await fetch(`http://localhost:3030/data/likes?where=movieId%3D%22${movie_id}%22&distinct=_ownerId&count `, {
            method: 'GET',
            headers: {
                'X-Authorization': authToken
            }})
            .then(res => res.json())
            .then(data => {
                return data;
            });

        const likedSpan = document.createElement('span');
        likedSpan.classList.add('enrolled-span', 'likedSpan');
        likedSpan.textContent = `Liked ${likes}`;
        likedSpan.addEventListener('click', async (e) => {
            e.preventDefault();
            await dislikeMovie(movie_id);

            const buttonsParent = e.target.parentNode;
            const likeButton = await getLikeButton(movie_id);

            likedSpan.remove();
            buttonsParent.appendChild(likeButton);
        });

    return likedSpan;
}

async function getLikeButton(movie_id) {
    const likeButton = document.createElement('a');
        likeButton.classList.add('btn' ,'btn-primary', 'likeBtn');
        likeButton.textContent = `Like`;
        likeButton.addEventListener('click', async (e) => {
            e.preventDefault();
            await likeMovie(movie_id);

            const buttonsParent = e.target.parentNode;
            const spanButton = await getLikedSpan(movie_id);
            
            likeButton.remove();
            buttonsParent.appendChild(spanButton);
        });

    return likeButton;
}