class LibraryCollection {
    constructor(capacity) {
        if (capacity >= 0) {
            this.capacity = Number(capacity);
            this.books = [];
            this._totalBooks = 0;
        }
    }

    addBook(bookName, bookAuthor) {
        if (typeof bookName == 'string' && typeof bookAuthor == 'string') {
            if (this._totalBooks + 1 > this.capacity) {
                throw new Error('Not enough space in the collection.');
            } else {
                this.books.push({
                    bookName,
                    bookAuthor,
                    payed: false
                });

                this._totalBooks++;

                return `The ${bookName}, with an author ${bookAuthor}, collect.`;
            }
        }
    }

    payBook(bookName) {
        let indexOfBook = this.books.findIndex(b => b.bookName == bookName);

        if (indexOfBook == -1) {
            throw new Error(`${bookName} is not in the collection.`);
        } else if (this.books[indexOfBook].payed == true) {
            throw new Error(`${bookName} has already been paid.`);
        }
        else {
            this.books[indexOfBook].payed = true;

            return `${bookName} has been successfully paid.`;
        }
    }

    removeBook(bookName) {
        let indexOfBook = this.books.findIndex(b => b.bookName == bookName);

        if (indexOfBook == -1) {
            throw new Error("The book, you're looking for, is not found.");
        } else if (this.books[indexOfBook].payed == false) {
            throw new Error(`${bookName} need to be paid before removing from the collection.`);
        }
        else {
            this.books.splice(indexOfBook, 1);

            this._totalBooks--;

            return `${bookName} remove from the collection.`;
        }
    }

    getStatistics(bookAuthor) {
        let output = '';
        if (bookAuthor === undefined) {
            output += `The book collection has ${this.capacity - this.books.length} empty spots left.`

            this.books.sort((a, b) => a.bookName.localeCompare(b.bookName));

            for (const book of this.books) {
                output += `\n${book.bookName} == ${book.bookAuthor} - ${book.payed ? 'Has Paid' : 'Not Paid'}.`;
            }
        } else {
            let book = this.books.find(x => x.bookAuthor == bookAuthor);
            if (book === undefined) {
                throw new Error(`${bookAuthor} is not in the collection."`);
            }

            output += `${book.bookName} == ${book.bookAuthor} - ${book.payed ? 'Has Paid' : 'Not Paid'}.`;
        }
        return output;
    }
}