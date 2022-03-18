import { html, render } from '../node_modules/lit-html/lit-html.js';
import { getFurnitureByUser } from './api.js';
import { navigationTemplate } from './navigationTemplate.js';
import { user } from './auth.js'; 

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

let myFurnitureTemplate = (furnitures) => html`
    ${html`${navigationTemplate()}`}
    <div class="container">
        <div class="row space-top">
            <div class="col-md-12">
                <h1>My Furniture</h1>
                <p>This is a list of your publications.</p>
            </div>
        </div>
        <div class="row space-top">
            ${furnitures.map(f => html`${furnitureTemplate(f)}`)}
        </div>
    </div>`;

export function renderMyFurnitureView() 
{
    getFurnitureByUser(user._id)
        .then(furnitures => render(myFurnitureTemplate(furnitures), document.getElementById('root')));
}