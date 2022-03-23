import { html } from '../../node_modules/lit-html/lit-html.js';
import { getCarsByYear } from '../services/carService.js';

const searchTemplate = (ctx, cars = false) => html`
<section id="search-cars">
<h1>Filter by year</h1>

<div class="container">
    <input id="search-input" type="text" name="search" placeholder="Enter desired production year">
    <button class="button-list" @click=${searchHandler.bind(null, ctx)}>Search</button>
</div>

<h2>Results:</h2>
<div class="listings">
    ${
        cars ? 
        (cars.length > 0 ? html`${cars.map(r => html`
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
        : html`<p class="no-cars"> No results.</p>`) : html``
    }
</div>
</section>
`;

export function renderSearchView(ctx) {
    ctx.render(searchTemplate(ctx));
}

async function searchHandler(ctx, e) {
    e.preventDefault();

    const search = document.querySelector('#search-input').value;

    const cars = await getCarsByYear(search);

    ctx.render(searchTemplate(ctx, cars));
}