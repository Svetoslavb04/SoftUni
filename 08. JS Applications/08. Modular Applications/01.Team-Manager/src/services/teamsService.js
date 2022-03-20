import { getUser } from "./authService.js";


const baseUrl = 'http://localhost:3030';;
const teamsUrl = baseUrl + '/data/teams';
const membersUrl = baseUrl + '/data/members';

export const getAll = () => fetch(teamsUrl).then(res => res.json());

export const getMembers = (teamid) => {
    const queryString = encodeURIComponent(`teamId IN ("${teamid}") AND status="member"`);

    return fetch(`${membersUrl}?where=${queryString}`)
        .then(res => res.json());
}

export const getMembersAndPendingMembers = (teamid) => {
    return fetch(`${membersUrl}?where=teamId%3D%22${teamid}%22&load=user%3D_ownerId%3Ausers`)
        .then(res => res.json());
}

export const createTeam = async (name, logoUrl, description) => {

    try {
        const createTeamResponse = await fetch(teamsUrl, {
            method: 'POST',
            headers: {
                'Content-Type': 'application/json',
                'X-Authorization': user.accessToken
            },
            body: JSON.stringify({
                _ownerId: getUser()._id,
                name,
                logoUrl,
                description,
            })
        })
        const teamData = await createTeamResponse.json();

        const membershipRequestData = await requestToBecomeMember(teamData._id);
    
        await approveMember(membershipRequestData._id);

        return teamData;
    } catch (error) {
        return error;
    }
}

export const requestToBecomeMember = (teamId) => {
    return fetch(membersUrl, {
        method: 'POST',
        headers: {
            'Content-Type': 'application/json',
            'X-Authorization': getUser().accessToken
        },
        body: JSON.stringify({
            teamId
        })
    })
    .then(res => res.json());
}

export const approveMember = (memberId) => {
    return fetch(`${membersUrl}/${memberId}`, {
        method: 'PUT',
        headers: {
            'Content-Type': 'application/json',
            'X-Authorization': getUser().accessToken
        },
        body: JSON.stringify({
            status: "member"
        })
    })
    .then(res => res.json());
}

export const removeMember = (memberId) => {
    return fetch(`${membersUrl}/${memberId}`, {
        method: 'DELETE',
        headers: {
            'Content-Type': 'application/json',
            'X-Authorization': getUser().accessToken
        }
    })
    .then(res => res.json());
}

export const getTeamDetails = (_id) => {
    return fetch(`${teamsUrl}/${_id}`)
        .then(res => res.json())
        .then(data => {
            if (data.message) throw new Error(data.message);
            else return data;
        })
        .catch(err => err);
}

export const getTeamsOfUser = async (user_id) => {
    let teams = [];

    const data = await (await fetch(`${membersUrl}?where=_ownerId%3D%22${user_id}%22%20AND%20status%3D%22member%22&load=team%3DteamId%3Ateams`))
        .json();

    teams = data.reduce((array, currentObj) => {
        array.push(currentObj.team);
        return array;
    }, []);

    return teams;
}

export const editTeam = (teamId, name, logoUrl, description) => {
    return fetch(`${teamsUrl}/${teamId}`, {
            method: 'PUT',
            headers: {
                'Content-Type': 'application/json',
                'X-Authorization': getUser().accessToken
            },
            body: JSON.stringify({
                name,
                logoUrl,
                description
            })
        })
            .then(res => res.json())
            .then(data => {
                if (data.message) throw new Error(data.message);
                else return data;
            })
            .catch(err => err);
}