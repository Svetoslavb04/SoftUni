function solve() {
  let textAreaElement = document.querySelector('#input');
  let outputDivElement = document.querySelector('#output');

  let sentences = Array.from(textAreaElement.value.split('.')).filter(Boolean).map(x => x.trim());
  
  while (sentences.length > 0) {
    let p = document.createElement("p");
    
    let sentencesToAdd = sentences.splice(0, 3).filter(Boolean);

    p.textContent = sentencesToAdd.join('. ') + '.';

    outputDivElement.appendChild(p);
  }  
}