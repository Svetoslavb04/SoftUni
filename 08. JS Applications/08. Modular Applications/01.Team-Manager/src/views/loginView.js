import { html } from '../../node_modules/lit-html/lit-html.js';
import { login } from '../services/authService.js';
import page from "../../node_modules/page/page.mjs";
import { popNotification } from '../services/notificationService.js';

const loginTemplate = () => html`
    <article class="narrow">
        <header class="pad-med">
            <h1>Login</h1>
        </header>
        <form id="login-form" class="main-form pad-large" @submit=${loginHandler}>
            <label>E-mail: <input type="text" name="email"></label>
            <label>Password: <input type="password" name="password"></label>
            <input class="action cta" type="submit" value="Sign In">
        </form>
        <footer class="pad-small">Don't have an account? <a href="/register" class="invert">Sign up here</a>
        </footer>
    </article>`;

export function renderLoginView(ctx) {
    ctx.render(loginTemplate());
}

function loginHandler(e) {
    e.preventDefault();

    const formData = new FormData(e.currentTarget);

    const email = formData.get('email');
    const password = formData.get('password');

    login(email, password)
        .then(data => {
            if (!data.message) {
                page.redirect('/my-teams');
            } else {
                popNotification(data.message, (e) => {
                    e.preventDefault();

                    let messageParagraph = e.currentTarget.parentNode.querySelector('p');
                    messageParagraph.textContent = '';

                    let notification = e.currentTarget.parentNode.parentNode;
                    notification.style.display = 'none';
                });
            }
        });
}