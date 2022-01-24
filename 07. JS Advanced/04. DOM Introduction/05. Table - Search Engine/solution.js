function solve() {
   document.querySelector('#searchBtn').addEventListener('click', onClick);
   
   function onClick() {
     let matchElement = document.querySelector('#searchField');
     let match = matchElement.value.toLowerCase();

     let rows = document.querySelectorAll('tbody tr');

     for (let row of rows) {
      row.classList.remove('select');
     }

     if (match == '') {
     } else {
      matchElement.value = '';

      for (let row of rows) {
         for (const cell of Array.from(row.children)) {
          if (cell.textContent.toLowerCase().includes(match)) {
             row.classList.add('select');
          }
         }
      }
     }
     
   }
}