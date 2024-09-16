import { Component, EventEmitter, Input, SimpleChanges } from '@angular/core';

@Component({
  selector: 'app-child',
  templateUrl: './child.component.html',
  styleUrls: ['./child.component.css'],
  outputs : ['cevent']
})
export class ChildComponent {
  @Input() data : any;
  ngOnChanges(changes : SimpleChanges){
    console.log(changes);
    
  }

  cevent : EventEmitter<string> = new EventEmitter<string>();

  onChange(value : string){
    this.cevent.emit(value);
  }

  hello(){
    alert("Hello World!");
  }
}
