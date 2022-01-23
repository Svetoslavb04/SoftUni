function search() {
   let towns = document.querySelectorAll('li');
   let matcher = document.querySelector('#searchText');

   let totalMatches = 0;

   for (let i = 0; i < towns.length; i++) {
      if (towns[i].textContent.includes(matcher.value)) {
         towns[i].style['font-weight'] = 'bold';
         towns[i].style['text-decoration'] = 'underline';

         totalMatches++;
      }
   }

   let resultElement = document.querySelector('#result');

   resultElement.textContent = `${totalMatches} matches found`;
}
