import { html } from "../../node_modules/lit-html/lit-html.js";

const guestButtons = html`
    <a href="/login" class="action">Login</a>
    <a href="/register" class="action">Register</a>`;

const userButtons = html`
    <a href="/my-teams" class="action">My Teams</a>
    <a href="/logout" class="action">Logout</a>`;

const headerTemplate = (ctx) => html`
    <header id="titlebar" class="layout">
        <a href="/" class="site-logo">Team Manager</a>
        <nav>
            <a href="/browse" class="action">Browse Teams</a>
            ${ctx.isAuthenticated ? userButtons : guestButtons}
        </nav>
    </header>`;

const footerTemplate = html`
    <footer id="footer">
        SoftUni &copy; 2014-2021
    </footer>`;

export const layoutTemplate = (ctx, templateResult) => html`
    <div id="content">
        ${headerTemplate(ctx)}
        <main>${templateResult}</main>
        ${footerTemplate}
    </div>`;

