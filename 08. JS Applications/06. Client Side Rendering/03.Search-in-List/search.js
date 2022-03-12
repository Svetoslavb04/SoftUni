import { html, render}  from '../node_modules/lit-html/lit-html.js';
import { towns } from './towns.js';

let townsTemplate = (towns) => html`<ul>${towns.map(t => html`<li>${t}</li>`)}</ul>`;

render(townsTemplate(towns), document.getElementById('towns'));

let searchButton = document.querySelector('button');
searchButton.addEventListener('click', search);

function search(e) {
   e.preventDefault();

   let searchText = document.getElementById('searchText').value;

   let townsLis = document.querySelectorAll('ul > li');

   let totalMatches = 0;

   townsLis.forEach(li => li.classList.remove('active'));

   townsLis.forEach(li => {
      if (li.textContent.toLowerCase().includes(searchText.toLowerCase())) {
         li.classList.add('active');
         totalMatches++;
      }
   });

   document.getElementById('searchText').value = '';

   let resultElement = document.getElementById('result');
   
   resultElement.textContent = `${totalMatches} matches found`;
}