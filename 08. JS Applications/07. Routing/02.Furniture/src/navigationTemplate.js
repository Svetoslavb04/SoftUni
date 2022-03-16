import { user } from './auth.js';
import { html } from '../node_modules/lit-html/lit-html.js';

export let navigationTemplate;

if (user) {
    navigationTemplate = () => html`
    <a id="catalogLink" href="index.html" class="active">Dashboard</a>
    <div id="user">
        <a id="createLink" href="create.html" >Create Furniture</a>
        <a id="profileLink" href="my-furniture.html" >My Publications</a>
        <a id="logoutBtn" href="javascript:void(0)">Logout</a>
    </div>`
} else {
    navigationTemplate = () => html`
    <div id="guest">
        <a id="loginLink" href="login.html">Login</a>
        <a id="registerLink" href="register.html">Register</a>
    </div>`;
}