import { html } from "../node_modules/lit-html/lit-html.js";
import { editEntity, getOne } from "../services/entityService.js";

const editTemplate = (ctx, book) => html`
    <section id="edit-page" class="edit">
        <form id="edit-form" @submit=${editHandler.bind(null, ctx)}>
            <fieldset>
                <legend>Edit my Book</legend>
                <p class="field">
                    <label for="title">Title</label>
                    <span class="input">
                        <input type="text" name="title" id="title" value="${book.title}" required>
                    </span>
                </p>
                <p class="field">
                    <label for="description">Description</label>
                    <span class="input">
                        <textarea name="description"
                            id="description" required>${book.description}</textarea>
                    </span>
                </p>
                <p class="field">
                    <label for="image">Image</label>
                    <span class="input">
                        <input type="text" name="imageUrl" id="image" value="${book.imageUrl}" required>
                    </span>
                </p>
                <p class="field">
                    <label for="type">Type</label>
                    <span class="input">
                        <select id="type" name="type" value="${book.type}" required>
                            <option value="Fiction" selected>Fiction</option>
                            <option value="Romance">Romance</option>
                            <option value="Mistery">Mistery</option>
                            <option value="Classic">Clasic</option>
                            <option value="Other">Other</option>
                        </select>
                    </span>
                </p>
                <input class="button submit" type="submit" value="Save">
            </fieldset>
        </form>
    </section>`;

export function renderEditView(ctx) {
    getOne(ctx.params._id)
        .then(book => ctx.render(editTemplate(ctx, book)));
}

function editHandler(ctx, e) {
    e.preventDefault();

    const formdata = new FormData(e.currentTarget);

    const title = formdata.get('title');
    const description = formdata.get('description');
    const imageUrl = formdata.get('imageUrl');
    const type = formdata.get('type');

    const book = {
        title,
        description,
        imageUrl,
        type
    }

    editEntity(ctx.params._id, book)
        .then(data => {
            if (data.message) {
                window.alert(data.message);
            }
            else {
                ctx.page.redirect(`/books/${ctx.params._id}`);
            }
        })
}