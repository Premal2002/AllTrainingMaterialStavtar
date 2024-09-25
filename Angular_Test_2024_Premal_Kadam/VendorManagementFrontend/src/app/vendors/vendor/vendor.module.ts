import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { AddVendorComponent } from '../add-vendor/add-vendor.component';
import { ListVendorsComponent } from '../list-vendors/list-vendors.component';
import { ManageVendorComponent } from '../manage-vendor/manage-vendor.component';
import { VendorRoutingModule } from './vendor-routing.module';
import { HttpClientModule } from '@angular/common/http';
import { ReactiveFormsModule } from '@angular/forms';



@NgModule({
  declarations: [
    AddVendorComponent,
    ListVendorsComponent,
    ManageVendorComponent
  ],
  imports: [
    CommonModule,
    HttpClientModule,
    ReactiveFormsModule,
    VendorRoutingModule,
  ],
  // bootstrap: [ListVendorsComponent]
})
export class VendorModule { }
