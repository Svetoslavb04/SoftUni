function create(words) {
   var contentElement = document.getElementById('content');

   for (const text of words) {
      var sectionElement = document.createElement('div');
      var paragraphElement = document.createElement('p');

      paragraphElement.textContent = text;
      paragraphElement.style.display = 'none';

      sectionElement.appendChild(paragraphElement);
      sectionElement.addEventListener('click', (e) => {
         var paragraph = e.currentTarget.children[0];
         paragraph.style.display = 'inline';
      })

      contentElement.appendChild(sectionElement);
   }
}