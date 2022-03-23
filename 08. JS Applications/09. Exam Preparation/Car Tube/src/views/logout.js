import { logout } from "../services/authService.js";
import page from '../../node_modules/page/page.mjs';

export function executeLogout() {
    logout()
        .then(data => {
            if (!data) {
                page.redirect('/'); //TO REDIRECT TO ALL LISTINGS
            } else {
                window.alert(data);
            }
        });
}