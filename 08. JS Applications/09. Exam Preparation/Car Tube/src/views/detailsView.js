import page from '../../node_modules/page/page.mjs';
import { html } from '../../node_modules/lit-html/lit-html.js';
import { getUser } from '../services/authService.js';
import { deleteCar, getCar } from '../services/carService.js';

const detailsTemplate = (car) => html`
<section id="listing-details">
    <h1>Details</h1>
    <div class="details-info">
        <img src="${car.imageUrl}">
        <hr>
        <ul class="listing-props">
            <li><span>Brand:</span>${car.brand}</li>
            <li><span>Model:</span>${car.model}</li>
            <li><span>Year:</span>${car.year}</li>
            <li><span>Price:</span>${car.price}$</li>
        </ul>

        <p class="description-para">${car.description}</p>
        ${car._ownerId == getUser()._id ? html`
            <div class="listings-buttons">
                <a href="/listings/edit/${car._id}" class="button-list">Edit</a>
                <a href="" class="button-list" @click=${deleteHandler.bind(null, car._id)}>Delete</a>
            </div>`
            : html``
        }
    </div>
</section>`;

export async function renderDetailsView(ctx) {
    const car = await getCar(ctx.params._id);

    ctx.render(detailsTemplate(car));
}

function deleteHandler(_id, e) {
    if (confirm('Are you sure you want to delete it?') == true) {
        deleteCar(_id)
            .then(data => {
                if (data.message) {
                    window.alert(data.message);
                } else {
                    page.redirect('/listings/all');
                }
            })
    }
}