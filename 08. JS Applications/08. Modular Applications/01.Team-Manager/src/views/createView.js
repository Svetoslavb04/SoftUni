import { html } from "../../node_modules/lit-html/lit-html.js";
import { popNotification } from "../services/notificationService.js";
import { createTeam } from "../services/teamsService.js";
import page from "../../node_modules/page/page.mjs";


const createTeamTemplate = () => html`
    <article class="narrow">
        <header class="pad-med">
            <h1>New Team</h1>
        </header>
        <form id="create-form" class="main-form pad-large" @submit=${createTeamHandler}>
            <label>Team name: <input type="text" name="name"></label>
            <label>Logo URL: <input type="text" name="logoUrl"></label>
            <label>Description: <textarea name="description"></textarea></label>
            <input class="action cta" type="submit" value="Create Team">
        </form>
    </article>`;

export function renderCreateView(ctx) {
    ctx.render(createTeamTemplate());
}

function createTeamHandler(e) {
    e.preventDefault();

    e.currentTarget.querySelector('div')?.remove();

    const formdata = new FormData(e.currentTarget);

    let teamName = formdata.get('name');
    let logoUrl = formdata.get('logoUrl');
    let description = formdata.get('description');

    if (!teamName || teamName.length < 3) {
        
        const errorDiv = document.createElement('div');
        errorDiv.classList.add('error');
        errorDiv.textContent = 'Invalid Team Name!';

        e.currentTarget.prepend(errorDiv);

        return;
    }

    if (!logoUrl) {
        
        const errorDiv = document.createElement('div');
        errorDiv.classList.add('error');
        errorDiv.textContent = 'Invalid URL!';

        e.currentTarget.prepend(errorDiv);

        return;
    }

    if (!description || description.length < 9) {
        
        const errorDiv = document.createElement('div');
        errorDiv.classList.add('error');
        errorDiv.textContent = 'Invalid description!';

        e.currentTarget.prepend(errorDiv);

        return;
    }

    createTeam(teamName, logoUrl, description)
        .then(data => {
            if (!data.message) {
                page.redirect(`/team/${data._id}`);
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