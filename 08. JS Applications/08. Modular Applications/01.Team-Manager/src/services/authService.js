const baseUrl = 'http://localhost:3030/users';

const save = (user) => {
    if (user) {
        sessionStorage.setItem('accessToken', user.accessToken);
        sessionStorage.setItem('email', user.email);
        sessionStorage.setItem('username', user.username);
        sessionStorage.setItem('_id', user._id);
    }
};

export const login = (email, password) => {
    return fetch(`${baseUrl}/login`, {
        method: 'POST',
        headers: {
            'content-type': 'application/json'
        },
        body: JSON.stringify({email, password})
    })
        .then(res => res.json())
        .then(user => {
            save(user);

            return user;
        });
};

export const register = (email, username, password) => {
    return fetch(`${baseUrl}/register`, {
        method: 'POST',
        headers: { 'Content-Type': 'application/json' },
        body: JSON.stringify({
            email,
            username,
            password
        })
    })
        .then(res => res.json())
        .then(data => {
            if (data.message) {
                throw new Error(data.message);
            } else {
                save(data);

                return data;
            }
            
        })
        .catch(err => err);
};

export const isAuthenticated = () => {
    let accessToken = sessionStorage.getItem('accessToken');
    
    return Boolean(accessToken);
};

export const getUser = () => {
    let username = sessionStorage.getItem('username');
    let email = sessionStorage.getItem('email');
    let _id = sessionStorage.getItem('_id');
    let accessToken = sessionStorage.getItem('accessToken');
    
    let user = {
        username,
        email,
        _id,
        accessToken
    };

    return user;
}

export const logout = () => {
    let accessToken = sessionStorage.getItem('accessToken');

    return fetch(`${baseUrl}/logout`, {
        headers: {
            'X-Authorization': accessToken
        }
    })
        .then(res => {
            sessionStorage.clear();
        });
};