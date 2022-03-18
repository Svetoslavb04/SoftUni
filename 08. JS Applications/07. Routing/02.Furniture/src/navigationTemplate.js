import { logout, user } from './auth.js';
import { html } from '../node_modules/lit-html/lit-html.js';
import page from '../node_modules/page/page.mjs';

export let navigationTemplate = () => {
    if (user != undefined) {
        return html`
        <header>
            <h1><a href="/">Furniture Store</a></h1>
            <nav>
                <a id="catalogLink" href="/" class="active">Dashboard</a>
                <div id="user">
                    <a id="createLink" href="/create" >Create Furniture</a>
                    <a id="profileLink" href="/my-furniture" >My Publications</a>
                    <a id="logoutBtn" @click=${logoutHandler}>Logout</a>
                </div>
            </nav>
        </header>`;
    } else {
        return html`
        <header>
            <h1><a href="/">Furniture Store</a></h1>
            <nav>
                <div id="guest">
                    <a id="loginLink" href="/login">Login</a>
                    <a id="registerLink" href="/register">Register</a>
                </div>
            </nav>
        </header>`;
    }
};

function logoutHandler(e) {
    e.preventDefault();

    logout();

    page.redirect('/');
}