import { Component } from '@angular/core';
import { UserService } from '../user.service';

@Component({
  selector: 'app-user-list',
  templateUrl: './user-list.component.html',
  styleUrls: ['./user-list.component.css']
})
export class UserListComponent {
  userList : any[];
  constructor(private service : UserService){}

  ngOnInit(){
    this.service.getAllUsers().subscribe(data=>{
      this.userList = data;
    });
  }
}
