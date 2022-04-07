import { html } from "../../node_modules/lit-html/lit-html.js";
import { login } from "../services/authService.js";

const loginTemplate = (ctx) => html`
    <section id="loginPage">
        <form class="loginForm" @submit=${loginHandler.bind(null, ctx)}>
            <img src="./images/logo.png" alt="logo" />
            <h2>Login</h2>

            <div>
                <label for="email">Email:</label>
                <input id="email" name="email" type="text" placeholder="your@email.here" value="">
            </div>

            <div>
                <label for="password">Password:</label>
                <input id="password" name="password" type="password" placeholder="********" value="">
            </div>

            <button class="btn" type="submit">Login</button>

            <p class="field">
                <span>If you don't have profile click <a href="/register">here</a></span>
            </p>
        </form>
    </section>`;

export function renderLoginView(ctx) {
    ctx.render(loginTemplate(ctx));
}

function loginHandler(ctx, e) {
    e.preventDefault();

    const formdata = new FormData(e.currentTarget);

    const email = formdata.get('email');
    const password = formdata.get('password');

    if (!email || !password) {
        return window.alert('All fields are required!');
    }

    login(email, password)
        .then(data => {
            if (data.message) {
                window.alert(data.message);
            }
            else {
                ctx.page.redirect('/');
            }
        })
}