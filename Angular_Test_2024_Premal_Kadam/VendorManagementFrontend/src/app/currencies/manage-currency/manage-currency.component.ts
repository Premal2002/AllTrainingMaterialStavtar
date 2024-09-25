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
  totalCurrencies : number = 0;
  constructor(private currencService : CurrencyService){}

  ngOnInit(): void {
    this.currencService.getPaginatedCurrencies(1).subscribe((data : any) => {
      this.totalCurrencies = data.count;
    });
  }
}
