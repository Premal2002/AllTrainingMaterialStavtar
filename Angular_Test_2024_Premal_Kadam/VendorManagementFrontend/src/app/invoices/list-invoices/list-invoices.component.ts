import { Component } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
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
  vFilter : number = 0;
  cFilter : number = 0;
  pageNo : number = 1;
  totalPages : number;

  constructor(private invoiceService: InvoiceService,private router : Router,private vendorService: VendorService,private currencyService: CurrencyService,private route : ActivatedRoute) { }

  ngOnInit(): void {
    // this.getInvoices();
    this.onChange();
    
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
          this.router.navigate(['Invoice/manageInvoice/listInvoice']);
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
    this.router.navigate([`Invoice/manageInvoice/addInvoice/${invoiceNumber}`]);
  }

  getCurrencyCode(currencyId: number): string {
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

  onChange(){
      this.invoiceService.getFilteredInvoices(this.cFilter,this.vFilter,this.pageNo).subscribe(data => {
        this.invoices = data.iList;
        this.totalPages =Math.ceil(data.count / 5);
      },err => {
        alert(err.error);
      })
    // }
  }

  backToInvoiceList(){
    this.router.navigateByUrl('/', { skipLocationChange: true }).then(() => {
      this.router.navigate(['Invoice/manageInvoice/listInvoice']);
  });
  }


  next(){
    this.pageNo++; 
    this.onChange();
    
  }

  previous(){
    this.pageNo--;
    this.onChange();
  }
}
