function attachEvents() {
    let loadButton = document.getElementById('btnLoad');
    loadButton.addEventListener('click', loadNumbers);

    let createButton = document.getElementById('btnCreate');
    createButton.addEventListener('click', createNumber);
}

function loadNumbers() {
    let phonebookElement = document.getElementById('phonebook');
    phonebookElement.innerHTML = '';

    fetch('http://localhost:3030/jsonstore/phonebook')
        .then((res) => res.json())
        .then((data) => {
            Object.values(data).forEach(p => {
                let liElement = document.createElement('li');
                liElement.textContent = `${p.person}: ${p.phone}`;

                let deleteButton = document.createElement('button');
                deleteButton.textContent = 'Delete';
                deleteButton.setAttribute('id', p._id);
                
                deleteButton.addEventListener('click', deleteEntry);

                liElement.appendChild(deleteButton);

                phonebookElement.appendChild(liElement);
            });
        })    
}

async function deleteEntry(e) {
    await fetch(`http://localhost:3030/jsonstore/phonebook/${e.currentTarget.getAttribute('id')}`, {
        method: 'DELETE'
    })

    loadNumbers();
}

async function createNumber(e) {
    e.preventDefault();

    let person = document.querySelector('#person');
    let phone = document.querySelector('#phone');

    await fetch('http://localhost:3030/jsonstore/phonebook', {
        method: 'POST',
        body: JSON.stringify({
            "person": person.value,
            "phone": phone.value
          })
    })

    loadNumbers();
}

attachEvents();