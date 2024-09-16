import { Component } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { UserServiceService } from 'src/app/user-service.service';


@Component({
  selector: 'app-userform',
  templateUrl: './userform.component.html',
  styleUrls: ['./userform.component.css']
})
export class UserformComponent {
  userForm: FormGroup;
  submitted: boolean = false;
  constructor(private builder: FormBuilder, private router: Router,
    private service: UserServiceService
  ) { }
  ngOnInit() {
    this.userForm = this.builder.group({
      name: ['', Validators.required],
      email: ['', Validators.required],
      country: ['', Validators.required],
    })
  }
  get form() {
    return this.userForm.controls;
  }
  handleSubmit() {
    this.submitted = true;
    if (this.userForm.valid) {
      const user=this.userForm.value;
      user.id=Date.now()+"";
      this.service.addUser(user).subscribe(
        (resp) => {
          alert('User Added Successfully');
          this.router.navigate(['userList']);
        }
      )
    }
  }
}
