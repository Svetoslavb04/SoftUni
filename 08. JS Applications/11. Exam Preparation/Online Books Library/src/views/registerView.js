import { html } from "../node_modules/lit-html/lit-html.js";
import { register } from "../services/authService.js";

const registerTemplate = (ctx) => html`
    <section id="register-page" class="register">
        <form id="register-form" @submit=${registerHandler.bind(null, ctx)}>
            <fieldset>
                <legend>Register Form</legend>
                <p class="field">
                    <label for="email">Email</label>
                    <span class="input">
                        <input type="text" name="email" id="email" placeholder="Email">
                    </span>
                </p>
                <p class="field">
                    <label for="password">Password</label>
                    <span class="input">
                        <input type="password" name="password" id="password" placeholder="Password">
                    </span>
                </p>
                <p class="field">
                    <label for="repeat-pass">Repeat Password</label>
                    <span class="input">
                        <input type="password" name="confirm-pass" id="repeat-pass" placeholder="Repeat Password">
                    </span>
                </p>
                <input class="button submit" type="submit" value="Register">
            </fieldset>
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
    const confirmPass = formdata.get('confirm-pass');

    if (!email || !password || !confirmPass) {
        window.alert('All fields are required!');

        return;
    }
    if (password !== confirmPass) {
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