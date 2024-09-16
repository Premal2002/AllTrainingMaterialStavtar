import { Component } from '@angular/core';

@Component({
  selector: 'app-directive',
  templateUrl: './directive.component.html',
  styleUrls: ['./directive.component.css']
})
export class DirectiveComponent {
  flag : boolean = false;

  students =[
    {id : 1, name : "Prem", city : "Thane",percentage : 25},
    {id : 2, name : "Sandip", city : "Mumbai",percentage : 45},
    {id : 3, name : "Saurabh", city : "Delhi",percentage : 20},
    {id : 4, name : "DJ", city : "Satara",percentage : 60},
    {id : 5, name : "Harsh", city : "Thane",percentage : 85}
  ]

  input : number = 1;

  change():void {
    this.flag = !this.flag;
  }
}
