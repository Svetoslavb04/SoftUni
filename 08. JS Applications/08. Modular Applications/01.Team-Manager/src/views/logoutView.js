import page from "../../node_modules/page/page.mjs";
import { logout } from "../services/authService.js";
import { popNotification } from "../services/notificationService.js";

export function renderLogoutView() {
    logout()
        .then(res => page.redirect('/'))
        .catch(err => popNotification(err.message, (e) => {
            e.preventDefault();

            let messageParagraph = e.currentTarget.parentNode.querySelector('p');
            messageParagraph.textContent = '';
            
            let notification = e.currentTarget.parentNode.parentNode;
            notification.style.display = 'none';
        }));
}