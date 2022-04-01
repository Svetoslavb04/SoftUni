import { html } from "../node_modules/lit-html/lit-html.js";
import { getUser } from "../services/authService.js";
import { getAllOfUser } from "../services/entityService.js";

const mineTemplate = (books) => html`
    <section id="my-books-page" class="my-books">
    <h1>My Books</h1>
    ${
        books.length > 0
        ? html`
            <ul class="my-books-list">
                ${books.map(b => html`
                    <li class="otherBooks">
                        <h3>${b.title}</h3>
                        <p>Type: ${b.type}</p>
                        <p class="img"><img src="${b.imageUrl}"></p>
                        <a class="button" href="/books/${b._id}">Details</a>
                    </li>`
                )}
                
            </ul>`
        : html `<p class="no-books">No books in database!</p>`
    }
    </section>`;

export function renderMineView(ctx) {
    getAllOfUser(getUser()._id)
        .then(books => ctx.render(mineTemplate(books)));
}