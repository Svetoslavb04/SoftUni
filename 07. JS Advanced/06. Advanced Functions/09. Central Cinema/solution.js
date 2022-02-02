function solve() {
    function addMovie(e) {
        e.preventDefault();
        let nameElement = document.querySelector('#container input:nth-child(1)');
        let hallElement = document.querySelector('#container input:nth-child(2)');
        let ticketPriceElement = document.querySelector('#container input:nth-child(3)');

        let name = nameElement.value;
        let hall = hallElement.value;
        let ticketPrice = ticketPriceElement.value;

        if (name == '' || hall == '' || ticketPrice == '' || isNaN(ticketPrice)) {
            return;
        }

        let movieElement = createMovieElement(name, hall, ticketPrice);

        let moviesSection = document.querySelector('#movies ul');

        moviesSection.appendChild(movieElement);

        nameElement.value = '';
        hallElement.value = '';
        ticketPriceElement.value = '';
    }

    let onScreenButton = document.querySelector('#add-new div button');
    onScreenButton.addEventListener('click', addMovie);

    let clearButton = document.querySelector('#archive button');
    clearButton.addEventListener('click', clearHandler);

    function createMovieElement(name, hall, ticketPrice) {
        let movieElement = document.createElement('li');
    
        let nameSpanElement = document.createElement('span');
        nameSpanElement.textContent = name;
    
        let hallStrongElement = document.createElement('strong');
        hallStrongElement.textContent = `Hall: ${hall}`;
    
        let divElement = document.createElement('div');
    
        let priceStrongElement = document.createElement('strong');
        priceStrongElement.textContent = `${Number(ticketPrice).toFixed(2)}`;
    
        let soldTicketsInputElement = document.createElement('input');
        soldTicketsInputElement.placeholder = 'Tickets Sold';
    
        let archiveButtonElement = document.createElement('button');
        archiveButtonElement.textContent = 'Archive';
    
        movieElement.appendChild(nameSpanElement);
        movieElement.appendChild(hallStrongElement);
        divElement.appendChild(priceStrongElement);
        divElement.appendChild(soldTicketsInputElement);
        divElement.appendChild(archiveButtonElement);
        movieElement.appendChild(divElement);
    
        function archiveHandler() {
            if (soldTicketsInputElement.value != '' && soldTicketsInputElement.value >= 0) {
                let archivedList = document.createElement('li');
    
                let nameSpanElement = document.createElement('span');
                nameSpanElement.textContent = name;
    
                let totalAmountElement = document.createElement('strong');
                totalAmountElement.textContent = `Total amount: ${(Number(soldTicketsInputElement.value) * Number(priceStrongElement.textContent)).toFixed(2)}`;
                
                let deleteButtonElement = document.createElement('button');
                deleteButtonElement.textContent = 'Delete';
    
                archivedList.appendChild(nameSpanElement);
                archivedList.appendChild(totalAmountElement);
                archivedList.appendChild(deleteButtonElement);
    
                deleteButtonElement.addEventListener('click', () => {
                    archivedList.remove();
                });
    
                let archivedMovies = document.querySelector('#archive ul');
                archivedMovies.appendChild(archivedList);
    
                movieElement.remove();
            }
        }
    
        archiveButtonElement.addEventListener('click', archiveHandler);
        
        return movieElement;
    }
    
    function clearHandler() {
        let archivedMovies = document.querySelectorAll('#archive ul li');
    
        for (let movie of Array.from(archivedMovies)) {
            movie.remove();
        }
    }
}