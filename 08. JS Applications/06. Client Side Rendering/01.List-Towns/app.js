import { html, render} from '../node_modules/lit-html/lit-html.js';

let listTemplate = (names) => html`
    <ul>
    ${names.map(n => html`${nameTemplate(n)}`)}
    </ul>
`;

let nameTemplate = (name) => html`<li>${name}</li>`;

let rootElement = document.getElementById('root');

let form = document.querySelector('.content');
form.addEventListener('submit', (e) => {
    e.preventDefault();

    let formdata = new FormData(e.currentTarget);

    let names = formdata.get('towns').split(', ');

    render(listTemplate(names), rootElement);
})
