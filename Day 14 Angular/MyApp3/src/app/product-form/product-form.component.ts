import { Component } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { forbiddenNameValidator } from '../myValidators';
import { DataSharingService } from '../data-sharing.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-product-form',
  templateUrl: './product-form.component.html',
  styleUrls: ['./product-form.component.css']
})
export class ProductFormComponent {
  registerForm : FormGroup;
    submitted : boolean = false;

    constructor(private builder : FormBuilder, private service : DataSharingService,private router : Router){}

    ngOnInit(){
      this.registerForm = this.builder.group({
        name : ['',[Validators.required, Validators.minLength(3)]],
        price : ['',Validators.required],
        description : ['',[Validators.required,Validators.minLength(5)]],
      });
    }

    get form(){
      return this.registerForm.controls;
    }

    handleSubmit(){
      this.submitted = true;

      if(this.registerForm.valid){
        console.log(this.registerForm.value);
        this.service.addproduct(this.registerForm.value);
        alert("Product added successfully");
        this.router.navigate(['list']);
      }
    }
}
