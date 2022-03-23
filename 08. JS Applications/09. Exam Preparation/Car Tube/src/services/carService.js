import { getUser } from './authService.js';

const baseUrl = 'http://localhost:3030/data';

export const getAllCars = () => {
    return fetch(`${baseUrl}/cars?sortBy=_createdOn%20desc`)
        .then(res => res.json());
}

export const createCar = (brand, model, description, year, imageUrl, price) => {
    return fetch(`${baseUrl}/cars`, {
        method: 'post',
        headers: {
            'content-type': 'application/json',
            'X-Authorization': getUser().accessToken
        },
        body: JSON.stringify({
            brand,
            model,
            description,
            year,
            imageUrl,
            price
          })
    })
    .then(res => res.json())
    .catch(err => err);
}

export const getCar = (_id) => {
    return fetch(`${baseUrl}/cars/${_id}`)
        .then(res => res.json())
        .catch(err => err);
}

export const editCar = (_id, newCar) => {
    return fetch(`${baseUrl}/cars/${_id}`, {
        method: 'PUT',
        headers: {
            'Content-Type': 'application/json',
            'X-Authorization': getUser().accessToken
        },
        body: JSON.stringify(newCar)
    })
    .then(res => res.json())
    .catch(err => err);
}

export const deleteCar = (_id) => {
    return fetch(`${baseUrl}/cars/${_id}`, {
        method: 'DELETE',
        headers: {
            'X-Authorization': getUser().accessToken
        },
    })
    .then(res => res.json())
    .catch(err => err);
}

export const getCarsByUser = (_id) => {
    return fetch(`${baseUrl}/cars?where=_ownerId%3D%22${_id}%22&sortBy=_createdOn%20desc`,{
        method: 'GET',
        headers: {
            'X-Authorization': getUser().accessToken
        }
    })
    .then(res => res.json())
    .catch(err => err);
}

export const getCarsByYear = (year) => {
    return fetch(`${baseUrl}/cars?where=year%3D${year}`,{
        method: 'GET',
        headers: {
            'X-Authorization': getUser().accessToken
        }
    })
    .then(res => res.json())
    .catch(err => err);
}