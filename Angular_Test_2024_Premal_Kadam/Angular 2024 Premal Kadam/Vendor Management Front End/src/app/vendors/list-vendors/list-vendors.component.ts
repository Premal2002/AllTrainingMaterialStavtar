import { Component } from '@angular/core';
import { Vendor } from '../vendor.model';
import { VendorService } from 'src/app/vendor.service';
import { Router } from '@angular/router';
import * as XLSX from 'xlsx';

@Component({
  selector: 'app-list-vendors',
  templateUrl: './list-vendors.component.html',
  styleUrls: ['./list-vendors.component.css']
})
export class ListVendorsComponent {
  vendors : Vendor[] = [];
  constructor(private vendorService : VendorService,private router : Router){}
  ngOnInit(): void {
    this.getVendors();
  }

  getVendors(){
    this.vendorService.getVendors().subscribe((data : Vendor[]) => {
      this.vendors = data;
    });
  }

  deleteVendor(vendorCode : string){
    this.vendorService.deleteVendor(vendorCode).subscribe(data => {
      alert("Vendor deleted successfully");
      this.router.navigateByUrl('manageInvoice/listInvoice', { skipLocationChange: true }).then(() => {
        this.router.navigate(['manageVendor/listVendor']);
    });
    },err => {
      alert(err.error);
    });
   
  }


  updateVendor(vCode : string){
    this.router.navigate([`manageVendor/addVendor/${vCode}`]);
  }

  //export vendors
  exportVendors() {
    //this is backend api
    // this.vendorService.exportVendors().subscribe(data => {
    //   alert("Vendors List Exported Successfully");
    // },err => {
    //   alert(err.error);
    // });

    const ws = XLSX.utils.json_to_sheet(this.vendors);
    const wb = XLSX.utils.book_new();
    XLSX.utils.book_append_sheet(wb, ws, 'Vendors');
    XLSX.writeFile(wb, 'vendors.xlsx');
  }
}
