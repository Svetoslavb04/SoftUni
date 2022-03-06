let loadButton = document.getElementById('loadBooks');
loadButton.addEventListener('click', loadBooks);

let formElement = document.querySelector('form');
formElement.addEventListener('submit', handleBook);

let _selectedBookId = '';

function loadBooks() {
    let tbodyElement = document.querySelector('tbody');
    tbodyElement.innerHTML = '';
    fetch('http://localhost:3030/jsonstore/collections/books')
        .then((res) => res.json())
        .then((data) => {
            Object.values(data).forEach(b => {
                let trElement = document.createElement('tr');

                let authorElement = document.createElement('td');
                let titleElement = document.createElement('td');
                let buttonsElement = document.createElement('td');

                authorElement.textContent = b.author;
                titleElement.textContent = b.title;
                
                let editButtonElement = document.createElement('button');
                let deleteButtonElement = document.createElement('button');

                let id = Object.keys(data).filter(bo =>  data[bo].title == b.title);

                deleteButtonElement.setAttribute('id', id[0]);

                editButtonElement.addEventListener('click', editBook);
                deleteButtonElement.addEventListener('click', deleteBook);

                editButtonElement.textContent = 'Edit';
                deleteButtonElement.textContent = 'Delete';

                buttonsElement.appendChild(editButtonElement);
                buttonsElement.appendChild(deleteButtonElement);

                trElement.appendChild(titleElement);
                trElement.appendChild(authorElement);
                trElement.appendChild(buttonsElement);

                tbodyElement.appendChild(trElement);
            });
        })
}

function editBook(e) {
    let author = e.currentTarget.parentNode.parentNode.children[0].textContent;
    let title = e.currentTarget.parentNode.parentNode.children[1].textContent;

    _selectedBookId = e.currentTarget.parentNode.parentNode.children[2].children[1].getAttribute('id');
    
    formElement.children[0].textContent = 'Edit FORM';

    formElement.children[4].value = author;
    formElement.children[2].value = title;

    formElement.children[5].textContent = 'Save';
}

async function deleteBook(e) {
    let id = e.currentTarget.getAttribute('id');

    await fetch(`http://localhost:3030/jsonstore/collections/books/${id}`, {
        method: 'DELETE'
    });

    loadBooks();
}


async function handleBook(e) {
    e.preventDefault();
    let formData = new FormData(formElement);

    if (e.currentTarget[2].textContent == 'Submit') {
        

        let author = formData.get('author');
        let title = formData.get('title');

        if (!author || !title) {
            alert('Invalid data');
            return;
        } 

    fetch(`http://localhost:3030/jsonstore/collections/books/`, {
        method: 'POST',
        headers: {
            'Content-type': 'application/json'
        },
        body: JSON.stringify({
            author,
            title
        })
    });
    } else if(e.currentTarget[2].textContent == 'Save') {
        let formDataAuthor = formData.get('author');
        let formDataTitle = formData.get('title');

        if (!formDataAuthor || !formDataTitle) {
            alert('Invalid data');
            return;
        }
        
        let bodyReq = JSON.stringify({
            "author": formDataAuthor,
            "title": formDataTitle
          });

        await fetch(`http://localhost:3030/jsonstore/collections/books/${_selectedBookId}`, {
            method: 'PUT',
            headers: {
                'Content-type': 'application/json'
            },
            body: bodyReq
        })
        .catch((err) => console.log(err));

        formElement.children[0].textContent = 'FORM';
        formElement.children[4].value = '';
        formElement.children[2].value = '';
        formElement.children[5].textContent = 'Submit';
    }

    loadBooks();
}

loadBooks();