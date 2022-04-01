import { html } from "../node_modules/lit-html/lit-html.js";
import { login } from "../services/authService.js";

const loginTemplate = (ctx) => html`
    <section id="login-page" class="login">
        <form id="login-form" @submit=${loginHandler.bind(null, ctx)}>
            <fieldset>
                <legend>Login Form</legend>
                <p class="field">
                    <label for="email">Email</label>
                    <span class="input">
                        <input type="text" name="email" id="email" placeholder="Email" required>
                    </span>
                </p>
                <p class="field">
                    <label for="password">Password</label>
                    <span class="input">
                        <input type="password" name="password" id="password" placeholder="Password" required>
                    </span>
                </p>
                <input class="button submit" type="submit" value="Login">
            </fieldset>
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