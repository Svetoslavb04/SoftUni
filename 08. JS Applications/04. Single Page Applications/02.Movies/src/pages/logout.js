import { clearSession, authToken } from "../auth.js";
import { displayLogin } from "./login.js";

export async function logout() {
    try {
        const response = await fetch('http://localhost:3030/users/logout', {
        method: 'GET',
        headers: {
            'X-Authorization': authToken
        }
    });
        if (response.status != 200 && response.status != 204)  {
            throw Error('Invalid access token');
        }

        clearSession();
        displayLogin();
        
    } catch (error) {
        alert(error.message);
        displayLogin();
    }
    
}