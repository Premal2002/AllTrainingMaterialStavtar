import { Pipe, PipeTransform } from "@angular/core";


//custom pipes
@Pipe({name : "changeString"})
export class CustomPipe implements PipeTransform {
    transform(value : any, character : string){
        return value.split(' ').join(character);
    }
}