import { getTeamDetails, getMembersAndPendingMembers, removeMember, approveMember, requestToBecomeMember, getMembers } from "../services/teamsService.js";
import { html } from "../../node_modules/lit-html/lit-html.js";
import { getUser, isAuthenticated } from "../services/authService.js";

const guestDetailsTemplate = (team) => html`
    <article class="layout">
        <img src="${team.logoUrl}" class="team-logo left-col">
        <div class="tm-preview">
            <h2>${team.name}</h2>
            <p>${team.description}</p>
            <span class="details">${team.members.length} Members</span>
        </div>
        <div class="pad-large">
            <h3>Members</h3>
            <ul class="tm-members">
                ${team.members.map(m => html`<li>${m.user.username}</li>`)}
            </ul>
        </div>
    </article>`;
    
const ownerDetailsTemplate = (team, ctx) => html` 
    <article class="layout">
        <img src="${team.logoUrl}" class="team-logo left-col">
        <div class="tm-preview">
            <h2>${team.name}</h2>
            <p>${team.description}</p>
            <span class="details" id="membersCount">${team.members.length} Members</span>
            <div>
                <a href="/edit/${team._id}" class="action">Edit team</a>
            </div>
        </div>
        <div class="pad-large">
            <h3>Members</h3>
            <ul class="tm-members">
            ${team.members.map(m => {
                if (m.user._id == getUser()._id) {
                    return html`<li>${m.user.username}</li>`
                } else {
                    return html`<li>${m.user.username}<a class="tm-control action" @click=${removeFromTeamHandler.bind(null, m._id, ctx)}>Remove from team</a></li>`
                }
            })}
            </ul>
        </div>
        <div class="pad-large">
            <h3>Membership Requests</h3>
            <ul class="tm-members">
                ${
                    team.pendingMembers.map(p => html`
                    <li>${p.user.username}
                        <a class="tm-control action"  @click=${approveRequestHandler.bind(null, p._id, ctx)}>Approve</a>
                        <a class="tm-control action" @click=${declineRequestHandler.bind(null, p._id, ctx)}>Decline</a>
                    </li>`)
                }
            </ul>
        </div>
    </article>
`;

const nonOwnerDetailsTemplate = (team, ctx) => html`
    <article class="layout">
        <img src="${team.logoUrl}" class="team-logo left-col">
        <div class="tm-preview">
            <h2>${team.name}</h2>
            <p>${team.description}</p>
            <span class="details">${team.members.length} Members</span>
        </div>
        <div>
        ${team.members.some(m => m._ownerId == getUser()._id) ?
            html`<a class="action invert" @click=${leaveTeamOrCancelRequestHandler.bind(null, team.members.filter(m => m._ownerId == getUser()._id)[0]._id, ctx)}>Leave team</a>` :
                (team.pendingMembers
                    .some(p => p._ownerId == getUser()._id) ? 
                        html`Membership pending. <a @click=${leaveTeamOrCancelRequestHandler.bind(null, team.pendingMembers.filter(p => p._ownerId == getUser()._id)[0]._id, ctx)}>Cancel request</a>` :
                            html`<a class="action" @click=${joinTeamHandler.bind(null, team._id, ctx)}>Join team</a>`
                )
        }
        </div>
        <div class="pad-large">
            <h3>Members</h3>
            <ul class="tm-members">
                ${team.members.map(m => html`<li>${m.user.username}</li>`)}
            </ul>
        </div>
    </article>`;

export async function renderTeamDetails(ctx) {
    const team = await getTeamDetails(ctx.params._id);

    const membersAndPending = await getMembersAndPendingMembers(ctx.params._id);

    team.members = membersAndPending.filter(mp => mp.status == 'member');
    team.pendingMembers = membersAndPending.filter(mp => mp.status == 'pending');

    if (!isAuthenticated()) {
        ctx.render(guestDetailsTemplate(team));
    } else {
        const user = getUser();

        if (user._id == team._ownerId) {
            ctx.render(ownerDetailsTemplate(team, ctx));
        } else {
            ctx.render(nonOwnerDetailsTemplate(team, ctx));
        }
    }
}

async function removeFromTeamHandler(_id, ctx, e) {
    e.preventDefault();

    await removeMember(_id);

    const team = await getTeamDetails(ctx.params._id);

    const membersAndPending = await getMembersAndPendingMembers(ctx.params._id);

    team.members = membersAndPending.filter(mp => mp.status == 'member');
    team.pendingMembers = membersAndPending.filter(mp => mp.status == 'pending');

    ctx.render(ownerDetailsTemplate(team, ctx));
}

async function declineRequestHandler(_id, ctx, e) {
    e.preventDefault();

    await removeMember(_id);

    const team = await getTeamDetails(ctx.params._id);

    const membersAndPending = await getMembersAndPendingMembers(ctx.params._id);

    team.members = membersAndPending.filter(mp => mp.status == 'member');
    team.pendingMembers = membersAndPending.filter(mp => mp.status == 'pending');

    ctx.render(ownerDetailsTemplate(team, ctx));
}

async function approveRequestHandler(_id, ctx, e) {
    e.preventDefault();

    await approveMember(_id);

    const team = await getTeamDetails(ctx.params._id);

    const membersAndPending = await getMembersAndPendingMembers(ctx.params._id);

    team.members = membersAndPending.filter(mp => mp.status == 'member');
    team.pendingMembers = membersAndPending.filter(mp => mp.status == 'pending');

    ctx.render(ownerDetailsTemplate(team, ctx));
}

async function joinTeamHandler(teamId, ctx, e) {
    e.preventDefault();

    await requestToBecomeMember(teamId);

    const team = await getTeamDetails(ctx.params._id);

    const membersAndPending = await getMembersAndPendingMembers(ctx.params._id);

    team.members = membersAndPending.filter(mp => mp.status == 'member');
    team.pendingMembers = membersAndPending.filter(mp => mp.status == 'pending');

    ctx.render(nonOwnerDetailsTemplate(team, ctx));
}

async function leaveTeamOrCancelRequestHandler(memberId, ctx, e) {
    e.preventDefault();

    await removeMember(memberId);

    const team = await getTeamDetails(ctx.params._id);

    const membersAndPending = await getMembersAndPendingMembers(ctx.params._id);

    team.members = membersAndPending.filter(mp => mp.status == 'member');
    team.pendingMembers = membersAndPending.filter(mp => mp.status == 'pending');

    ctx.render(nonOwnerDetailsTemplate(team, ctx));
}