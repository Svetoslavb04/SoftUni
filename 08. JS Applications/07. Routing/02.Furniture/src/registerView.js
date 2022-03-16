import { html, render } from '../node_modules/lit-html/lit-html.js';
import { navigationTemplate } from './navigationTemplate.js';
import { register } from './api.js';
import { updateAuth } from './auth.js';
import page from '../node_modules/page/page.mjs';


const registerTemplate = () => html`
    ${html`${navigationTemplate()}`}
    <div class="container">
        <div class="row space-top">
            <div class="col-md-12">
                <h1>Register New User</h1>
                <p>Please fill all fields.</p>
            </div>
        </div>
        <form @submit=${registerHandler}>
            <div class="row space-top">
                <div class="col-md-4">
                    <div class="form-group">
                        <label class="form-control-label" for="email">Email</label>
                        <input class="form-control" id="email" type="text" name="email">
                    </div>
                    <div class="form-group">
                        <label class="form-control-label" for="password">Password</label>
                        <input class="form-control" id="password" type="password" name="password">
                    </div>
                    <div class="form-group">
                        <label class="form-control-label" for="rePass">Repeat</label>
                        <input class="form-control" id="rePass" type="password" name="rePass">
                    </div>
                    <input type="submit" class="btn btn-primary" value="Register" />
                </div>
            </div>
        </form>
    </div>`;

export function renderRegisterView() {
    render(registerTemplate(), document.getElementById('root'));
}

function registerHandler(e) {
    e.preventDefault();

    const formdata = new FormData(e.currentTarget);

    const email = formdata.get('email');
    const password = formdata.get('password');
    const rePass = formdata.get('rePass');

    if (!email || !password) {
        alert('Required email and password');
        return;
    }

    if (rePass != password) {
        alert('Password does not match');
        return;
    }

    register(email, password)
        .then(data => {
            if (data) {
                updateAuth({
                    'email': data.email,
                    'username': data.username,
                    '_id': data._id,
                    'accessToken': data.accessToken
                });

                page.redirect('/');
            }
        });
}