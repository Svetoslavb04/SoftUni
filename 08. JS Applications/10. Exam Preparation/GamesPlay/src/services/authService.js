export const isAuthenticated = () => {
    let accessToken = JSON.parse(sessionStorage.getItem('user'));
    
    if (accessToken) {
        return true;
    } else {
        return false;
    }
};

export const baseUrl = 'http://localhost:3030/users';

export const getUser = () => {
    if (isAuthenticated()) {
        return JSON.parse(sessionStorage.getItem('user'));
    } else {
        return { email: undefined, _id: undefined, accessToken: undefined};
    }
    
};

export function save(user) {
    sessionStorage.setItem('user', JSON.stringify(user));
}

export function register(email, password) {
    return fetch(`${baseUrl}/register`, {
        method: 'POST',
        headers: {
            'Content-Type': 'application/json'
        },
        body: JSON.stringify({
            email,
            password
        })
    })
    .then(res => res.json())
    .then(user => {
        if (!user.message) {
            save(user);
        }
        return user;
    });
}

export function login(email, password) {
    return fetch(`${baseUrl}/login`, {
        method: 'POST',
        headers: {
            'Content-Type': 'application/json'
        },
        body: JSON.stringify({
            email,
            password
        })
    })
    .then(res => res.json())
    .then(user => {
        if (!user.message) {
            save(user);
        }
        return user;
    });
}

export function logout() {
    return fetch(`${baseUrl}/logout`, {
        method: 'GET',
        headers: {
            'Content-Type': 'application/json',
            'X-Authorization': getUser().accessToken
        }
    })
    .then(res => {
        if (res.status != 204) {
            sessionStorage.clear();
            return 'Invalid access token';
        } else {
            sessionStorage.clear();
            return false;
        }
    });
}