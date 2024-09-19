import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { ManageVendorComponent } from '../manage-vendor/manage-vendor.component';
import { AddVendorComponent } from '../add-vendor/add-vendor.component';
import { ListVendorsComponent } from '../list-vendors/list-vendors.component';
import { ManageInvoiceComponent } from 'src/app/invoices/manage-invoice/manage-invoice.component';
import { AddInvoiceComponent } from 'src/app/invoices/add-invoice/add-invoice.component';
import { ListInvoicesComponent } from 'src/app/invoices/list-invoices/list-invoices.component';
import { ManageCurrencyComponent } from 'src/app/currencies/manage-currency/manage-currency.component';
import { AddCurrencyComponent } from 'src/app/currencies/add-currency/add-currency.component';
import { ListCurrenciesComponent } from 'src/app/currencies/list-currencies/list-currencies.component';


const routes: Routes = [
    {path : '', redirectTo : "manageVendor/listVendor", pathMatch : "full"},
    {path: 'manageVendor', component: ManageVendorComponent, children : [
    {path : 'addVendor/:vCode', component : AddVendorComponent},
    {path : 'listVendor', component : ListVendorsComponent},
  ] },
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class VendorRoutingModule { }