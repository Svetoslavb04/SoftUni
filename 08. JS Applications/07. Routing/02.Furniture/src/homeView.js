import { html, render } from '../node_modules/lit-html/lit-html.js';
import { getAllFurniture } from './api.js';
import { navigationTemplate } from './navigationTemplate.js';

let furnitureTemplate = (furniture) => html`
<div class="col-md-4">
    <div class="card text-white bg-primary">
        <div class="card-body" _ownerId="${furniture._ownerId}">
            <img src="${furniture.img}" />
            <p>${furniture.description}</p>
            <footer>
                <p>Price: <span>${furniture.price} $</span></p>
            </footer>
            <div>
                <a href="/furniture/${furniture._id}" class="btn btn-info">Details</a>
            </div>
        </div>
    </div>
</div>
`;

let homeTemplate = (furnitures) => html`
    ${html`${navigationTemplate()}`}
    <div class="container">
            <div class="row space-top">
                <div class="col-md-12">
                    <h1>Welcome to Furniture System</h1>
                    <p>Select furniture from the catalog to view details.</p>
                </div>
            </div>
            <div class="row space-top">
                ${furnitures.map(f => html`${furnitureTemplate(f)}`)}
            </div>
    </div>`;

export function renderHomeView() 
{
    getAllFurniture()
        .then(furnitures => render(homeTemplate(furnitures), document.getElementById('root')));
}