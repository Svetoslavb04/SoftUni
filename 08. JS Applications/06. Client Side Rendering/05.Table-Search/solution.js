import { html, render } from '../node_modules/lit-html/lit-html.js';

function solve() {
   let tableBodyTemplate = (students) => html`${students.map(s => {
      return html`<tr>
      <td>${s.firstName} ${s.lastName}</td>
      <td>${s.email}</td>
      <td>${s.course}</td>
   </tr>`;
   })}`;

   const tableBodyElement = document.querySelector('tbody');

   fetch('http://localhost:3030/jsonstore/advanced/table')
      .then(res => res.json())
      .then(data => render(tableBodyTemplate(Object.values(data)), tableBodyElement));

   document.querySelector('#searchBtn').addEventListener('click', onClick);

   function onClick() {
      let search = document.querySelector('#searchField').value;
      let tableRows = tableBodyElement.children;

      for (const row of tableRows) {
         row.classList.remove('select');
      }

      for (const row of tableRows) {
         if (row.textContent.toLowerCase().includes(search.toLowerCase())) {
            row.classList.add('select');
         }
      }

      document.querySelector('#searchField').value = '';
   }
}

solve();