import { Component, ElementRef, ViewChild } from '@angular/core';
import { ChildComponent } from './child/child.component';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  title = 'myApp2';
  cdata : string ="";

  @ViewChild("inputData")
  inputEl! : ElementRef;

  @ViewChild(ChildComponent)
  child! : ChildComponent;

  
  // ngAfterViewInit(){
  //   // this.inputEl.nativeElement.focus();
  //   this.child.hello();
  // }
}
