import { html } from "../../node_modules/lit-html/lit-html.js";
import { register } from "../services/authService.js";
import page from '../../node_modules/page/page.mjs';

const registerTemplate = () => html`
    <div class="container">
        <form id="register-form" @submit=${registerHandler}>
            <h1>Register</h1>
            <p>Please fill in this form to create an account.</p>
            <hr>

            <p>Username</p>
            <input type="text" placeholder="Enter Username" name="username" required>

            <p>Password</p>
            <input type="password" placeholder="Enter Password" name="password" required>

            <p>Repeat Password</p>
            <input type="password" placeholder="Repeat Password" name="repeatPass" required>
            <hr>

            <input type="submit" class="registerbtn" value="Register">
        </form>
        <div class="signin">
            <p>Already have an account?
                <a href="/login">Sign in</a>.
            </p>
        </div>
    </div>`;

export function renderRegisterView(ctx) {
    ctx.render(registerTemplate());
}

function registerHandler(e) {
    e.preventDefault();

    const formdata = new FormData(e.currentTarget);
    
    if (formdata.get('password') != formdata.get('repeatPass')) {
        window.alert('Passwords does not match!');
        return;
    }

    register(formdata.get('username'), formdata.get('password'))
    .then(user => {
        user.message ? window.alert(user.message) : page.redirect('/listings/all');
    });
}