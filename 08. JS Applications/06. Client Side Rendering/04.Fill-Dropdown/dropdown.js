import { html, render } from '../node_modules/lit-html/lit-html.js';

let optionsTemplate = (data) => 
    html`${data.map(e => html`<option _id=${e._id}>${e.text}</option>`)}`;

let data = await fetch('http://localhost:3030/jsonstore/advanced/dropdown')
    .then(data => data.json());

const menuSelect = document.getElementById('menu');

render(optionsTemplate(Object.values(data)), menuSelect);

const addBtn = document.querySelector('input[type="submit"]');
addBtn.addEventListener('click', (e) => {
    e.preventDefault();

    addItem();
})

async function addItem() {
    let text = document.querySelector('#itemText').value;

    if(text) {
        const res = await fetch('http://localhost:3030/jsonstore/advanced/dropdown', {
            method: 'POST',
            body: JSON.stringify({text})
        });

        if (res.ok) {
            let texts = await fetch('http://localhost:3030/jsonstore/advanced/dropdown')
                .then(res => res.json());

            render(optionsTemplate(Object.values(texts)), menuSelect);

            document.querySelector('#itemText').value = '';
        }
    }
}