function addItem() {
    let textElement = document.querySelector('#newItemText');
    let valueElement = document.querySelector('#newItemValue');

    let menuElement = document.querySelector('#menu');

    let optionElement = document.createElement('option');

    optionElement.textContent = textElement.value;
    optionElement.value = valueElement.value;

    textElement.value = '';
    valueElement.value = '';

    menuElement.appendChild(optionElement);

    
}