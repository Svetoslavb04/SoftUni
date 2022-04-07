import { html } from "../../node_modules/lit-html/lit-html.js";
import { createEntity } from "../services/entityService.js";

const createTemplate = (ctx) => html`
    <section id="createPage">
        <form class="createForm" @submit=${createHandler.bind(null, ctx)}>
            <img src="/images/cat-create.jpg">
            <div>
                <h2>Create PetPal</h2>
                <div class="name">
                    <label for="name">Name:</label>
                    <input name="name" id="name" type="text" placeholder="name">
                </div>
                <div class="breed">
                    <label for="breed">Breed:</label>
                    <input name="breed" id="breed" type="text" placeholder="breed">
                </div>
                <div class="Age">
                    <label for="age">Age:</label>
                    <input name="age" id="age" type="text" placeholder="age">
                </div>
                <div class="weight">
                    <label for="weight">Weight:</label>
                    <input name="weight" id="weight" type="text" placeholder="weight">
                </div>
                <div class="image">
                    <label for="image">Image:</label>
                    <input name="image" id="image" type="text" placeholder="image">
                </div>
                <button class="btn" type="submit">Create Pet</button>
            </div>
        </form>
    </section>`;

export function renderCreateView(ctx) {
    ctx.render(createTemplate(ctx));
}

function createHandler(ctx, e) {
    e.preventDefault();

    const formdata = new FormData(e.currentTarget);

    const name = formdata.get('name');
    const breed = formdata.get('breed');
    const age = formdata.get('age');
    const weight = formdata.get('weight');
    const image = formdata.get('image');

    const pet = {
        name,
        breed,
        age,
        weight,
        image
    }

    if (!name || !breed || !age || !weight || !image) {
        return window.alert('All fields are required');
    }
    
    createEntity(pet)
        .then(data => {
            if (data.message) {
                window.alert(data.message);
            }
            else {
                ctx.page.redirect('/');
            }
        })
}