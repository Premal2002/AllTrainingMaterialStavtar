import { Book } from "./Book";
import { Library } from "./Library";

export class User{
    name : string;
    email : string;
    borrowedBooks : Book[] = [];
    
    
    constructor(name : string, email : string){
        this.name = name;
        this.email = email;
        this.borrowedBooks = [];
    }

    borrowBook(isbn : string,library:Library) : string{
        return library.borrowBook(isbn,this.borrowedBooks);
    }

    returnBook(isbn : string,library:Library) : string{
        return library.returnBook(isbn,this.borrowedBooks);
    }
}