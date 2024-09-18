import { Component, OnInit } from '@angular/core';
import { VendorService } from 'src/app/vendor.service';
import { Vendor } from '../vendor.model';

@Component({
  selector: 'app-manage-vendor',
  templateUrl: './manage-vendor.component.html',
  styleUrls: ['./manage-vendor.component.css']
})
export class ManageVendorComponent {

  vendors : Vendor[] = [];
  totalVendors : number = 0;
  constructor(private vendorService : VendorService){}
  ngOnInit(): void {
    this.vendorService.getVendors().subscribe((data : Vendor[]) => {
      this.vendors = data;
      this.totalVendors = this.vendors.length;
    });
  }



}
