import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { ManageInvoiceComponent } from 'src/app/invoices/manage-invoice/manage-invoice.component';
import { AddInvoiceComponent } from 'src/app/invoices/add-invoice/add-invoice.component';
import { ListInvoicesComponent } from 'src/app/invoices/list-invoices/list-invoices.component';


const routes: Routes = [
  {path : '', redirectTo : "manageInvoice/listInvoice", pathMatch : "full"},
  {path : 'manageInvoice', component : ManageInvoiceComponent,children : [
    {path : 'addInvoice/:iNumber', component : AddInvoiceComponent},
    {path : 'listInvoice', component : ListInvoicesComponent},
  ]},

];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class InvoiceRoutingModule { }