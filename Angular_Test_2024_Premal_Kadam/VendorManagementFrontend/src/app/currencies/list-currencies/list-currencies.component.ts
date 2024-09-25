import { Component, EventEmitter } from '@angular/core';
import { Router } from '@angular/router';
import { CurrencyService } from 'src/app/currency.service';
import { Currency } from '../currency.model';
import * as XLSX from 'xlsx';

@Component({
  selector: 'app-list-currencies',
  templateUrl: './list-currencies.component.html',
  styleUrls: ['./list-currencies.component.css']
})
export class ListCurrenciesComponent {
  currencies: Currency[] = [];
  pageNo : number = 1;
  totalPages : number;

  constructor(
    private currencyService: CurrencyService,
    private router: Router
  ) {}

  ngOnInit(): void {
    this.loadCurrencies();
  }

  loadCurrencies(): void {
    this.currencyService.getPaginatedCurrencies(this.pageNo).subscribe(data => {
      this.currencies = data.cList;
      this.totalPages =Math.ceil(data.count / 5);
    });
  }

  deleteCurrency(currencyCode: string): void {
    if (confirm('Are you sure you want to delete this currency?')) {
      this.currencyService.deleteCurrency(currencyCode).subscribe(() => {
        alert("Currency deleted successfully.")
        this.router.navigateByUrl('/failure', { skipLocationChange: true }).then(() => {
          this.router.navigate(['Currency/manageCurrency/listCurrency']);
      });
        // this.loadCurrencies(); 
      },err => {
        alert(err.error);
      });
    }
  }

  editCurrency(currencyCode: string): void {
    this.router.navigate([`Currency/manageCurrency/addCurrency/${currencyCode}`]);
  }

  exportCurrency(){
    const ws = XLSX.utils.json_to_sheet(this.currencies);
    const wb = XLSX.utils.book_new();
    XLSX.utils.book_append_sheet(wb, ws, 'Currencies');
    XLSX.writeFile(wb, 'currencies.xlsx');
  }


  next(){
    this.pageNo++; 
    this.loadCurrencies();
    
  }

  previous(){
    this.pageNo--;
    this.loadCurrencies();
  }
  
}
