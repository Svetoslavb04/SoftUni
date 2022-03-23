import { render } from '../../node_modules/lit-html/lit-html.js';
import { layoutTemplate } from '../views/layout.js';

export function renderMiddleware(ctx, next) {
    ctx.render = (templateResult) => render(layoutTemplate.call(null, ctx, templateResult), document.getElementById('container'));

    next();
}