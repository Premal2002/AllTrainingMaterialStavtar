import { Component } from '@angular/core';

@Component({
  selector: 'app-data-binding',
  templateUrl: './data-binding.component.html',
  styleUrls: ['./data-binding.component.css']
})
export class DataBindingComponent {
    name : string = "Premal kadam";
    imgURL : string = "https://th.bing.com/th/id/OIP.HH1stuszQE_PPB2HPYGlPQAAAA?rs=1&pid=ImgDetMain";
    height : number = 200;
    message:string = "Welcome";
    isActive:boolean = true;
    bgColor : boolean = true;
    onClick() : void {
      alert("This is an basic example of event binding");
    }
    
    removeClasses():void{
      this.isActive = !this.isActive;
      this.bgColor = !this.bgColor;
      this.imgURL = "https://i.ytimg.com/vi/jMe6D5i-Fw8/maxresdefault.jpg";
    }
}
