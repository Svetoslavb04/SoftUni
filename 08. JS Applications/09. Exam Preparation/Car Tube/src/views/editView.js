import { html } from '../../node_modules/lit-html/lit-html.js';
import { editCar, getCar } from '../services/carService.js';
import page from '../../node_modules/page/page.mjs';

const editTemplate = (car) => html`
    <section id="edit-listing">
        <div class="container">
            <form id="edit-form" @submit=${editHandler.bind(null, car)}>
                <h1>Edit Car Listing</h1>
                <p>Please fill in this form to edit an listing.</p>
                <hr>

                <p>Car Brand</p>
                <input type="text" placeholder="Enter Car Brand" name="brand" value="${car.brand}">

                <p>Car Model</p>
                <input type="text" placeholder="Enter Car Model" name="model" value="${car.model}">

                <p>Description</p>
                <input type="text" placeholder="Enter Description" name="description" value="${car.description}">

                <p>Car Year</p>
                <input type="number" placeholder="Enter Car Year" name="year" value="${car.year}">

                <p>Car Image</p>
                <input type="text" placeholder="Enter Car Image" name="imageUrl" value="${car.imageUrl}">

                <p>Car Price</p>
                <input type="number" placeholder="Enter Car Price" name="price" value="${car.price}">

                <hr>
                <input type="submit" class="registerbtn" value="Edit Listing">
            </form>
        </div>
    </section>`;

export async function renderEditView(ctx) {
    const car = await getCar(ctx.params._id);

    ctx.render(editTemplate(car));
}

function editHandler(car, e) {
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

    const newCar = {
        brand,
        model,
        description,
        year,
        imageUrl,
        price
      };
      
    editCar(car._id, newCar)
        .then(data => {
            if (data.message) {
                window.alert(data.message);
            } else {
                page.redirect(`/listings/${car._id}`);
            }
        })

}