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
import { AppComponent } from './app.component';
import { FailureComponent } from './failure/failure.component';

const routes: Routes = [
  {path : '', loadChildren: () => import('./vendors/vendor/vendor.module').then(m => m.VendorModule)},
  {path : 'Invoice',  loadChildren:() => import('./invoices/invoice/invoice.module').then(m => m.InvoiceModule)},
  {path : 'Currency',  loadChildren:() => import('./currencies/currency/currency.module').then(m => m.CurrencyModule)},
  {path : 'failure', component : FailureComponent}
 
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
