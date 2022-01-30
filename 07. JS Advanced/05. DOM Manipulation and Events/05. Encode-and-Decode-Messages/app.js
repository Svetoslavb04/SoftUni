function encodeAndDecodeMessages() {
    function encodeHandler() {
        let encodeTextareaElement = document.querySelector('#main div:nth-child(1) textarea');
        let decodeTextareaElement = document.querySelector('#main div:nth-child(2) textarea');

        let encodeedText = encodeTextareaElement.value;
        let decodedText = '';
        for (let char of encodeedText) {
            decodedText += String.fromCharCode(char.charCodeAt(0) + 1);
        }

        decodeTextareaElement.textContent = decodedText;
        encodeTextareaElement.value = '';
    }

    function decodeHandler() {
        let encodeTextareaElement = document.querySelector('#main div:nth-child(1) textarea');
        let decodeTextareaElement = document.querySelector('#main div:nth-child(2) textarea');

        let decodeedText = decodeTextareaElement.value;
        let encodeedText = '';

        for (let char of decodeedText) {
            encodeedText += String.fromCharCode(char.charCodeAt(0) - 1);
        }

        decodeTextareaElement.value = encodeedText;
    }

    let encodeButtonElement = document.querySelector('#main div:nth-child(1) button');
    let decodeButtonElement = document.querySelector('#main div:nth-child(2) button');

    encodeButtonElement.addEventListener('click', encodeHandler);
    decodeButtonElement.addEventListener('click', decodeHandler);
}