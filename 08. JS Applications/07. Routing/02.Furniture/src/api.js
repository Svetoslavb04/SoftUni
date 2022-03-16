import { user } from './auth.js';

const baseUrl = 'http://localhost:3030';
const dataUrl = baseUrl + '/data/catalog';

export function getAllFurniture() {
    return fetch(dataUrl)
        .then(res => res.json())
        .catch(err => alert(err.message));
}

export function getFurnitureDetails(_id) {
    return fetch(`${dataUrl}/${_id}`)
        .then(res => res.json())
        .catch(err => alert(err.message));
}

export function login(email, password) {
    return fetch(`${baseUrl}/users/login`, {
        method: 'POST',
        headers: { 'Content-Type': 'application/json' },
        body: JSON.stringify({
            email,
            password
        })
    })
        .then(res => {
            if (res.status != 200) {
                res.json()
                    .then(data => { throw new Error(data.message); })
                    .catch(err => {
                        alert(err.message);
                    });
            }
            else {
                return res.json();
            }
        });
}

export function register(email, password) {
    return fetch(`${baseUrl}/users/register`, {
        method: 'POST',
        headers: { 'Content-Type': 'application/json' },
        body: JSON.stringify({
            email,
            password
        })
    })
        .then(res => {
            if (res.status != 200) {
                res.json()
                    .then(data => { throw new Error(data.message); })
                    .catch(err => {
                        alert(err.message);
                    });
            }
            else {
                return res.json();
            }
        });
}

export function deleteFurnitureEntity(_id) {
    fetch(`${dataUrl}/${_id}`, {
        method: 'DELETE',
        headers: {
            'X-Authorization': user.accessToken
        }
    })
    .catch(err => alert(err.message));
}