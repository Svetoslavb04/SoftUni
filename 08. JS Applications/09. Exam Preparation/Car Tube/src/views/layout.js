import { html } from '../../node_modules/lit-html/lit-html.js';
import { getUser } from '../services/authService.js';

export const layoutTemplate = (ctx, templateResult) => html`
        <header>
            <nav>
                <a class="active" href="/">Home</a>
                <a href="/listings/all">All Listings</a>
                <a href="/search">By Year</a>
                ${
                    ctx.isAuthenticated ?
                        html`<div id="profile">
                            <a>Welcome ${getUser().username}</a>
                            <a href="/user/listings">My Listings</a>
                            <a href="/listing">Create Listing</a>
                            <a href="/logout">Logout</a>
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