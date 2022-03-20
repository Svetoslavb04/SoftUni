import { html } from "../../node_modules/lit-html/lit-html.js";
import { editTeam, getTeamDetails } from "../services/teamsService.js";
import page from '../../node_modules/page/page.mjs';

const editTeamTemplate = (team, ctx) => html`
    <article class="narrow">
        <header class="pad-med">
            <h1>Edit Team</h1>
        </header>
        <form id="edit-form" class="main-form pad-large" @submit=${editTeamHandler.bind(null, ctx)}>
            <label>Team name: <input type="text" name="name" value=${team.name} @change=${validateName.bind(null, null)}></label>
            <label>Logo URL: <input type="text" name="logoUrl" value=${team.logoUrl} @change=${validateLogoUrl.bind(null, null)}></label>
            <label>Description: <textarea name="description" @change=${validateDescription.bind(null, null)}>${team.description}</textarea></label>
            <input class="action cta" type="submit" value="Save Changes">
        </form>
    </article>
`;

export async function renderEditTeamView(ctx) {
    const team = await getTeamDetails(ctx.params._id);

    ctx.render(editTeamTemplate(team, ctx));
}

function editTeamHandler(ctx, e) {
    e.preventDefault();

    const formdata = new FormData(e.currentTarget);

    const name = formdata.get('name');
    const logoUrl = formdata.get('logoUrl');
    const description = formdata.get('description');

    if(!validateName(name)) return; 
    if(!validateLogoUrl(logoUrl)) return;
    if(!validateDescription(description)) return;

    editTeam(ctx.params._id, name, logoUrl, description)
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

function validateName(teamName, e) {
    if (e) {
        teamName = e.currentTarget.value;
        e.preventDefault();
    }

    document.querySelector('.invalid-name')?.remove();

    if (!teamName || teamName.length < 3) {
        
        const errorDiv = document.createElement('div');
        errorDiv.classList.add('error', 'invalid-name');
        errorDiv.textContent = 'Invalid Team Name!';

        e.currentTarget.parentNode.parentNode.prepend(errorDiv);

        return false;
    }

    return true;
}

function validateLogoUrl(logoUrl, e) {

    if (e) {
        logoUrl = e.currentTarget.value;
        e.preventDefault();
    }

    document.querySelector('.invalid-logoUrl')?.remove();

    if (!logoUrl) {
        const errorDiv = document.createElement('div');
        errorDiv.classList.add('error', 'invalid-logoUrl');
        errorDiv.textContent = 'Invalid URL!';

        e.currentTarget.parentNode.parentNode.prepend(errorDiv);

        return false;
    }

    return true;
}

function validateDescription(description, e) {

    if (e) {
        description = e.currentTarget.value;
        e.preventDefault();
    }

    document.querySelector('.invalid-description')?.remove();

    if (!description || description.length < 9) {
        
        const errorDiv = document.createElement('div');
        errorDiv.classList.add('error', 'invalid-description');
        errorDiv.textContent = 'Invalid Description!';

        e.currentTarget.parentNode.parentNode.prepend(errorDiv);

        return false;
    }

    return true;
}