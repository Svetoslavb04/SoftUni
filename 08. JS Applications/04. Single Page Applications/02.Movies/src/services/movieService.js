import { displayDetails } from '../pages/details.js';

export async function getAllMoviesPreviewElements() {
    let moviesElements = [];

    await fetch('http://localhost:3030/data/movies')
        .then((res) => res.json())
        .then((data) => {
            Object.values(data).forEach(m => {
                const movieElement = createMovieElement(m);

                moviesElements.push(movieElement);
            });
        })
        .catch(err => alert(err.message));

    return moviesElements;
}

function createMovieElement(movie) {
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
