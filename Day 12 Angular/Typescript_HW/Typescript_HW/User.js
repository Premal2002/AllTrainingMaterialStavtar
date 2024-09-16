"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
exports.User = void 0;
class User {
    constructor(name, email) {
        this.borrowedBooks = [];
        this.name = name;
        this.email = email;
        this.borrowedBooks = [];
    }
    borrowBook(isbn, library) {
        return library.borrowBook(isbn, this.borrowedBooks);
    }
    returnBook(isbn, library) {
        return library.returnBook(isbn, this.borrowedBooks);
    }
}
exports.User = User;
