import { html } from "../node_modules/lit-html/lit-html.js";
import { createEntity } from "../services/entityService.js";

const createTemplate = (ctx) => html`
    <section id="create-page" class="create">
        <form id="create-form" @submit=${createHandler.bind(null, ctx)}>
            <fieldset>
                <legend>Add new Book</legend>
                <p class="field">
                    <label for="title">Title</label>
                    <span class="input">
                        <input type="text" name="title" id="title" placeholder="Title" required>
                    </span>
                </p>
                <p class="field">
                    <label for="description">Description</label>
                    <span class="input">
                        <textarea name="description" id="description" placeholder="Description" required></textarea>
                    </span>
                </p>
                <p class="field">
                    <label for="image">Image</label>
                    <span class="input">
                        <input type="text" name="imageUrl" id="image" placeholder="Image" required>
                    </span>
                </p>
                <p class="field">
                    <label for="type">Type</label>
                    <span class="input">
                        <select id="type" name="type" required>
                            <option value="Fiction">Fiction</option>
                            <option value="Romance">Romance</option>
                            <option value="Mistery">Mistery</option>
                            <option value="Classic">Clasic</option>
                            <option value="Other">Other</option>
                        </select>
                    </span>
                </p>
                <input class="button submit" type="submit" value="Add Book">
            </fieldset>
        </form>
    </section>`;

export function renderCreateView(ctx) {
    ctx.render(createTemplate(ctx));
}

function createHandler(ctx, e) {
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

    createEntity(book)
        .then(data => {
            if (data.message) {
                window.alert(data.message);
            }
            else {
                ctx.page.redirect('/');
            }
        })
}