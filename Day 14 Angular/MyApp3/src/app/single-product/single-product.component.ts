import { Component } from '@angular/core';
import { DataSharingService } from '../data-sharing.service';
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-single-product',
  templateUrl: './single-product.component.html',
  styleUrls: ['./single-product.component.css']
})
export class SingleProductComponent {
  product: any;

  constructor(private service: DataSharingService, private route : ActivatedRoute) { }

  ngOnInit(){
    const id = Number(this.route.snapshot.paramMap.get('id'));
    this.product = this.service.getById(id);
  }
}
