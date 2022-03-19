import{ render } from '../../node_modules/lit-html/lit-html.js';
import { layoutTemplate } from '../views/layoutView.js';

const rootElement = document.querySelector('#root');

const renderFunction = (ctx, templateResult) => render(layoutTemplate(ctx, templateResult), rootElement);

export function renderMiddleware(ctx, next) {
    ctx.render = renderFunction.bind(null, ctx);

    next();
}

