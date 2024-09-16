import { HttpClient } from '@angular/common/http';
import { Component } from '@angular/core';
import { MaterialExampleComponent } from './material-example/material-example.component';
import { TableComponent } from './table/table.component';
import { PaginationComponent } from './pagination/pagination.component';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css'],
  standalone : true,
  imports : [MaterialExampleComponent,TableComponent,PaginationComponent]
})
export class AppComponent {
  title = 'Testing';

  constructor(private http : HttpClient){}

  ngOnInit(){
    this.http.get("https://jsonplaceholder.typicode.com/users/1").subscribe(data=>{
      console.log(data);
    });
  }
}
