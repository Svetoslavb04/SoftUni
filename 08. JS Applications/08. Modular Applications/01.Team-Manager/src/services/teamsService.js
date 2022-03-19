import { getUser } from "./authService.js";


const baseUrl = 'http://localhost:3030';;
const teamsUrl = baseUrl + '/data/teams';
const membersUrl = baseUrl + '/data/members';

export const getAll = () => fetch(teamsUrl).then(res => res.json());

export const getMembers = (_id) => {
    const queryString = encodeURIComponent(`teamId IN ("${_id}") AND status="member"`);

    return fetch(`${membersUrl}?where=${queryString}`)
        .then(res => res.json());
}

export const createTeam = async (name, logoUrl, description) => {
    const user = getUser();
    try {
        const createTeamResponse = await fetch(teamsUrl, {
            method: 'POST',
            headers: {
                'Content-Type': 'application/json',
                'X-Authorization': user.accessToken
            },
            body: JSON.stringify({
                _ownerId: user._id,
                name,
                logoUrl,
                description,
            })
        })
        const teamData = await createTeamResponse.json();
    
        const OwnerRequestForMembershipResponse = await fetch(membersUrl, {
                method: 'POST',
                headers: {
                    'Content-Type': 'application/json',
                    'X-Authorization': user.accessToken
                },
                body: JSON.stringify({
                    teamId: teamData._id
                })
            });
    
        const membershipRequestData = await OwnerRequestForMembershipResponse.json();
    
        const OwnerApprovalResponse = await fetch(`${membersUrl}/${membershipRequestData._id}`, {
            method: 'PUT',
            headers: {
                'Content-Type': 'application/json',
                'X-Authorization': user.accessToken
            },
            body: JSON.stringify({
                status: "member"
            })
        });

        return teamData;
    } catch (error) {
        return error;
    }
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