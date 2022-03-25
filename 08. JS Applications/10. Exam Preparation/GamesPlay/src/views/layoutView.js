import { html } from '../../node_modules/lit-html/lit-html.js';

export const layoutTemplate = (ctx, templateResult) => html`
        <header>
            <!-- Navigation -->
            <h1><a class="home" href="/">GamesPlay</a></h1>
            <nav>
                <a href="#">All games</a>
                <!-- Logged-in users -->
                ${ctx.isAuthenticated() ?
                    html`<div id="user">
                            <a href="/games/create">Create Game</a>
                            <a href="/logout">Logout</a>
                            </div>` :
                    html`<div id="guest">
                                <a href="/login">Login</a>
                                <a href="/register">Register</a>
                            </div>`
                }
            </nav>
        </header>
        <!-- Main Content -->
        <main id="main-content">
        ${html`${templateResult}`}
        </main>`;