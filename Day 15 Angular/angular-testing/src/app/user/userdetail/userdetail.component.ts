import { Component } from '@angular/core';
import { ActivatedRoute, ActivatedRouteSnapshot, Router } from '@angular/router';
import { User } from '../user.model';
import { UserServiceService } from 'src/app/user-service.service';

@Component({
  selector: 'app-userdetail',
  templateUrl: './userdetail.component.html',
  styleUrls: ['./userdetail.component.css']
})
export class UserdetailComponent {
  user : User;
  constructor(private route : ActivatedRoute,private userService : UserServiceService){}

  ngOnInit(){
    const id = this.route.snapshot.paramMap.get("id");
    this.userService.getById(id).subscribe(data => {
      this.user = data;
    })
  }
}
