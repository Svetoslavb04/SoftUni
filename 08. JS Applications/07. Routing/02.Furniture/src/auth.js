import { logoutUser } from "./api.js";
export let user = JSON.parse(sessionStorage.getItem('user'));

export function updateAuth(_user) {
    sessionStorage.setItem('user', JSON.stringify(_user));
    user = _user;
}

export function logout() {
    logoutUser()
        .then(res => {
            sessionStorage.removeItem('user');
            user = undefined;
        });
}