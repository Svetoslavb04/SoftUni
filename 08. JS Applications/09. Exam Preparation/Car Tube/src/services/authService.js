export let isAuthenticated;

export const baseUrl = 'http://localhost:3030/users';

export const getUser = () => JSON.parse(sessionStorage.getItem('user'));

export function save(user) {
    sessionStorage.setItem('user', user);

    if (user.accessToken) {
        isAuthenticated = true;
    }
}

export function login(username, password) {
    return fetch(`${baseUrl}/login`, {
        method: 'POST',
        headers: {
            'Content-Type': 'application/json'
        },
        body: JSON.stringify({
            username,
            password
        })
    })
    .then(res => res.json);
}