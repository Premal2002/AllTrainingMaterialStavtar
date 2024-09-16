import { Component } from '@angular/core';
import { DataSharingService } from '../data-sharing.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-product-list',
  templateUrl: './product-list.component.html',
  styleUrls: ['./product-list.component.css']
})
export class ProductListComponent {

  products : any[];

  constructor(private service : DataSharingService,private router : Router){}

  ngOnInit(){
    this.products = this.service.getAllProducts();
  }

  details(id : number){
      this.router.navigate([`details/${id}`]);
  }
}
