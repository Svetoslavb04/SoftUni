import { html } from '../../node_modules/lit-html/lit-html.js';
import { getAll, getMembers } from "../services/teamsService.js";

const browseTeamsTemplate = (ctx, teams) => html`
    <article class="pad-med">
        <h1>Team Browser</h1>
    </article>

    ${ctx.isAuthenticated ? 
        html`
        <article class="layout narrow">
            <div class="pad-small"><a href="/create" class="action cta">Create Team</a></div>
        </article>` : ''
    }

    ${
        teams.map(t => html`
                    <article class="layout" _id=${t._id}>
                        <img src=".${t.logoUrl}" class="team-logo left-col">
                        <div class="tm-preview">
                            <h2>${t.name}</h2>
                            <p>${t.description}</p>
                            <span class="details">${t.members.length}</span>
                            <div><a href="/team/${t._id}" class="action">See details</a></div>
                        </div>
                    </article>`)
    }`;

export async function renderBrowseTeamsView(ctx) {
    const teams = await getAll();

    for (const team of teams) {
        const members = await getMembers(team._id);

        team.members = members;
    }
    
    ctx.render(browseTeamsTemplate(ctx, teams));
}