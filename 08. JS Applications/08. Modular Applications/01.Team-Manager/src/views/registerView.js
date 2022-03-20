import { html } from '../../node_modules/lit-html/lit-html.js';
import { register } from '../services/authService.js';
import page from "../../node_modules/page/page.mjs";
import { popNotification } from '../services/notificationService.js';

const registerTemplate = () => html`
    <article class="narrow">
        <header class="pad-med">
            <h1>Register</h1>
        </header>
        <form id="register-form" class="main-form pad-large" @submit=${registerHandler}>
            
            <label>E-mail: <input type="text" name="email"></label>
            <label>Username: <input type="text" name="username"></label>
            <label>Password: <input type="password" name="password"></label>
            <label>Repeat: <input type="password" name="repass"></label>
            <input class="action cta" type="submit" value="Create Account">
        </form>
        <footer class="pad-small">Already have an account? <a href="/login" class="invert">Sign in here</a>
        </footer>
    </article>`;

export function renderRegisterView(ctx) {
    ctx.render(registerTemplate());
}

function registerHandler(e) {
    e.preventDefault();

    e.currentTarget.querySelector('div')?.remove();
    const formData = new FormData(e.currentTarget);

    const email = formData.get('email');
    const username = formData.get('username');
    const password = formData.get('password');
    const rePass = formData.get('repass');

    if (!email || !validateEmail(email)) {

        const errorDiv = document.createElement('div');
        errorDiv.classList.add('error');
        errorDiv.textContent = 'Invalid Email!';

        e.currentTarget.prepend(errorDiv);

        return;
    }

    if (!username || username.length < 2) {

        const errorDiv = document.createElement('div');
        errorDiv.classList.add('error');
        errorDiv.textContent = 'Invalid Username!';

        e.currentTarget.prepend(errorDiv);

        return;
    }

    if (!password || password.length < 2) {

        const errorDiv = document.createElement('div');
        errorDiv.classList.add('error');
        errorDiv.textContent = 'Invalid Password!';

        e.currentTarget.prepend(errorDiv);

        return;
    }

    if (password != rePass) {
        popNotification('Passwords does not match', (e) => {
            e.preventDefault();

            let messageParagraph = e.currentTarget.parentNode.querySelector('p');
            messageParagraph.textContent = '';
            
            let notification = e.currentTarget.parentNode.parentNode;
            notification.style.display = 'none';
        });

        return;
    }

    register(email, username, password)
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

function validateEmail(input) {

    var validRegex = /^[a-zA-Z0-9.!#$%&'*+/=?^_`{|}~-]+@[a-zA-Z0-9-]+(?:\.[a-zA-Z0-9-]+)*$/;

    if (validRegex.test(input)) return true;
    else return false;
}