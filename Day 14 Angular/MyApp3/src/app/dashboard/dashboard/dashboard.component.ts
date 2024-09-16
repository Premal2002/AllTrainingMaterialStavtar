import { Component } from '@angular/core';
import { Observable } from 'rxjs';
import { CanComponentDeactivate } from 'src/app/test-guard.guard';

@Component({
  selector: 'app-dashboard',
  templateUrl: './dashboard.component.html',
  styleUrls: ['./dashboard.component.css']
})
export class DashboardComponent implements CanComponentDeactivate {

  unsavedChanges : boolean = true;

  CanDeactivate(): Observable<boolean> | Promise<boolean> | boolean {
    if(this.unsavedChanges){
      return confirm("do you really want to leave");
    }
    return true;
  }
}
