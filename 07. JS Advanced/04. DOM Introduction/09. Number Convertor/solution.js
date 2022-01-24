function solve() {
    let menuElement = document.querySelector('#selectMenuTo');

    let binaryOption = document.createElement('option');
    binaryOption.value = 'binary';
    binaryOption.textContent = 'Binary';
    menuElement.appendChild(binaryOption);

    let hexdecimalOption = document.createElement('option');
    hexdecimalOption.value = 'hexadecimal';
    hexdecimalOption.textContent = 'Hexadecimal';

    menuElement.appendChild(hexdecimalOption);

    let convertNumber = function () {
        let numberElement = document.querySelector('#input');
        let number = Number(numberElement.value);

        let output;

        if (menuElement.value == 'binary') {
            output = number.toString(2);
        } else if (menuElement.value == 'hexadecimal') {
            output = number.toString(16).toUpperCase();
        }

        let resultElement = document.querySelector('#result');
        resultElement.value = output;
    }

    let button = document.querySelector('#container button');
    button.onclick = convertNumber;

}