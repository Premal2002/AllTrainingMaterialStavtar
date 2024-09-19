import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { AddCurrencyComponent } from '../add-currency/add-currency.component';
import { ListCurrenciesComponent } from '../list-currencies/list-currencies.component';
import { ManageCurrencyComponent } from '../manage-currency/manage-currency.component';
import { ReactiveFormsModule } from '@angular/forms';
import { CurrencyRoutingModule } from './currency-routing.module';
import { HttpClientModule } from '@angular/common/http';



@NgModule({
  declarations: [
    AddCurrencyComponent,
    ListCurrenciesComponent,
    ManageCurrencyComponent
  ],
  imports: [
    CommonModule,
    HttpClientModule,
    ReactiveFormsModule,
    CurrencyRoutingModule

  ],
  // bootstrap : [ListCurrenciesComponent]
})
export class CurrencyModule { }
