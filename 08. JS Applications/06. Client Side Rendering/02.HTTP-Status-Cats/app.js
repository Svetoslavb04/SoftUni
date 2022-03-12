import { html, render}  from '../node_modules/lit-html/lit-html.js';
import {cats} from './catSeeder.js';  

let catsListTemplate = (cats) => html`<ul>${cats.map(c => html`${catTemplate(c)}`)}</ul>`;

let catTemplate = (cat) => html`<li>
    <img src="./images/${cat.imageLocation}.jpg" width="250" height="250" alt="Card image cap">
    <div class="info">
    <button class="showBtn" @click=${showMoreInfo}>Show status code</button>
    <div class="status" style="display: none" id="${cat.id}">
        <h4>Status Code: ${cat.statusCode}</h4>
        <p>${cat.statusMessage}</p>
    </div>
    </div>
    </li>`;

function showMoreInfo(e) {
    e.preventDefault();

    let infoDiv = e.currentTarget.parentNode;

    if (e.currentTarget.textContent == 'Show status code') {
        infoDiv.children[1].style.display = 'inline';
        e.currentTarget.textContent = 'Hide status code';
    } else if(e.currentTarget.textContent == 'Hide status code'){
        infoDiv.children[1].style.display = 'none';
        e.currentTarget.textContent = 'Show status code';
    }
}

render(catsListTemplate(cats), document.getElementById('allCats'));