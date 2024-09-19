import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { ManageVendorComponent } from './vendors/manage-vendor/manage-vendor.component';
import { AddVendorComponent } from './vendors/add-vendor/add-vendor.component';
import { ListVendorsComponent } from './vendors/list-vendors/list-vendors.component';
import { ManageInvoiceComponent } from './invoices/manage-invoice/manage-invoice.component';
import { AddInvoiceComponent } from './invoices/add-invoice/add-invoice.component';
import { ListInvoicesComponent } from './invoices/list-invoices/list-invoices.component';
import { ListCurrenciesComponent } from './currencies/list-currencies/list-currencies.component';
import { AddCurrencyComponent } from './currencies/add-currency/add-currency.component';
import { ManageCurrencyComponent } from './currencies/manage-currency/manage-currency.component';

const routes: Routes = [
  {path : '', redirectTo : "manageVendor/listVendor", pathMatch : "full"},
  {path : 'manageVendor', component : ManageVendorComponent,children : [
    {path : 'addVendor/:vCode', component : AddVendorComponent},
    {path : 'listVendor', component : ListVendorsComponent},
  ]},
  {path : 'manageInvoice', component : ManageInvoiceComponent,children : [
    {path : 'addInvoice/:iNumber', component : AddInvoiceComponent},
    {path : 'listInvoice', component : ListInvoicesComponent},
  ]},
  {path : 'manageCurrency', component : ManageCurrencyComponent,children : [
    {path : 'addCurrency/:cCode', component : AddCurrencyComponent},
    {path : 'listCurrency', component : ListCurrenciesComponent},
  ]}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
