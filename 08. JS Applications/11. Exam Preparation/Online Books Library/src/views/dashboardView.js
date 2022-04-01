import { html } from "../node_modules/lit-html/lit-html.js";
import { getAll } from "../services/entityService.js";

const dashboardTemplate = (books) => html`
    <section id="dashboard-page" class="dashboard">
        <h1>Dashboard</h1>
        ${
            books.length > 0
            ? html`
                <ul class="other-books-list">
                    ${books.map(b => html`<li class="otherBooks">
                                            <h3>${b.title}</h3>
                                            <p>Type: ${b.type}</p>
                                            <p class="img"><img src="${b.imageUrl}"></p>
                                            <a class="button" href="/books/${b._id}">Details</a>
                                        </li>`)}
                </ul>`
            : html`<p class="no-books">No books in database!</p>`
        }
    </section>`;

export function renderDashboardView(ctx) {
    getAll()
        .then(books => ctx.render(dashboardTemplate(books)));
}