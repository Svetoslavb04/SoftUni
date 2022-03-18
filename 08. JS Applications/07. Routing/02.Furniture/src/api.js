import { user } from './auth.js';

const baseUrl = 'http://localhost:3030';
const dataUrl = baseUrl + '/data/catalog';

export function getAllFurniture() {
    return fetch(dataUrl)
        .then(res => res.json())
        .catch(err => alert(err.message));
}

export function getFurnitureByUser(user_id) {
    return fetch(`${dataUrl}?where=_ownerId%3D%22${user_id}%22`)
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
    return fetch(`${dataUrl}/${_id}`, {
        method: 'DELETE',
        headers: {
            'X-Authorization': user.accessToken
        }
    })
    .then(res => res.json())
    .catch(err => alert(err.message));
}

export function editFurniture(furniture) {
    const _ownerId = furniture._ownerId;
    const make = furniture.make;
    const model = furniture.model;
    const year = furniture.year;
    const description = furniture.description;
    const price = furniture.price;
    const img = furniture.img;
    const material = furniture.material;
    const _id = furniture._id;

    return fetch(`${dataUrl}/${_id}`, {
        method: 'PUT',
        headers: {
            'Content-type': 'application/json',
            'X-Authorization': user.accessToken
        },
        body: JSON.stringify({
            _ownerId,
            make,
            model,
            year: Number(year),
            description,
            price: Number(price),
            img,
            material,
            _id
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

export function createFurniture(furniture) {
    const _ownerId = furniture._ownerId;
    const make = furniture.make;
    const model = furniture.model;
    const year = furniture.year;
    const description = furniture.description;
    const price = furniture.price;
    const img = furniture.img;
    const material = furniture.material;

    return fetch(`${dataUrl}`, {
        method: 'POST',
        headers: {
            'Content-type': 'application/json',
            'X-Authorization': user.accessToken
        },
        body: JSON.stringify({
            _ownerId,
            make,
            model,
            year: Number(year),
            description,
            price: Number(price),
            img,
            material
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