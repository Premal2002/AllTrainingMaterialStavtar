import { Component } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { forbiddenNameValidator } from '../myValidators';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css']
})
export class RegisterComponent {
    registerForm : FormGroup;
    submitted : boolean = false;

    constructor(private builder : FormBuilder){}

    ngOnInit(){
      this.registerForm = this.builder.group({
        firstName : ['',Validators.required],
        lastName : ['',Validators.required],
        email : ['',[Validators.required,Validators.email]],
        username : ['',[Validators.required, forbiddenNameValidator('admin')]],
        password : ['',[Validators.required,Validators.minLength(6)]],
        gender : ['',Validators.required]

      });
    }

    get form(){
      return this.registerForm.controls;
    }

    handleSubmit(){
      this.submitted = true;
    }


}
