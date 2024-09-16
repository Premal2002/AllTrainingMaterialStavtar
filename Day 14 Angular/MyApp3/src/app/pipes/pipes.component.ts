import { Component } from '@angular/core';

@Component({
  selector: 'app-pipes',
  templateUrl: './pipes.component.html',
  styleUrls: ['./pipes.component.css']
})
export class PipesComponent {
  name : string = "premal";
  pi : number = 3.14156789;

  salary : number = 40000;

  today : Date = new Date();

  obj = {id : 1, name : "Prem", email : "prem@gmail.com"};

  message : string = "My name is Prem";
}
