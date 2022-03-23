import { html } from "../../node_modules/lit-html/lit-html.js";
import { login, save } from "../services/authService.js";

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

    login(formdata.username, formdata.password)
        .then(user => {
            save(user);
        })
}