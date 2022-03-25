import { logout } from "../services/authService.js";
import page from '../../node_modules/page/page.mjs';

export function executeLogout(ctx) {
    logout()
        .then(data => {
            if (data) {
                window.alert(data);
            } else {
                page.redirect('/');
            }
        })
}