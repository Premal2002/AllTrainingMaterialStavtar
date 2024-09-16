import { Book } from "./Book";

export class Library {
  books: Book[] = [];

  constructor() { }

  addBook(book: Book): string {
    if (
      this.books.some(
        (bookRef) => bookRef.title == book.title || bookRef.isbn == book.isbn
      )
    ) {
      return `Book with title{${book.title}} or isbn{${book.isbn}} already there in list`;
    }

    this.books.push(book);
    return `Book added successfully`;
  }

  removeBook(isbn: String): string {
    let tempBook = this.books.find((b) => b.isbn == isbn);
    if (tempBook == undefined) {
      return `Book with isbn{${isbn}} not found`;;
    }

    this.books = this.books.filter((bookRef) => bookRef.isbn !== isbn);
    return `Book removed successfully`;
  }

  findBookByTitle(title: string) {
    let tempBook = this.books.find(b => b.title === title);
    if (tempBook == undefined) {
      return undefined;
    }

    return tempBook;

  }

  borrowBook(isbn: string, borrowedBooks: Book[]): string {
    let tempBook = this.books.find(b => b.isbn == isbn);
    // console.log(tempBook);

    if (tempBook == undefined) {
      return `Book with isbn{${isbn}} not found in books list`;
    } else if (tempBook.availableCopies == 0) {
      return `Copies of this book is over. Try again later...`;
    } else if (borrowedBooks.some(book => book.isbn == tempBook.isbn)) {
      return `You have already borrowed this book.You can borrow other books`;
    }

    tempBook.availableCopies -= 1;
    borrowedBooks.push(tempBook);
    return `Book borrowed successfully`;
  }

  returnBook(isbn: string, borrowedBooks: Book[]): string {
    // Find the book in the collection
    let tempBook = this.books.find(b => b.isbn === isbn);

    // Check if the book was found
    if (tempBook === undefined) {
      return `Book with ISBN ${isbn} not found in books list`;
    }

    // Check if the book is in the borrowedBooks list
    let index = borrowedBooks.findIndex(book => book.isbn === isbn);
    if (index !== -1) {
      // Return the book to the collection
      tempBook.availableCopies += 1;

      // Remove the book from the borrowedBooks array
      borrowedBooks.splice(index, 1);

      return `Book returned successfully`;
    } else {
      return `Book with ISBN ${isbn} was not borrowed`;
    }
  }

}
