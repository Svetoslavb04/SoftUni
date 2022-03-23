import { html } from "../../node_modules/lit-html/lit-html.js";
import { getAllCars } from "../services/carService.js";

const allListingsTemplate = (cars) => html`
<section id="car-listings">
    <h1>Car Listings</h1>
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
        : html`<p class="no-cars">No cars in database.</p>`
    }
    </div>
</sections>`;

export async function renderAllListings(ctx) {
    let cars = await getAllCars();
    
    ctx.render(allListingsTemplate(cars));
}