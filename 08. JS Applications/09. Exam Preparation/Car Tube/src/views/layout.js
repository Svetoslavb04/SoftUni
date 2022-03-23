import { html } from '../../node_modules/lit-html/lit-html.js';

export const layoutTemplate = (ctx, templateResult) => html`
        <header>
            <nav>
                <a class="active" href="#">Home</a>
                <a href="#">All Listings</a>
                <a href="#">By Year</a>
                ${
                    ctx.isAuthenticated ?
                        html`<div id="profile">
                            <a>Welcome username</a>
                            <a href="#">My Listings</a>
                            <a href="#">Create Listing</a>
                            <a href="#">Logout</a>
                        </div>` :
                        html`<div id="guest">
                            <a href="/login">Login</a>
                            <a href="/register">Register</a>
                        </div>`
                }
            </nav>
        </header>
        <main id="site-content">
        ${
            html`${templateResult}`
        }
        </main>
        <footer>
            <p>&copy; All rights reserved</p>
        </footer>`;