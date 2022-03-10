import { displayDetails } from '../pages/details.js';
import { _id } from '../auth.js';

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

    if (movie._ownerId == _id) {
        buttonsParent.innerHTML += `<a class="btn btn-danger deleteBtn" href="#">Delete</a>
        <a class="btn btn-warning editBtn" href="#">Edit</a>
        <span class="enrolled-span likedSpan">Liked 1</span>
        `;
    } else {
        buttonsParent.innerHTML += `<a class="btn btn-primary likeBtn" href="#">Like</a>`;
    }

    let editButton = containerDiv.querySelector('.editBtn');
    let deleteButton = containerDiv.querySelector('.deleteBtn');
    let likeButton = containerDiv.querySelector('.likeBtn');
    let likedSpan = containerDiv.querySelector('.likedSpan');

    likeButton.addEventListener('click', likeMovie);

    return containerDiv;
}

function likeMovie() {
    
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
