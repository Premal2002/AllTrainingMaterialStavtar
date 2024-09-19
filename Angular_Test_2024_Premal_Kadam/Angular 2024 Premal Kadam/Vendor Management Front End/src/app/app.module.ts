import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { ManageVendorComponent } from './vendors/manage-vendor/manage-vendor.component';
import { AddVendorComponent } from './vendors/add-vendor/add-vendor.component';
import { ManageInvoiceComponent } from './invoices/manage-invoice/manage-invoice.component';
import { AddInvoiceComponent } from './invoices/add-invoice/add-invoice.component';
import { ManageCurrencyComponent } from './currencies/manage-currency/manage-currency.component';
import { AddCurrencyComponent } from './currencies/add-currency/add-currency.component';
import { HttpClientModule } from "@angular/common/http";
import { ListVendorsComponent } from './vendors/list-vendors/list-vendors.component';
import { ReactiveFormsModule } from '@angular/forms';
import { ListInvoicesComponent } from './invoices/list-invoices/list-invoices.component';
import { ListCurrenciesComponent } from './currencies/list-currencies/list-currencies.component';


@NgModule({
  declarations: [
    AppComponent,
    ManageVendorComponent,
    AddVendorComponent,
    ManageInvoiceComponent,
    AddInvoiceComponent,
    ManageCurrencyComponent,
    AddCurrencyComponent,
    ListVendorsComponent,
    ListInvoicesComponent,
    ListCurrenciesComponent,
    
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    ReactiveFormsModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
