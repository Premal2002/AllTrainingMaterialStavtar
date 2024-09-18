import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { Currency } from 'src/app/currencies/currency.model';
import { CurrencyService } from 'src/app/currency.service';
import { InvoiceService } from 'src/app/invoice.service';
import { VendorService } from 'src/app/vendor.service';
import { Vendor } from 'src/app/vendors/vendor.model';
import { Invoice } from '../invoice.model';
import * as XLSX from 'xlsx';


@Component({
  selector: 'app-list-invoices',
  templateUrl: './list-invoices.component.html',
  styleUrls: ['./list-invoices.component.css']
})
export class ListInvoicesComponent {
  invoices: Invoice[] = [];
  vendors: Vendor[] = [];
  currencies: Currency[] = [];

  constructor(private invoiceService: InvoiceService,private router : Router,private vendorService: VendorService,private currencyService: CurrencyService) { }

  ngOnInit(): void {
    this.getInvoices();

     // Fetch vendor and currency data
     this.vendorService.getVendors().subscribe(data => {
      this.vendors = data;
    });
    this.currencyService.getCurrencies().subscribe(data => {
      this.currencies = data;
    });
  }

  getInvoices() {
    this.invoiceService.getInvoices().subscribe((data: any) => {
      this.invoices = data;
    }, (error) => {
      alert(error.error);
      console.error("Error fetching invoices", error);
    });
  }

  exportInvoices() {
    // this.invoiceService.exportInvoices().subscribe(() => {
    //   alert("Invoices exported successfully!");
    // }, (error) => {
    //   alert(error.error);
    //   console.error("Error exporting invoices", error);
    // });

    const ws = XLSX.utils.json_to_sheet(this.invoices);
    const wb = XLSX.utils.book_new();
    XLSX.utils.book_append_sheet(wb, ws, 'Invoices');
    XLSX.writeFile(wb, 'invoices.xlsx');
  }

  deleteInvoice(invoiceNumber: number) {
    if (confirm('Are you sure you want to delete this invoice?')) {
      this.invoiceService.deleteInvoice(invoiceNumber).subscribe(() => {
        alert('Invoice deleted successfully');
        this.router.navigateByUrl('/', { skipLocationChange: true }).then(() => {
          this.router.navigate(['manageInvoice/listInvoice']);
      });
        // this.getInvoices();
      }, (error) => {
        alert(error.error);
        console.error("Error deleting invoice", error);
      });
    }
  }

  updateInvoice(invoiceNumber: number) {
    // Redirect to update invoice form
    this.router.navigate([`manageInvoice/addInvoice/${invoiceNumber}`]);
  }

  getCurrencyName(currencyId: number): string {
    let cCode : string = "null";
    this.currencies.forEach(element => {
      if(element.currencyId == currencyId){
          cCode = element.currencyCode;
      }
    });
    return cCode; 
  }

  getVendorName(vendorId: number): string {
    let vName : string = "null";
    this.vendors.forEach(element => {
      if(element.vendorId == vendorId){
          vName = element.vendorLongName;
      }
    });
    return vName; 
  }

  onVendorChange(event : Event){
    const selectedVendorId = Number ((event.target as HTMLSelectElement).value);
    if (selectedVendorId) {
      this.invoiceService.getInvoices().subscribe((data: Invoice[]) => {
        this.invoices = data.filter(invoice => invoice.vendorId == selectedVendorId);
      }, (error) => {
        alert(error.error);
        console.error("Error fetching invoices", error);
      });
    }else{
      this.getInvoices();
    }
  }
}
