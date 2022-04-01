import { logout } from "../services/authService.js";

export function executeLogout(ctx) {
    logout()
        .then(data => {
            if (data.message) {
                window.alert(data.message);
            }
            else {
                ctx.page.redirect('/');
            }
        })
}