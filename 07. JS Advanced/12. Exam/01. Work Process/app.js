function solve() {
    let hireWorkerButton = document.querySelector('#add-worker');

    function hireWorkerHandler(e) {
        e.preventDefault();

        let firstNameElement = document.querySelector('#fname');
        let lastNameElement = document.querySelector('#lname');
        let emailElement = document.querySelector('#email');
        let birthElement = document.querySelector('#birth');
        let positionElement = document.querySelector('#position');
        let salaryElement = document.querySelector('#salary');

        let firstName = firstNameElement.value;
        let lastName = lastNameElement.value;
        let email = emailElement.value;
        let birth = birthElement.value;
        let position = positionElement.value;
        let salary = salaryElement.value;

        if (!firstName || !lastName || !email || !birth || !position || !salary) {
            return;
        }

        let rowElement = document.createElement('tr');
        let firstNameTd = document.createElement('td');
        firstNameTd.textContent = firstName;
        let lastNameTd = document.createElement('td');
        lastNameTd.textContent = lastName;

        let emailTd = document.createElement('td');
        emailTd.textContent = email;

        let birthTd = document.createElement('td');
        birthTd.textContent = birth;

        let positionTd = document.createElement('td');
        positionTd.textContent = position;

        let salaryTd = document.createElement('td');
        salaryTd.textContent = salary;

        let buttonsTd = document.createElement('td');
        let firedButton = document.createElement('button');
        firedButton.classList.add('fired');
        firedButton.textContent = 'Fired';

        let editButton = document.createElement('button');
        editButton.classList.add('edit');
        editButton.textContent = 'Edit';

        buttonsTd.appendChild(firedButton);
        buttonsTd.appendChild(editButton);

        rowElement.appendChild(firstNameTd);
        rowElement.appendChild(lastNameTd);
        rowElement.appendChild(emailTd);
        rowElement.appendChild(birthTd);
        rowElement.appendChild(positionTd);
        rowElement.appendChild(salaryTd);
        rowElement.appendChild(buttonsTd);

        let tableBodyElement = document.querySelector('#tbody');
        tableBodyElement.appendChild(rowElement);

        let budgetSpanElement = document.querySelector('#sum');
        budgetSpanElement.textContent = (Number(budgetSpanElement.textContent) + Number(salary)).toFixed(2);

        firstNameElement.value = '';
        lastNameElement.value = '';
        emailElement.value = '';
        birthElement.value = '';
        positionElement.value = '';
        salaryElement.value = '';

        function editWorkerHandler(e) {
            e.preventDefault();

            firstNameElement.value = firstName;
            lastNameElement.value = lastName;
            emailElement.value = email;
            birthElement.value = birth;
            positionElement.value = position;
            salaryElement.value = salary;

            budgetSpanElement.textContent = (Number(budgetSpanElement.textContent) - Number(salary)).toFixed(2);

            rowElement.remove();
        }

        editButton.addEventListener('click', editWorkerHandler);

        function fireWorkerHandler() {
            e.preventDefault();

            budgetSpanElement.textContent = (Number(budgetSpanElement.textContent) - Number(salary)).toFixed(2);

            rowElement.remove();
        }

        firedButton.addEventListener('click', fireWorkerHandler);
    }

    hireWorkerButton.addEventListener('click', hireWorkerHandler);
}
solve()