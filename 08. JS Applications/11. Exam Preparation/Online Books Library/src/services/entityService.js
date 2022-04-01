import { getUser } from './authService.js'

const baseUrl = 'http://localhost:3030/data';
const entityType = 'book' + 's';

export const createEntity = (entity) => fetch(`${baseUrl}/${entityType}`, {
    method: 'POST',
    headers: {
        'Content-Type': 'application/json',
        'X-Authorization': getUser().accessToken
    },
    body: JSON.stringify(entity)
})
    .then(res => res.json())
    .catch(err => err);

export const getAll = () => fetch(`${baseUrl}/${entityType}?sortBy=_createdOn%20desc`)
    .then(res => res.json())
    .catch(err => err);

export const getAllOfUser = (_id) => fetch(`${baseUrl}/${entityType}?where=_ownerId%3D%22${_id}%22&sortBy=_createdOn%20desc`, {
    method: 'GET',
    headers: {
        'X-Authorization': getUser().accessToken
    }
})
    .then(res => res.json())
    .catch(err => err);

export const getOne = (_id) => fetch(`${baseUrl}/${entityType}/${_id}`)
    .then(res => res.json())
    .catch(err => err);

export const editEntity = (_id, entity) => fetch(`${baseUrl}/${entityType}/${_id}`, {
    method: 'PUT',
    headers: {
        'Content-Type': 'application/json',
        'X-Authorization': getUser().accessToken
    },
    body: JSON.stringify(entity)
})
    .then(res => res.json())
    .catch(err => err);

export const deleteEnitity = (_id) => fetch(`${baseUrl}/${entityType}/${_id}`, {
    method: 'DELETE',
    headers: {
        'X-Authorization': getUser().accessToken
    }
})
    .then(res => res.json())
    .catch(err => err);

export const likeEntity = (_id) => fetch(`${baseUrl}/likes`, {
    method: 'POST',
    headers: {
        'Content-Type': 'application/json',
        'X-Authorization': getUser().accessToken
    },
    body: JSON.stringify({ bookId: _id })
})
    .then(res => res.json())
    .catch(err => err);

export const totalLikesOfEntity = (_id) => fetch(`${baseUrl}/likes?where=bookId%3D%22${_id}%22&distinct=_ownerId&count`)
    .then(res => res.json())
    .catch(err => err);

export const isAEntityLikedByUser = function (entity_id, user_id) {
    return fetch(`${baseUrl}/likes?where=bookId%3D%22${entity_id}%22%20and%20_ownerId%3D%22${user_id}%22&count`, {
        method: 'GET',
        headers: {
            'X-Authorization': getUser().accessToken
        }
    })
        .then(res => res.json())
        .catch(err => err);
}
