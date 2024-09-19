import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { AddInvoiceComponent } from '../add-invoice/add-invoice.component';
import { ListInvoicesComponent } from '../list-invoices/list-invoices.component';
import { ManageInvoiceComponent } from '../manage-invoice/manage-invoice.component';
import { ReactiveFormsModule } from '@angular/forms';
import { InvoiceRoutingModule } from './invoice-routing.module';



@NgModule({
  declarations: [
    AddInvoiceComponent,
    ListInvoicesComponent,
    ManageInvoiceComponent
  ],
  imports: [
    CommonModule,
    ReactiveFormsModule,
    InvoiceRoutingModule
  ],
  bootstrap :[ListInvoicesComponent]
})
export class InvoiceModule { }
