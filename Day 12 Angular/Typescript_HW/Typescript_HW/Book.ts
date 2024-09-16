export class Book{
    title : string;
    author : string;
    isbn : string;
    availableCopies : number;

    constructor(title : string, author : string, isbn : string, availableCopies : number){
        this.title = title;
        this.author = author;
        this.isbn = isbn;
        this.availableCopies = availableCopies;
    }

}