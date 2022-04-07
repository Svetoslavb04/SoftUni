import { html } from "../../node_modules/lit-html/lit-html.js";
import { register } from "../services/authService.js";

const registerTemplate = (ctx) => html`
    <section id="registerPage">
        <form class="registerForm" @submit=${registerHandler.bind(null, ctx)}>
            <img src="./images/logo.png" alt="logo" />
            <h2>Register</h2>
            <div class="on-dark">
                <label for="email">Email:</label>
                <input id="email" name="email" type="text" placeholder="your@email.here" value="">
            </div>

            <div class="on-dark">
                <label for="password">Password:</label>
                <input id="password" name="password" type="password" placeholder="********" value="">
            </div>

            <div class="on-dark">
                <label for="repeatPassword">Repeat Password:</label>
                <input id="repeatPassword" name="repeatPassword" type="password" placeholder="********" value="">
            </div>

            <button class="btn" type="submit">Register</button>

            <p class="field">
                <span>If you have profile click <a href="/login">here</a></span>
            </p>
        </form>
    </section>`;

export function renderRegisterView(ctx) {
    ctx.render(registerTemplate(ctx));
}

function registerHandler(ctx, e) {
    e.preventDefault();

    const formdata = new FormData(e.currentTarget);

    const email = formdata.get('email');
    const password = formdata.get('password');
    const repeatPassword = formdata.get('repeatPassword');

    if (!email || !password || !repeatPassword) {
        window.alert('All fields are required!');

        return;
    }
    if (password !== repeatPassword) {
        window.alert('Password does not match!');

        return;
    }

    register(email, password)
        .then(data => {
            if (data.message) {
                window.alert(data.message);
            }
            else {
                ctx.page.redirect('/');
            }
        })
}