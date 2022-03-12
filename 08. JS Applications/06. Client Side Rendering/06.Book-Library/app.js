import { html, render } from "../node_modules/lit-html/lit-html.js";

let booksTemplate = (bookKeys, booksObject) => html`${bookKeys.map(bk => html`${html`<tr _id=${bk}>
<td>${booksObject[bk].title}</td>
<td>${booksObject[bk].author}</td>
<td>
    <button _id=${bk} @click=${editBook}>Edit</button>
    <button _id=${bk} @click=${deleteBook}>Delete</button>
</td>
</tr>`}`)}`;

let addFormTemplate = () => html`<form id="add-form">
<h3>Add book</h3>
<label>TITLE</label>
<input type="text" name="title" placeholder="Title...">
<label>AUTHOR</label>
<input type="text" name="author" placeholder="Author...">
<input type="submit" value="Submit" @click=${createBook}>
</form>`;

let editFormTemplate = (bookKey) => html`<form id="edit-form">
<input type="hidden" name="id">
<h3>Edit book</h3>
<label>TITLE</label>
<input type="text" name="title" placeholder="Title..." value=${booksObject[bookKey].title}>
<label>AUTHOR</label>
<input type="text" name="author" placeholder="Author..." value=${booksObject[bookKey].author}>
<input type="submit" value="Save" @click=${saveBook} _id=${bookKey}>
</form>`;

let initialTemplate = () => html`<button id="loadBooks" @click=${loadBooks}>LOAD ALL BOOKS</button>
<table>
    <thead>
        <tr>
            <th>Title</th>
            <th>Author</th>
            <th>Action</th>
        </tr>
    </thead>
    <tbody>
    </tbody>
</table>
${html`${addFormTemplate()}`}`;

let editTemplate = (bookKeys, booksObject, editedBookKey) => html`<button id="loadBooks" @click=${loadBooks}>LOAD ALL BOOKS</button>
<table>
    <thead>
        <tr>
            <th>Title</th>
            <th>Author</th>
            <th>Action</th>
        </tr>
    </thead>
    <tbody>
    ${html`${booksTemplate(bookKeys, booksObject)}`}
    </tbody>
</table>
${html`${editFormTemplate(editedBookKey)}`}`;

let booksObject = await fetch('http://localhost:3030/jsonstore/collections/books')
    .then(res => res.json());
let bookKeys = Object.keys(booksObject);

render(initialTemplate(), document.querySelector('body'));

function loadBooks(e) {
    e.preventDefault();

    fetch('http://localhost:3030/jsonstore/collections/books')
        .then(res => res.json())
        .then(data => {
            booksObject = data;
            bookKeys = Object.keys(data)
            render(booksTemplate(bookKeys, booksObject), document.querySelector('tbody'))
    });
}

async function createBook(e) {
    e.preventDefault();

    let form = document.querySelector('#add-form');
    let formdata = new FormData(form);

    let author = formdata.get('author');
    let title = formdata.get('title');

    if (!author || !title) {
        alert('All fields are required');
        return;
    }

    await fetch('http://localhost:3030/jsonstore/collections/books', {
        method:'POST',
        body: JSON.stringify({
            "author": author,
            "title": title
          })
    });

    booksObject = await fetch('http://localhost:3030/jsonstore/collections/books')
        .then(res => res.json());
    bookKeys = Object.keys(booksObject);

    render(booksTemplate(bookKeys, booksObject), document.querySelector('tbody'));
}

function saveBook(e) {
    e.preventDefault();

    let editedBookId = e.currentTarget.getAttribute('_id');

    let form = e.currentTarget.parentNode;
    let formdata = new FormData(form);

    let author = formdata.get('author');
    let title = formdata.get('title');

    if (!author || !title) {
        alert('All fields are required');
        return;
    }

    fetch(`http://localhost:3030/jsonstore/collections/books/${editedBookId}`, {
        method: 'PUT',
        body: JSON.stringify({
            "author": author,
            "title": title
          })
    })
    .then(res => {
        fetch('http://localhost:3030/jsonstore/collections/books')
        .then(res => res.json())
        .then(data => {
            booksObject = data;
            bookKeys = Object.keys(data)
            render(initialTemplate(), document.querySelector('body'));
            render(booksTemplate(bookKeys, booksObject), document.querySelector('tbody'))
        });
    });
}

function editBook(e) {
    e.preventDefault();

    let editedBookId = e.currentTarget.getAttribute('_id');
    render(editTemplate(bookKeys, booksObject, editedBookId), document.querySelector('body'));

}

async function deleteBook(e) {
    e.preventDefault();

    let id = e.currentTarget.getAttribute('_id');

    await fetch(`http://localhost:3030/jsonstore/collections/books/${id}`, {
        method: 'DELETE'
    });

    fetch('http://localhost:3030/jsonstore/collections/books')
        .then(res => res.json())
        .then(data => {
            booksObject = data;
            bookKeys = Object.keys(data)
            render(booksTemplate(bookKeys, booksObject), document.querySelector('tbody'))
    });
}