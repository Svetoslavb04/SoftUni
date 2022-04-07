const baseUrl = 'http://localhost:3030/users';

const saveUser = (user) => sessionStorage.setItem('user', JSON.stringify({ _id: user._id, email: user.email, accessToken: user.accessToken}));

export const getUser = () => JSON.parse(sessionStorage.getItem('user')) || {} ;

export const login = (email, password) => fetch(`${baseUrl}/login`, {
        method: 'POST',
        body: JSON.stringify({ email, password})
    })
    .then(res => res.json())
    .then(data => {
        saveUser(data);

        return data;
    })
    .catch(err => err);

export const register = (email, password) => fetch(`${baseUrl}/register`, {
        method: 'POST',
        body: JSON.stringify({ email, password})
    })
    .then(res => res.json())
    .then(data => {
        saveUser(data);

        return data;
    })
    .catch(err => err);

export const logout = () => fetch(`${baseUrl}/logout`, {
        method: 'GET',
        headers: {
            'X-Authorization': getUser().accessToken
        }
    })
    .then(res => {
        if (res.status != 204) {
            return res.json();
        } else {
            return res
        }
    })
    .then(data => {
        sessionStorage.clear();
        
        if (!data.message) {
            return {};
        } else {
            throw data;
        }
    })
    .catch(err => err);

