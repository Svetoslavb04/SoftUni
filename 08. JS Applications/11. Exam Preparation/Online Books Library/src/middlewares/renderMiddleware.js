import { html, render } from '../node_modules/lit-html/lit-html.js';

const layoutTemplate = (ctx, template) => html`
    <header id="site-header">
        <nav class="navbar">
            <section class="navbar-dashboard">
                <a href="/">Dashboard</a>
                ${ctx.isAuthenticated()
                    ? html`
                        <div id="user">
                            <span>Welcome, ${ctx.userEmail()}</span>
                            <a class="button" href="/books/mine">My Books</a>
                            <a class="button" href="/books/add">Add Book</a>
                            <a class="button" href="/logout">Logout</a>
                        </div>`
                    : html`
                        <div id="guest">
                            <a class="button" href="/login">Login</a>
                            <a class="button" href="/register">Register</a>
                        </div>`
                }
            </section>
        </nav>
    </header>
    <main id="site-content">${html`${template}`}</main>
    <footer id="site-footer">
        <p>@OnlineBooksLibrary</p>
    </footer>`;

export function renderMiddleware(ctx, next) {
    ctx.render = (template) => render(layoutTemplate(ctx, template), document.getElementById('container'));
    next();
}