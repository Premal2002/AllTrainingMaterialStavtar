import { Injectable } from '@angular/core';
import { BehaviorSubject } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class SubscriptionService {
  // constructor() { }
  private currentMessage = new BehaviorSubject<string>("Initial Message");
  message = this.currentMessage.asObservable();

  changeMessage(msg : string){
    this.currentMessage.next(msg);
  }
  
}
