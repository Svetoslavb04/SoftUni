import { html } from "../../node_modules/lit-html/lit-html.js";
import { editEntity, getOne } from "../services/entityService.js";

const editTemplate = (ctx, pet) => html`
    <section id="editPage">
        <form class="editForm" @submit=${editHandler.bind(null, ctx)}>
            <img src="/images/editpage-dog.jpg">
            <div>
                <h2>Edit PetPal</h2>
                <div class="name">
                    <label for="name">Name:</label>
                    <input name="name" id="name" type="text" value="${pet.name}">
                </div>
                <div class="breed">
                    <label for="breed">Breed:</label>
                    <input name="breed" id="breed" type="text" value="${pet.breed}">
                </div>
                <div class="Age">
                    <label for="age">Age:</label>
                    <input name="age" id="age" type="text" value="${pet.age}">
                </div>
                <div class="weight">
                    <label for="weight">Weight:</label>
                    <input name="weight" id="weight" type="text" value="${pet.weight}">
                </div>
                <div class="image">
                    <label for="image">Image:</label>
                    <input name="image" id="image" type="text" value="${pet.image}">
                </div>
                <button class="btn" type="submit">Edit Pet</button>
            </div>
        </form>
    </section>`;

export function renderEditView(ctx) {
    getOne(ctx.params._id)
        .then(book => ctx.render(editTemplate(ctx, book)));
}

function editHandler(ctx, e) {
    e.preventDefault();

    const formdata = new FormData(e.currentTarget);

    const name = formdata.get('name');
    const breed = formdata.get('breed');
    const age = formdata.get('age');
    const weight = formdata.get('weight');
    const image = formdata.get('image');

    if (!name || !breed || !age || !weight || !image) {
        return window.alert('All fields are required!');
    }

    const pet = {
        name,
        breed,
        age,
        weight,
        image
    }

    editEntity(ctx.params._id, pet)
        .then(data => {
            if (data.message) {
                window.alert(data.message);
            }
            else {
                ctx.page.redirect(`/pets/${ctx.params._id}`);
            }
        })
}