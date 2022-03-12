import { displayDetails } from '../pages/details.js';
import { displayEditMovie } from '../pages/editMovie.js';
import { authToken, _id, isAuthenticated } from '../auth.js';
import { navigateTo } from '../router.js';

export async function getAllMoviesPreviewElements() {
    let moviesElements = [];

    await fetch('http://localhost:3030/data/movies')
        .then((res) => res.json())
        .then((data) => {
            Object.values(data).forEach(m => {
                const movieElement = createMoviePreviewElement(m);

                moviesElements.push(movieElement);
            });
        })
        .catch(err => alert(err.message));

    return moviesElements;
}

export async function getMovieInfo(movie_id) {
    return await fetch(`http://localhost:3030/data/movies/${movie_id}`)
    .then((res) => res.json())
    .then((data) => {
        return data;
    })
    .catch(err => alert(err.message));
}

export async function editMovie(movie_id , title, description, img, _ownerId) {
    let movie = {
        _ownerId: _ownerId,
        title: title, 
        description: description,
        img: img,
        _id: movie_id
    }
    fetch(`http://localhost:3030/data/movies/${movie_id}`, {
            method: 'PUT',
            headers: {
                'Content-type': 'application/json',
                'X-Authorization': authToken
            },
            body: JSON.stringify(movie)
    })
    .catch(err => alert(err.message));
}

export async function deleteMovie(movie_id) {
    await fetch(`http://localhost:3030/data/movies/${movie_id}`, {
            method: 'DELETE',
            headers: {
                'Content-type': 'application/json',
                'X-Authorization': authToken
            }
    })
    .catch(err => alert(err.message));
}

export async function likeMovie(movie_id) {
    try {
        await fetch('http://localhost:3030/data/likes', {
            method: 'POST',
            headers: {
                'content-type': 'application/json',
                'X-Authorization': authToken
            },
            body: JSON.stringify({
                movieId: movie_id
            })
        });
    } catch (error) {
        alert(error.message);
    }
}

export async function dislikeMovie(movie_id) {
    try {
        const likeId = await fetch(`http://localhost:3030/data/likes?where=movieId%3D%22${movie_id}%22%20and%20_ownerId%3D%22${_id}%22`, {
            method: 'GET',
            headers: {
                'X-Authorization': authToken
            }})
            .then((res) => res.json())
            .then((data) => {
                return data[0]._id;
            });

        console.log(likeId);

        await fetch(`http://localhost:3030/data/likes/${likeId}`, {
            method: 'DELETE',
            headers: {
                'X-Authorization': authToken
            }});
    } catch (error) {
        alert(error.message);
    }
}

function createMoviePreviewElement(movie) {
    const cardDiv = document.createElement('div');
    cardDiv.classList.add('card', 'mb-4');
    cardDiv.setAttribute('_ownerId', movie._ownerId);

    //Data from server is sanitized and valid
    cardDiv.innerHTML = `<img class="card-img-top" src="${movie.img}"
    alt="Card image cap" width="400">
<div class="card-body">
   <h4 class="card-title">${movie.title}</h4>
</div>
<div class="card-footer">
   <a href="/details">
       <button type="button" class="btn btn-info" _id="${movie._id}">Details</button>
   </a>
</div>`;

    const detailsButton = cardDiv.querySelector('button');
    detailsButton.addEventListener('click', (e) => {
        e.preventDefault();

        displayDetails(detailsButton.getAttribute('_id'));
    });

    return cardDiv;
}
