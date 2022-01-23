function solve() {
  let textToTransferElement = document.querySelector('#text');
  let namingConventionElement = document.querySelector('#naming-convention');

  let wordsFromText = textToTransferElement.value.split(' ');
  let outputString = '';

  if (namingConventionElement.value == 'Camel Case') {

    outputString += wordsFromText[0].toLowerCase();

    for (let i = 1; i < wordsFromText.length; i++) {
      let word = wordsFromText[i].toLowerCase();
      word = word.charAt(0).toUpperCase() + word.slice(1);

      outputString += word;
    }
  }
  else if (namingConventionElement.value == 'Pascal Case') {

    for (let i = 0; i < wordsFromText.length; i++) {
      let word = wordsFromText[i].toLowerCase();
      word = word.charAt(0).toUpperCase() + word.slice(1);

      outputString += word;
    }

  } else {
    outputString = 'Error!';
  }

  let resultElement = document.querySelector('#result');
  resultElement.textContent = outputString;
}