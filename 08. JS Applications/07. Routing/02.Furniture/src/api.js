const baseUrl = 'http://localhost:3030/data/catalog';

export function getAllFurniture() {
    return fetch(baseUrl)
        .then(res => res.json());
}