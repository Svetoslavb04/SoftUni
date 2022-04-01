import { deleteEnitity } from "../services/entityService.js";

export function executeDelete(ctx) {
    deleteEnitity(ctx.params._id)
        .then(data => {
            if (data.message) {
                window.alert(data.message);
            }
            else {
                ctx.page.redirect('/');
            }
        })
}