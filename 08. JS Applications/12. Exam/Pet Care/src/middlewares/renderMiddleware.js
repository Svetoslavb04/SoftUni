import { html, render } from '../../node_modules/lit-html/lit-html.js';

const layoutTemplate = (ctx, template) => html`
    <header>
        <nav>
            <section class="logo">
                <a href="/"><img src="/images/logo.png" alt="logo"></a>
            </section>
            <ul>
                <!--Users and Guest-->
                <li><a href="/">Home</a></li>
                <li><a href="/dashboard">Dashboard</a></li>
                ${ctx.isAuthenticated()
                    ? html`<li><a href="/pets/create">Create Postcard</a></li>
                           <li><a href="/logout">Logout</a></li>`
                    : html`<li><a href="/login">Login</a></li>
                           <li><a href="/register">Register</a></li>`
                }
            </ul>
        </nav>
    </header>
    <main id="main-content">${html`${template}`}</main>
    <footer>Pet Care 2022©</footer>`;

export function renderMiddleware(ctx, next) {
    ctx.render = (template) => render(layoutTemplate(ctx, template), document.querySelector('body'));
    next();
}