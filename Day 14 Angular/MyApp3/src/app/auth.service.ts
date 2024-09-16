import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class AuthService {

  // constructor() { }

  private loggedIn = false;

  isLoggedIn() : boolean{
    return this.loggedIn;
  }

  logIn():void{
    this.loggedIn = true;
  }

  logOut() : void{
    this.loggedIn = false;
  }
}
