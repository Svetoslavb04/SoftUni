function loadStudents() {
    let tbodyElement = document.querySelector('tbody');

    fetch('http://localhost:3030/jsonstore/collections/students')
        .then((res) => res.json())
        .then((data) => {
            Object.values(data).forEach(s => {
                let trElement = document.createElement('tr');

                let firstNameElement = document.createElement('td');
                let lastNameElement = document.createElement('td');
                let facultyNumElement = document.createElement('td');
                let gradeElement = document.createElement('td');

                firstNameElement.textContent = s.firstName;
                lastNameElement.textContent = s.lastName;
                facultyNumElement.textContent = s.facultyNumber;
                gradeElement.textContent = s.grade;

                trElement.appendChild(firstNameElement);
                trElement.appendChild(lastNameElement);
                trElement.appendChild(facultyNumElement);
                trElement.appendChild(gradeElement);

                tbodyElement.appendChild(trElement);
            });
        })
}

function createStudent() {
    let firstName = document.querySelector('.inputs input:nth-child(1)').value;
    let lastName = document.querySelector('.inputs input:nth-child(2)').value;
    let facultyNum = document.querySelector('.inputs input:nth-child(3)').value;
    let grade = document.querySelector('.inputs input:nth-child(4)').value;

    console.log(firstName);

    let firstNameElement = document.createElement('td');
    let lastNameElement = document.createElement('td');
    let facultyNumElement = document.createElement('td');
    let gradeElement = document.createElement('td');
}

let createButtonElement = document.getElementById('submit');
createButtonElement.addEventListener('click', createStudent);
loadStudents();