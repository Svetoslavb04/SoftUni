import { html } from '../../node_modules/lit-html/lit-html.js';
import { getUser } from '../services/authService.js';
import { getCarsByUser } from '../services/carService.js';

const myListingsTemplate = (cars) => html`
<section id="my-listings">
            <h1>My car listings</h1>
            <div class="listings">
            ${
                cars.length > 0 ? html`${cars.map(r => html`
                <div class="listing">
                    <div class="preview">
                        <img src="${r.imageUrl}">
                    </div>
                    <h2>${r.brand} ${r.model}</h2>
                    <div class="info">
                        <div class="data-info">
                            <h3>Year: ${r.year}</h3>
                            <h3>Price: ${r.price} $</h3>
                        </div>
                        <div class="data-buttons">
                            <a href="/listings/${r._id}" class="button-carDetails">Details</a>
                        </div>
                    </div>
                </div>`)}`
                : html`<p class="no-cars"> You haven't listed any cars yet.</p>`
            }
            </div>
        </section>

`;

export async function renderMyListingsView(ctx) {
    const cars = await getCarsByUser(getUser()._id);

    ctx.render(myListingsTemplate(cars));
}