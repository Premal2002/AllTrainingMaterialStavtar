import { Component } from '@angular/core';
import { UserServiceService } from 'src/app/user-service.service';
import { User } from '../user.model';
import { Router } from '@angular/router';

@Component({
  selector: 'app-userlist',
  templateUrl: './userlist.component.html',
  styleUrls: ['./userlist.component.css']
})
export class UserlistComponent {

  users : User[] = [];
  constructor(private userService : UserServiceService,private router : Router){}

  ngOnInit(){
    this.fetchData()
  }

  fetchData(){
    this.userService.getAllUsers().subscribe(data =>this.users = data);
  }

  removeUser(id : string) {
    this.userService.deleteById(id).subscribe(data => {
      alert("Product removed succssfully");
      this.fetchData();
    });
    
  }
  
}
