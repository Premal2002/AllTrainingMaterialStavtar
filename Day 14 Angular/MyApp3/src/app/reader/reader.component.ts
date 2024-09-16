import { Component } from '@angular/core';
import { SubscriptionService } from '../subscription.service';

@Component({
  selector: 'app-reader',
  templateUrl: './reader.component.html',
  styleUrls: ['./reader.component.css']
})
export class ReaderComponent {
  constructor(private service : SubscriptionService){}

  ngOnInit(){
    this.service.message.subscribe(msg=>console.log(msg));

  }
}
