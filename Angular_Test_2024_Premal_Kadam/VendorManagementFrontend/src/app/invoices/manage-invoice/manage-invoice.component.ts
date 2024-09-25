import { Component } from '@angular/core';
import { Invoice } from '../invoice.model';
import { InvoiceService } from 'src/app/invoice.service';

@Component({
  selector: 'app-manage-invoice',
  templateUrl: './manage-invoice.component.html',
  styleUrls: ['./manage-invoice.component.css']
})
export class ManageInvoiceComponent {
  invoices : Invoice[] = [];
  totalInvoices : number = 0;
  constructor(private invoiceService : InvoiceService){}
  ngOnInit(): void {
    this.invoiceService.getFilteredInvoices(0,0,1).subscribe((data : any) => {
      this.totalInvoices = data.count;
    });
  }
}
