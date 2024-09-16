import { Component } from '@angular/core';

@Component({
  selector: 'app-register-component',
  templateUrl: './register-component.component.html',
  styleUrls: ['./register-component.component.css']
})
export class RegisterComponentComponent {
  user = {
    name : '',
    email : '',
    password : ''
  };

  onSubmit(form : any){
    if(form.valid){
      console.log(this.user);
      
    }
  }
}
