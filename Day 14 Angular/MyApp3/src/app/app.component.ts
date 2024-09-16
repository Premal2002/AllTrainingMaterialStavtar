import { Component } from '@angular/core';
import { SubscriptionService } from './subscription.service';
import { AuthService } from './auth.service';
import { Router } from '@angular/router';
import { CanComponentDeactivate } from './test-guard.guard';
import { Observable } from 'rxjs';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent{
  title = 'MyApp3';

  // constructor(private service : SubscriptionService){}

  // ngOnInit(){
  //   this.service.changeMessage("Welcome from App Component");
  // }

  loggedIn : boolean = false;


  constructor(private authService : AuthService,private router : Router){}

  

  ngDoCheck(){
    this.loggedIn = this.authService.isLoggedIn();
  }

  logout(){
    this.authService.logOut();
    this.router.navigate(['login']);
  }
}
