import { html, render } from '../node_modules/lit-html/lit-html.js';
import { navigationTemplate } from './navigationTemplate.js';
import { getFurnitureDetails } from './api.js';
import { user } from './auth.js';
import page from '../node_modules/page/page.mjs';

const validate = {
    make: (make) => {
        if (!make.value || make.value.length < 3) {
            make.classList.add('is-invalid');

            return false;
        } else {
            make.classList.add('is-valid');

            return true;
        }
    },
    model: (model) => {
        if (!model.value || model.value.length < 3) {
            model.classList.add('is-invalid');

            return false;
        } else {
            model.classList.add('is-valid');

            return true;
        }
    },
    description: (description) => {
        if (!description.value || description.value.length < 10) {
            description.classList.add('is-invalid');

            return false;
        } else {
            description.classList.add('is-valid');

            return true;
        }
    },
    price: (price) => {
        if (!price.value || Number(price.value) < 0) {
            price.classList.add('is-invalid');

            return false;
        } else {
            price.classList.add('is-valid');

            return true;
        }
    },
    year: (year) => {
        if (!year.value || Number(year.value) < 1949 || Number(year.value) > 2051) {
            year.classList.add('is-invalid');

            return false;
        } else {
            year.classList.add('is-valid');

            return true;
        }
    },
    img: (img) => {
        if (!img.value) {
            img.classList.add('is-invalid');

            return false;
        } else {
            img.classList.add('is-valid');

            return true;
        }
    },
}

const editPageTemplate = (furniture) => html`
    ${html`${navigationTemplate()}`}
    <div class="container">
        <div class="row space-top">
            <div class="col-md-12">
                <h1>Edit Furniture</h1>
                <p>Please fill all fields.</p>
            </div>
        </div>
        <form @submit=${editHandler}>
            <div class="row space-top">
                <div class="col-md-4">
                    <div class="form-group">
                        <label class="form-control-label" for="new-make">Make</label>
                        <input class="form-control" id="new-make" type="text" name="make" value=${furniture.make}>
                    </div>
                    <div class="form-group">
                        <label class="form-control-label" for="new-model">Model</label>
                        <input class="form-control" id="new-model" type="text" name="model" value=${furniture.model}>
                    </div>
                    <div class="form-group">
                        <label class="form-control-label" for="new-year">Year</label>
                        <input class="form-control" id="new-year" type="number" name="year" value=${furniture.year}>
                    </div>
                    <div class="form-group">
                        <label class="form-control-label" for="new-description">Description</label>
                        <input class="form-control" id="new-description" type="text" name="description" value=${furniture.description}>
                    </div>
                </div>
                <div class="col-md-4">
                    <div class="form-group">
                        <label class="form-control-label" for="new-price">Price</label>
                        <input class="form-control" id="new-price" type="number" name="price" value=${furniture.price}>
                    </div>
                    <div class="form-group">
                        <label class="form-control-label" for="new-image">Image</label>
                        <input class="form-control" id="new-image" type="text" name="img" value=${furniture.img}>
                    </div>
                    <div class="form-group">
                        <label class="form-control-label" for="new-material">Material (optional)</label>
                        <input class="form-control" id="new-material" type="text" name="material" value=${furniture.material}>
                    </div>
                    <input type="submit" class="btn btn-info" value="Edit" />
                </div>
            </div>
        </form>
    </div>
`;

export async function renderEditView(ctx) {
    const furniture = await getFurnitureDetails(ctx.params._id);
    
    render(editPageTemplate(furniture), document.getElementById('root'));
}

function editHandler(e) {
    e.preventDefault();

    let pageparh= page.Context(location.pathname);

    if (page.Context.params._id) {
        console.log('I am owner!');
    }

    const formElements = {
        makeElement: document.querySelector('input[name="make"]'),
        modelElement: document.querySelector('input[name="model"]'),
        yearElement: document.querySelector('input[name="year"]'),
        descriptionElement:  document.querySelector('input[name="description"]'),
        priceElement: document.querySelector('input[name="price"]'),
        imgElement: document.querySelector('input[name="img"]'),
        materialElement: document.querySelector('input[name="material"]'),
    }

    Array.from(Object.values(formElements)).forEach(element => {
        element.classList.remove('is-valid');
        element.classList.remove('is-invalid');
    });

    let validatorValues = [
        validate.make(formElements.makeElement),
        validate.model(formElements.modelElement),
        validate.year(formElements.yearElement),
        validate.description(formElements.descriptionElement),
        validate.price(formElements.priceElement),
        validate.img(formElements.imgElement)
    ];

    if (validatorValues.some(x => x == false)) return;


}