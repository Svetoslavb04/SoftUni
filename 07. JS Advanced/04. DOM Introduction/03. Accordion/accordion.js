function toggle() {
    let buttonMoreElement = document.querySelector('span.button');
    let hiddenParagraph = document.querySelector('#extra');

    if (buttonMoreElement.textContent == 'More') {
        hiddenParagraph.style.display = 'block';
        buttonMoreElement.textContent = 'Less';
    } else {
        hiddenParagraph.style.display = 'none';
        buttonMoreElement.textContent = 'More';
    }

    
}