export class Todo{
    id : number;
    task : string;
    status : string;

    constructor( id : number, task : string, status : string){
        this.id = id;
        this.task = task;
        this.status = status;
    }
}