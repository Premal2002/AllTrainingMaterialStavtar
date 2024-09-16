export class User{
    id : string;
    name : string;
    email:string;
    country : string;

    constructor(id : string, name : string, email:string, country : string){
        this.id = id;
        this.name = name;
        this.email = email;
        this.country = country;
    }
}