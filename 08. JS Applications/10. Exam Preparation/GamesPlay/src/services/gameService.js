import { getUser } from "./authService.js";

const baseUrl = 'http://localhost:3030/data/games';

export const getLatestGames = () => fetch(`${baseUrl}?sortBy=_createdOn%20desc&distinct=category`).then(res => res.json());

export const getAllGames = () => fetch(`${baseUrl}`).then(res => res.json());

export const createGame = (game) => {
    return fetch(baseUrl, {
        method: 'POST',
        headers: {
            'Content-Type': 'application/json',
            'X-Authorization': getUser().accessToken
        },
        body: JSON.stringify(game)
    })
    .then(res => res.json())
}