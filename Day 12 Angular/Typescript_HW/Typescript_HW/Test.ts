import { Book } from "./Book";
import { Library } from "./Library";
import { User } from "./User";
let library: Library = new Library();

console.log("------------------------------------------------------------------------");
console.log(library.addBook(new Book("DSA", "ABC", "123dsa", 5)));
console.log(library.addBook(new Book("Angular", "XYZ", "dsa", 5)));
console.log(library.addBook(new Book("The Pragmatic Programmer", "Andrew Hunt and David Thomas", "978-0201616224", 1)));
console.log(library.addBook(new Book("Clean Code", "Robert C. Martin", "978-0132350884", 2)));
console.log(library.addBook(new Book("Design Patterns: Elements of Reusable Object-Oriented Software", "Erich Gamma, Richard Helm, Ralph Johnson, and John Vlissides", "978-0201633610", 1)));
// library.addBook(new Book("Introduction to Algorithms", "Thomas H. Cormen, Charles E. Leiserson, Ronald L. Rivest, and Clifford Stein", "978-0262033848", 4));
// library.addBook(new Book("You Don't Know JS", "Kyle Simpson", "978-1491904244", 15));
// library.addBook(new Book("JavaScript: The Good Parts", "Douglas Crockford", "978-0596517748", 20));
// library.addBook(new Book("Effective Java", "Joshua Bloch", "978-0134685991", 1));
// library.addBook(new Book("The Art of Computer Programming", "Donald E. Knuth", "978-0201896831", 8));
// library.addBook(new Book("Sapiens: A Brief History of Humankind", "Yuval Noah Harari", "978-0062316097", 9));
// library.addBook(new Book("Educated", "Tara Westover", "978-0399590504", 11));
console.log("------------------------------------------------------------------------");
//list of books
library.books.forEach(element => {
    console.log(`Book Title : ${element.title}, Book Author : ${element.author}, Book isbn : ${element.isbn}, Book Available Copies : ${element.availableCopies}`);
});

//removing book
console.log("------------------------------------------------------------------------");

// console.log(library.removeBook("123dsa"));
// console.log(library.removeBook("123dsa")); // error message -- working
//find book by a title

console.log("------------------------------------------------------------------------");
let book = library.findBookByTitle("DSA");
if (book == undefined) {
    console.log("Book not found!!!");
}
else {
    console.log(`Book Title : ${book.title}, Book Author : ${book.author}, Book isbn : ${book.isbn}`);
}

console.log("------------------------------------------------------------------------");

//user operations 
let user : User = new User("sdf","ds");

//borrow a book //978-0201616224
console.log(user.borrowBook("978-0201616224",library));
console.log(user.borrowBook("978-0201616224",library)); // gives error copies not avaialable
user.borrowedBooks.forEach(element => {
  console.log("User Borrowed books");
  
  console.log(`Book Title : ${element.title}, Book Author : ${element.author}, Book isbn : ${element.isbn}, Book Available Copies : ${element.availableCopies}`); 
});
console.log("------------------------------------------------------------------------");

console.log(user.returnBook("978-0201616224",library));

console.log("------------------------------------------------------------------------");

user.borrowedBooks.forEach(element => {
  console.log("User Borrowed books");
  console.log(`Book Title : ${element.title}, Book Author : ${element.author}, Book isbn : ${element.isbn}, Book Available Copies : ${element.availableCopies}`); 
});

// console.log("------------------------------------------------------------------------");
// let book1 = library.findBookByTitle("The Pragmatic Programmer");
// if (book1 == undefined) {
//     console.log("Book not found!!!");
// }
// else {
//     console.log(`Book Title : ${book1.title}, Book Author : ${book1.author}, Book isbn : ${book1.isbn}, Book Available Copies : ${book1.availableCopies}`);
// }

console.log(user.borrowBook("978-0201616224",library));


