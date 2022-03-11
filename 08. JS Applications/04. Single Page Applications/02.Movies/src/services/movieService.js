import { displayDetails } from '../pages/details.js';
import { authToken, _id } from '../auth.js';

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

export async function getMovieDetailsElement(movie_id) {
    
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
                'X-Authorization': authToken
            }})
            .then(res => res.json())
            .then(data => {
                return data;
            });

    if (movie._ownerId == _id) {
        buttonsParent.innerHTML += `<a class="btn btn-danger deleteBtn" href="#">Delete</a>
        <a class="btn btn-warning editBtn" href="#">Edit</a>
        <span class="enrolled-span likedSpan">Liked ${likes}</span>
        `;

        const editButton = containerDiv.querySelector('.editBtn');
        const deleteButton = containerDiv.querySelector('.deleteBtn');
    } else {
        const res = await fetch(`http://localhost:3030/data/likes?where=movieId%3D%22${movie_id}%22%20and%20_ownerId%3D%22${_id}%22`, {
            method: 'GET',
            headers: {
                'X-Authorization': authToken
            }});

        const data = await res.json();
        if (data.length == 0) {
            buttonsParent.innerHTML += `<a class="btn btn-primary likeBtn" href="#">Like</a>`;
            const likeButton = containerDiv.querySelector('.likeBtn');

            likeButton.addEventListener('click', likeMovie);
        }
        else {
            buttonsParent.innerHTML += `<span class="enrolled-span likedSpan" href="#">Liked ${likes}</span>`;
            const likedSpan = containerDiv.querySelector('.likedSpan');
            likedSpan.addEventListener('click', dislikeMovie);
        }
    }

    

    return containerDiv;
}

async function likeMovie(e) {
    const likeButton = e.currentTarget
    const movieId = likeButton.parentNode.parentNode.parentNode.getAttribute('movie_id');

    try {
        await fetch('http://localhost:3030/data/likes', {
            method: 'POST',
            headers: {
                'content-type': 'application/json',
                'X-Authorization': authToken
            },
            body: JSON.stringify({
                movieId
            })
        });

        const likes = await fetch(`http://localhost:3030/data/likes?where=movieId%3D%22${movieId}%22&distinct=_ownerId&count `, {
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
        likedSpan.addEventListener('click', dislikeMovie);

        likeButton.parentNode.appendChild(likedSpan);
        likeButton.remove();

    } catch (error) {
        alert(error.message);
    }
}

async function dislikeMovie(e) {
    const likedSpan = e.currentTarget
    const movieId = likedSpan.parentNode.parentNode.parentNode.getAttribute('movie_id');

    try {
        const likeId = await fetch(`http://localhost:3030/data/likes?where=movieId%3D%22${movieId}%22%20and%20_ownerId%3D%22${_id}%22`, {
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

        const likeButton = document.createElement('a');
        likeButton.classList.add('btn' ,'btn-primary', 'likeBtn');
        likeButton.textContent = `Like`;
        likeButton.addEventListener('click', likeMovie);

        likedSpan.parentNode.appendChild(likeButton);
        likedSpan.remove();

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
