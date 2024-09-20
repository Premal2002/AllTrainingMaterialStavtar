import { Component } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { CurrencyService } from 'src/app/currency.service';

@Component({
  selector: 'app-add-currency',
  templateUrl: './add-currency.component.html',
  styleUrls: ['./add-currency.component.css']
})
export class AddCurrencyComponent {
  currencyForm: FormGroup;
  submitted = false;
  fromUpdate = false; // Flag to check whether we are in update mode or add mode

  constructor(private formBuilder: FormBuilder,private route : ActivatedRoute,private currencyService : CurrencyService,private router : Router) { }

  ngOnInit(): void {
    this.currencyForm = this.formBuilder.group({
      currencyCode: ['', [Validators.required, Validators.pattern('^[A-Z]{3}$')]], // ISO code pattern
      currencyName: ['', [Validators.required, Validators.minLength(4)]]
    });

    const cCode = this.route.snapshot.paramMap.get('cCode');
      if(cCode != '0'){
        this.fromUpdate = true;
        this.currencyService.getCurrencyByCode(cCode).subscribe(data => {
          this.currencyForm.patchValue(data);
        },err => {
          alert(err.error);
        });
      }
  }

  get form() {
    return this.currencyForm.controls;
  }

  handleSubmit(): void {
    this.submitted = true;
    if(this.currencyForm.valid){
        this.currencyService.addCurrency(this.currencyForm.value).subscribe(data => {
          alert("Currency added successfully");
          this.router.navigateByUrl('/failure', { skipLocationChange: true }).then(() => {
            this.router.navigate(['Currency/manageCurrency/listCurrency']);
        });
        }, err => {
          alert(err.error);
          console.log(err);
        });
      }
  }

  updateCurrency(): void {
    this.submitted = true;
    if(this.currencyForm.valid){
      this.currencyService.updateCurrency(this.currencyForm.value,this.currencyForm.get('currencyCode')?.value).subscribe(data => {
        alert("Currency Edited successfully");
        this.router.navigateByUrl('/failure', { skipLocationChange: true }).then(() => {
          this.router.navigate(['Currency/manageCurrency/listCurrency']);
      });
        
      }, err => {
        alert(err.error);
        // console.log(err.error);
        
      });
      
    }
  }
}
