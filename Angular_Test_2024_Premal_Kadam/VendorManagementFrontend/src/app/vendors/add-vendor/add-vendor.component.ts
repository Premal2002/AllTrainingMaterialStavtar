import { Component } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { VendorService } from 'src/app/vendor.service';
import { Vendor } from '../vendor.model';

@Component({
  selector: 'app-add-vendor',
  templateUrl: './add-vendor.component.html',
  styleUrls: ['./add-vendor.component.css']
})
export class AddVendorComponent {

    vendorForm : FormGroup;
    submitted : boolean = false;

    fromUpdate : boolean = false;

    constructor(private builder : FormBuilder,private router : Router,private vendorService : VendorService,private route : ActivatedRoute){}

    ngOnInit(): void {
      // Initializing the vendor form with validations
      this.vendorForm = this.builder.group({
        vendorCode: [
          '', 
          [Validators.required, Validators.pattern('^(?=.*[A-Za-z])(?=.*[0-9])[A-Za-z0-9_-]{3,10}$')] // Vendor code must be alphanumeric, 3-10 characters
        ],
        vendorLongName: [
          '', 
          [Validators.required, Validators.minLength(3)] // Vendor name must be at least 3 characters long
        ],
        vendorPhoneNumber: [
          '', 
          [Validators.required, Validators.pattern('^[0-9]{10}$')] // Contact number should be 10 digits
        ],
        vendorEmail: [
          '', 
          [Validators.required, Validators.email] // Validate email format
        ]
      });

      const vCode = this.route.snapshot.paramMap.get('vCode');
      if(vCode != '0'){
        this.fromUpdate = true;
        this.vendorService.getVendorByCode(vCode).subscribe(data => {
          this.vendorForm.patchValue(data);
        },err => {
          alert(err.error);
        });
      }
      
    }

    get form(){
      return this.vendorForm.controls;
    }

    handleSubmit(){
      this.submitted = true;

      if(this.vendorForm.valid){
        this.vendorService.addVendor(this.vendorForm.value).subscribe(data => {
          alert("Vendor added successfully");
          this.router.navigateByUrl('/', { skipLocationChange: true }).then(() => {
            this.router.navigate(['manageVendor/listVendor']);
        });
        }, err => {
          alert(err.error);
          console.log(err);
          
        });
      }
    }

    updateVendor(){
      this.submitted = true;
  
      if(this.vendorForm.valid){
        this.vendorService.updateVendor(this.vendorForm.value,this.vendorForm.get('vendorCode')?.value).subscribe(data => {
          alert("Vendor Edited successfully");
          this.router.navigateByUrl('/', { skipLocationChange: true }).then(() => {
            this.router.navigate(['manageVendor/listVendor']);
        });
          
        }, err => {
          alert(err.error);
          console.log(err.error);
          
        });
        
      }
    }
}