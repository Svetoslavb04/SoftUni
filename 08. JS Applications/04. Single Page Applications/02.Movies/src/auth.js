export let email = sessionStorage.getItem('email');
export let username = sessionStorage.getItem('username');
export let _id = sessionStorage.getItem('_id');
export let authToken = sessionStorage.getItem('authToken');

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

export function updateSession(email, username, _id, authToken) {
    sessionStorage.setItem('email', email);
    sessionStorage.setItem('username', username);
    sessionStorage.setItem('_id', _id);
    sessionStorage.setItem('authToken', authToken);

    updateAuth();
}

export function clearSession() {
    sessionStorage.clear();

    email = null;
    username = null;
    _id = null;
    authToken = null;

    updateAuth();
}