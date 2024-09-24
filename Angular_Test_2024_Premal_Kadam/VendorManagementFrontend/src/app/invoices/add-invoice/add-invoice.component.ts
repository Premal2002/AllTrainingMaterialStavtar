import { Component } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { CurrencyService } from 'src/app/currency.service';
import { InvoiceService } from 'src/app/invoice.service';
import { dueDateValidator } from 'src/app/myvalidator';
import { VendorService } from 'src/app/vendor.service';

@Component({
  selector: 'app-add-invoice',
  templateUrl: './add-invoice.component.html',
  styleUrls: ['./add-invoice.component.css']
})
export class AddInvoiceComponent {
  invoiceForm: FormGroup;
  fromUpdate: boolean = false;
  submitted: boolean = false;
  vendors: any[] = [];
  currencies: any[] = [];
  recDate : Date = new Date();
  // invoiceId: number | null = null;

  constructor(
    private fb: FormBuilder,
    private invoiceService: InvoiceService,
    private vendorService: VendorService,
    private currencyService: CurrencyService,
    private router: Router,
    private route: ActivatedRoute
  ) { }

  ngOnInit(): void {
    this.initializeForm();


    // Fetch vendor and currency data
    this.vendorService.getVendors().subscribe(data => {
      this.vendors = data;
    });
    this.currencyService.getCurrencies().subscribe(data => {
      this.currencies = data;
    });

    const iNumber = Number(this.route.snapshot.paramMap.get('iNumber'));
      if(iNumber != 0){
        this.fromUpdate = true;
        this.invoiceService.getInvoiceByNumber(iNumber).subscribe(data => {
          // debugger;
          this.recDate = new Date(data.invoiceReceivedDate);
          this.initializeForm();
          
          this.invoiceForm.patchValue(data);
          
          let date : Date  = new Date(data.invoiceDueDate.toString().split('T')[0]);
          let dateStr : string = this.getFormattedString(date);
          this.invoiceForm.get('invoiceDueDate')?.setValue(dateStr);
 
        },err => {
          alert(err.error);
        });
      }
  }

  //used in html
  get form(){
    return this.invoiceForm.controls;
  }

  //get date in yyyy-MM-dd format
  getFormattedString(date:Date)  : string {
    return date.getFullYear()+"-"+String(date.getMonth()+1).padStart(2,'0')  +"-"+String(date.getDate()).padStart(2,'0');
  }

  initializeForm(): void {
    // debugger;
    this.invoiceForm = this.fb.group({
      invoiceNumber: ['', [Validators.required, Validators.pattern('^[0-9]+$')]],
      currencyId: ['', Validators.required],
      vendorId: ['', Validators.required],
      invoiceAmount: ['', [Validators.required, Validators.pattern('^[0-9]+(\\.[0-9]{1,2})?$')]],
      invoiceDueDate: ['', [Validators.required, dueDateValidator(this.recDate)]],
      isActive: [true]
    }); 
    
  }




  handleSubmit(): void {
    this.submitted = true;
    if (this.invoiceForm.invalid) {
      return;
    }

    this.invoiceService.addInvoice(this.invoiceForm.value).subscribe(
    () =>  {
      alert("Invoice added successfully");
      this.router.navigateByUrl('/failure', { skipLocationChange: true }).then(() => {
        this.router.navigate(['Invoice/manageInvoice/listInvoice']);
    });
  },
      error => {
        alert(error.error);
        // console.error('Error adding invoice', error)
      }
    );
  }

  updateInvoice(): void {
    this.submitted = true;
  
      if(this.invoiceForm.valid){
        this.invoiceService.updateInvoice(this.invoiceForm.value,this.invoiceForm.get('invoiceNumber')?.value).subscribe(data => {
          alert("Invoice Edited successfully");
          this.router.navigateByUrl('/failure', { skipLocationChange: true }).then(() => {
            this.router.navigate(['Invoice/manageInvoice/listInvoice']);
        });
          
        }, err => {
          alert(err.error);
          // console.log(err.error);
        });
        
      }
  }
}
