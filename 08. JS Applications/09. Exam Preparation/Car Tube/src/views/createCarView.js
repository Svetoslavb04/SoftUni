import { html } from "../../node_modules/lit-html/lit-html.js";
import { createCar } from "../services/carService.js";
import page from '../../node_modules/page/page.mjs';

const createCarTemplate = html`
    <div class="container">
        <form id="create-form" @submit="${createHandler}">
            <h1>Create Car Listing</h1>
            <p>Please fill in this form to create an listing.</p>
            <hr>

            <p>Car Brand</p>
            <input type="text" placeholder="Enter Car Brand" name="brand">

            <p>Car Model</p>
            <input type="text" placeholder="Enter Car Model" name="model">

            <p>Description</p>
            <input type="text" placeholder="Enter Description" name="description">

            <p>Car Year</p>
            <input type="number" placeholder="Enter Car Year" name="year">

            <p>Car Image</p>
            <input type="text" placeholder="Enter Car Image" name="imageUrl">

            <p>Car Price</p>
            <input type="number" placeholder="Enter Car Price" name="price">

            <hr>
            <input type="submit" class="registerbtn" value="Create Listing">
        </form>
    </div>`;

export function renderCreateCarView(ctx) {
    ctx.render(createCarTemplate);
}

function createHandler(e) {
    e.preventDefault();
    const formdata = new FormData(e.currentTarget);

    const brand = formdata.get('brand');
    const model = formdata.get('model');
    const description = formdata.get('description');
    const year = Number(formdata.get('year'));
    const imageUrl = formdata.get('imageUrl');
    const price = Number(formdata.get('price'));

    if (!brand || !model || !description || !year || !imageUrl || !price || year < 0 || price < 0) {
        return;
    }

    createCar(brand, model, description, year, imageUrl, price)
        .then(data => {
            if (data.message) {
                window.alert(data.message);
            } else {
                page.redirect('/listings/all');
            }
        })

}