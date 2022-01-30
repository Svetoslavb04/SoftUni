function solve() {
  function generateHandler() {
    let textareaElement = document.querySelector('#exercise textarea:nth-of-type(1)');
    let furniture = JSON.parse(textareaElement.value);

    let tableBody = document.querySelector('tbody');

    for (let f of furniture) {
      let newRow = document.createElement('tr');
      
      for (let prop of f) {
        let newTd = document.createElement('td');
        new[prop] = prop.value;
        newRow.appendChild(newTd);
      }

      tableBody.appendChild(newRow);
    }
  }
  
  let generateButtonElement = document.querySelector('#exercise button:nth-of-type(1)');
  let buyButtonElement = document.querySelector('#exercise button:nth-of-type(2)');

  generateButtonElement.addEventListener('click', generateHandler);
  buyButtonElement.addEventListener('click', buyHandler);
}