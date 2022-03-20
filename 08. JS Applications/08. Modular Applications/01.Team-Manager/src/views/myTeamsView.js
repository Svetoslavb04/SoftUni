import { html } from "../../node_modules/lit-html/lit-html.js";
import { getUser } from "../services/authService.js";
import { getTeamsOfUser, getMembers } from "../services/teamsService.js";

const myTeamsTemplate = (teams) => html`
    <article class="pad-med">
        <h1>My Teams</h1>
    </article>

    ${
        teams.length > 0 ? teams.map(t => html`
            <article class="layout">
                <img src=${t.logoUrl} class="team-logo left-col">
                <div class="tm-preview">
                    <h2>${t.name}</h2>
                    <p>${t.description}</p>
                    <span class="details">${t.members.length} Members</span>
                    <div><a href=${`/team/${t._id}`} class="action">See details</a></div>
                </div>
            </article>`) 
        : html`
        <article class="layout narrow">
            <div class="pad-med">
                <p>You are not a member of any team yet.</p>
                <p><a href="/browse">Browse all teams</a> to join one, or use the button bellow to cerate your own team.</p>
            </div>
            <div class=""><a href="/create" class="action cta">Create Team</a></div>
        </article>`
    }`;

export async function renderMyTeamsView(ctx) {
    const teams = await getTeamsOfUser(getUser()._id);

    for (let team of teams) {
        let members = await getMembers(team._id);

        team.members = members;
    }
    
    ctx.render(myTeamsTemplate(teams));
}