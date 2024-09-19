import { Component, ViewChild } from '@angular/core';
import { CurrencyService } from 'src/app/currency.service';
import { Currency } from '../currency.model';
import { ListCurrenciesComponent } from '../list-currencies/list-currencies.component';

@Component({
  selector: 'app-manage-currency',
  templateUrl: './manage-currency.component.html',
  styleUrls: ['./manage-currency.component.css']
})
export class ManageCurrencyComponent {
  currencies : Currency[] = [];
  totalCurrencies : number = 0;
  constructor(private currencService : CurrencyService){}

  ngOnInit(): void {
    this.currencService.getCurrencies().subscribe((data : Currency[]) => {
      this.currencies = data;
      this.totalCurrencies = this.currencies.length;
    });
  }
}
