export let email = sessionStorage.getItem('email');
export let username = sessionStorage.getItem('username');
export let _id = sessionStorage.getItem('_id');
let authToken = sessionStorage.getItem('authToken');

export let isAuthenticated;

export function updateAuth() {
    email = sessionStorage.getItem('email');
    username = sessionStorage.getItem('username');
    _id = sessionStorage.getItem('_id');
    authToken = sessionStorage.getItem('authToken');

    if (authToken) {
        isAuthenticated = true;
    } else {
        isAuthenticated = false;

        username = 'guest';
    }
}