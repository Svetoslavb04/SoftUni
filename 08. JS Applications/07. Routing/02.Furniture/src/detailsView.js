import { html, render } from '../node_modules/lit-html/lit-html.js';
import page from '../node_modules/page/page.mjs';
import { navigationTemplate } from './navigationTemplate.js';
import { getFurnitureDetails, deleteFurnitureEntity } from './api.js';
import { user } from './auth.js';

const detailsTemplate = (furniture) => html`
    ${html`${navigationTemplate()}`}
    <div class="container" _ownerId="${furniture._ownerId}">
        <div class="row space-top">
            <div class="col-md-12">
                <h1>Furniture Details</h1>
            </div>
        </div>
        <div class="row space-top">
            <div class="col-md-4">
                <div class="card text-white bg-primary">
                    <div class="card-body">
                        <img src=".${furniture.img}" />
                    </div>
                </div>
            </div>
            <div class="col-md-4">
                <p>Make: <span>${furniture.make}</span></p>
                <p>Model: <span>${furniture.model}</span></p>
                <p>Year: <span>${furniture.year}</span></p>
                <p>Description: <span>${furniture.description}</span></p>
                <p>Price: <span>${furniture.price}</span></p>
                <p>Material: <span>mat${furniture.material}</span></p>
                <div>
                    <a href="/furniture/edit/${furniture._id}" class="btn btn-info">Edit</a>
                    <a class="btn btn-red" @click=${deleteFurnitureHandler.bind(null, furniture._id)}>Delete</a>
                </div>
            </div>
        </div>
    </div>`;

export function renderDetailsView(ctx) {
    getFurnitureDetails(ctx.params._id)
        .then(furniture => {
            render(detailsTemplate(furniture), document.getElementById('root'));
            
            if (!user || user._id !== furniture._ownerId) {
                document.querySelector('.container a').parentNode.remove();
            }
        });
}

async function deleteFurnitureHandler(furniture_id, e) {
    e.preventDefault();

    const confirmText = 'Are you sure you want to delete the furniture?';

    if (confirm(confirmText) == true) {
        await deleteFurnitureEntity(furniture_id);
        page.redirect('/');
    }
}