import { html } from "../../node_modules/lit-html/lit-html.js";
import { register } from "../services/authService.js";
import page from '../../node_modules/page/page.mjs';

const registerTemplate = () => html`
    <section id="register-page" class="content auth">
        <form id="register" @submit=${registerHandler}>
            <div class="container">
                <div class="brand-logo"></div>
                <h1>Register</h1>

                <label for="email">Email:</label>
                <input type="email" id="email" name="email" placeholder="email">

                <label for="pass">Password:</label>
                <input type="password" name="password" id="register-password">

                <label for="con-pass">Confirm Password:</label>
                <input type="password" name="confirm-password" id="confirm-password">

                <input class="btn submit" type="submit" value="Register">

                <p class="field">
                    <span>If you already have profile click <a href="/login">here</a></span>
                </p>
            </div>
        </form>
    </section>`;

export function renderRegisterView(ctx) {
    ctx.render(registerTemplate());
}

function registerHandler(e) {
    e.preventDefault();

    const formdata = new FormData(e.currentTarget);
    
    if (formdata.get('password') != formdata.get('confirm-password')) {
        window.alert('Passwords does not match!');
        return;
    }

    register(formdata.get('email'), formdata.get('password'))
    .then(user => {
        user.message ? window.alert(user.message) : page.redirect('/');
    });
}