import { html } from "../../node_modules/lit-html/lit-html.js";
import { login } from "../services/authService.js";
import page from '../../node_modules/page/page.mjs';

const loginTemplate = () => html`
    <section id="login-page" class="auth">
        <form id="login" @submit=${loginHandler}>

            <div class="container">
                <div class="brand-logo"></div>
                <h1>Login</h1>
                <label for="email">Email:</label>
                <input type="email" id="email" name="email" placeholder="email">

                <label for="login-pass">Password:</label>
                <input type="password" id="login-password" name="password" placeholder="password">
                <input type="submit" class="btn submit" value="Login">
                <p class="field">
                    <span>If you don't have profile click <a href="/register">here</a></span>
                </p>
            </div>
        </form>
    </section>`;

export function renderLoginView(ctx) {
    ctx.render(loginTemplate());
}

function loginHandler(e) {
    e.preventDefault();

    const formdata = new FormData(e.currentTarget);
    
    login(formdata.get('email'), formdata.get('password'))
        .then(user => {
            user.message ? window.alert(user.message) : page.redirect('/');
        });
}