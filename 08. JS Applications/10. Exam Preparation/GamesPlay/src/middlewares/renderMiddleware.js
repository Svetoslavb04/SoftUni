import { render } from "../../node_modules/lit-html/lit-html.js";
import { layoutTemplate } from "../views/layoutView.js";

export const renderMiddleware = (ctx, next) => {
    ctx.render = (templateResult) => render(layoutTemplate.call(null, ctx, templateResult), document.getElementById('box'));

    next();
}