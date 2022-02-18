window.addEventListener('load', solve);

function solve() {
    let addButtonElement = document.querySelector('#add');
    let modelInputElement = document.querySelector('#model');
    let yearInputElement = document.querySelector('#year');
    let descriptionInputElement = document.querySelector('#description');
    let priceInputElement = document.querySelector('#price');

    function addHandler(e) {
        e.preventDefault();

        let model = modelInputElement.value;
        let year = yearInputElement.value;
        let description = descriptionInputElement.value;
        let price = priceInputElement.value;

        if (!model || !year || !description || !price || Number(price) < 0 || Number(year) < 0) {
            return;
        }

        let tbody = document.querySelector('#furniture-list');

        let infoTr = document.createElement('tr');
        infoTr.classList.add('info');

        let modelTd = document.createElement('td');
        modelTd.textContent = model;

        let priceTd = document.createElement('td');
        priceTd.textContent = Number(price).toFixed(2);

        let buttonsTd = document.createElement('td');
        let moreInfoButton = document.createElement('button');
        moreInfoButton.classList.add('moreBtn');
        moreInfoButton.textContent = 'More Info';

        let buyItButton = document.createElement('button');
        buyItButton.classList.add('buyBtn');
        buyItButton.textContent = 'Buy it';

        buttonsTd.appendChild(moreInfoButton);
        buttonsTd.appendChild(buyItButton);

        infoTr.appendChild(modelTd);
        infoTr.appendChild(priceTd);
        infoTr.appendChild(buttonsTd);

        let moreInfoTr = document.createElement('tr');
        moreInfoTr.classList.add('hide');

        let yearTd = document.createElement('td');
        yearTd.textContent = `Year: ${year}`;

        let descriptionTd = document.createElement('td');
        descriptionTd.setAttribute('colspan', 3);
        descriptionTd.textContent = `Description: ${description}`;

        moreInfoTr.appendChild(yearTd);
        moreInfoTr.appendChild(descriptionTd);

        tbody.appendChild(infoTr);
        tbody.appendChild(moreInfoTr);

        function moreInfoHandler(e) {
            if (e.currentTarget.textContent == 'More Info') {
                e.currentTarget.textContent = 'Less Info';
                moreInfoTr = e.currentTarget.parentElement.parentElement.nextSibling;
                moreInfoTr.style.display = 'contents';  
            } else {
                e.currentTarget.textContent = 'More Info';
                moreInfoTr = e.currentTarget.parentElement.parentElement.nextSibling;
                moreInfoTr.style.display = 'none';  
            }
        }

        function buyItHandler() {
            let totalPriceElement = document.querySelector('.total-price');
            totalPriceElement.textContent = (Number(totalPriceElement.textContent) + Number(price)).toFixed(2);

            infoTr.remove();
            moreInfoTr.remove();
        }

        moreInfoButton.addEventListener('click', moreInfoHandler);
        buyItButton.addEventListener('click', buyItHandler);
    }

    addButtonElement.addEventListener('click', addHandler);
}
