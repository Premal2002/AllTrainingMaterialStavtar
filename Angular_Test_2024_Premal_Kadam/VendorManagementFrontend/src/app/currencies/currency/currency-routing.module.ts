import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { ManageCurrencyComponent } from 'src/app/currencies/manage-currency/manage-currency.component';
import { AddCurrencyComponent } from 'src/app/currencies/add-currency/add-currency.component';
import { ListCurrenciesComponent } from 'src/app/currencies/list-currencies/list-currencies.component';


const routes: Routes = [ 
  {path : '', redirectTo : "manageCurrency/listCurrency", pathMatch : "full"},
  {path : 'manageCurrency', component : ManageCurrencyComponent,children : [
    {path : 'addCurrency/:cCode', component : AddCurrencyComponent},
    {path : 'listCurrency', component : ListCurrenciesComponent},
  ]}
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class CurrencyRoutingModule { }