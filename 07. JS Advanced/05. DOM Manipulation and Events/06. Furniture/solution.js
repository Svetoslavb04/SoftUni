function solve() {
  function generateHandler() {
    let textareaElement = document.querySelector('#exercise textarea:nth-of-type(1)');
    let furniture = JSON.parse(textareaElement.value);

    let tableBody = document.querySelector('tbody');

    for (let f of furniture) {
      let newRow = document.createElement('tr');

      let orderedTds = [];

      for (let prop of Object.keys(f)) {
        let newTd = document.createElement('td');
        let newElement = document.createElement('p');

        switch (prop) {
          case 'img':
            newElement = document.createElement('img');
            newElement.src = f[prop];
            newTd.appendChild(newElement);
            orderedTds[0] = newTd;
            break;
          case 'name':
            newElement.textContent = f[prop];
            newTd.appendChild(newElement);
            orderedTds[1] = newTd;
            break;
          case 'price':
            newElement.textContent = f[prop];
            newTd.appendChild(newElement);
            orderedTds[2] = newTd;
            break;
          case 'decFactor':
            newElement.textContent = f[prop];
            newTd.appendChild(newElement);
            orderedTds[3] = newTd;
            break;
          default:
            break;
        }
      }

      for (const td of orderedTds) {
        newRow.appendChild(td);
      }

      let newTd = document.createElement('td');
      let checkBoxElement = document.createElement('input');
      checkBoxElement.type = 'checkbox';
      checkBoxElement.disabled = true;

      newTd.appendChild(checkBoxElement);
      newRow.appendChild(newTd);

      tableBody.appendChild(newRow);
    }

    let checkboxesElements = document.querySelectorAll('input[type=checkbox]');
    for (let checkbox of checkboxesElements) {
      checkbox.disabled = false;
    }

  }

  function buyHandler() {
    let checkboxesElements = document.querySelectorAll('input[type=checkbox]');

    let outputObj = {
      furniture: [],
      totalPrice: 0,
      totalDecFactor: 0
    }

    for (const checkbox of checkboxesElements) {
      if (checkbox.checked) {
        let tableRowElement = checkbox.parentElement.parentElement;

        let name = tableRowElement.children[1].textContent;
        let price = Number(tableRowElement.children[2].textContent);
        let decFactor = Number(tableRowElement.children[3].textContent);

        outputObj.furniture.push(name.trim());
        outputObj.totalPrice += price;
        outputObj.totalDecFactor += decFactor;
      }
    }

    let resultTextareaElement = document.querySelector('#exercise textarea:nth-of-type(2)');

    resultTextareaElement.value = `Bought furniture: ${outputObj.furniture.join(', ')}\nTotal price: ${outputObj.totalPrice.toFixed(2)}\nAverage decoration factor: ${(outputObj.totalDecFactor / outputObj.furniture.length)}`;

  }

  let generateButtonElement = document.querySelector('#exercise button:nth-of-type(1)');
  let buyButtonElement = document.querySelector('#exercise button:nth-of-type(2)');

  generateButtonElement.addEventListener('click', generateHandler);
  buyButtonElement.addEventListener('click', buyHandler);
}