import { html } from "../../node_modules/lit-html/lit-html.js";
import { login } from "../services/authService.js";
import page from '../../node_modules/page/page.mjs';

const loginTemplate = () => html`
    <div class="container">
        <form id="login-form" @submit=${loginHandler}>
            <h1>Login</h1>
            <p>Please enter your credentials.</p>
            <hr>
            <p>Username</p>
            <input placeholder="Enter Username" name="username" type="text">
            <p>Password</p>
            <input type="password" placeholder="Enter Password" name="password">
            <input type="submit" class="registerbtn" value="Login">
        </form>
        <div class="signin">
            <p>Dont have an account?
                <a href="/register">Sign up</a>.
            </p>
        </div>
    </div>`;

export function renderLoginView(ctx) {
    ctx.render(loginTemplate());
}

function loginHandler(e) {
    e.preventDefault();

    const formdata = new FormData(e.currentTarget);
    
    login(formdata.get('username'), formdata.get('password'))
        .then(user => {
            user.message ? window.alert(user.message) : page.redirect('/listings/all');
        });
}