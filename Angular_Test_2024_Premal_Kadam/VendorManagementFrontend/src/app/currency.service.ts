import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Currency } from './currencies/currency.model';

@Injectable({
  providedIn: 'root'
})
export class CurrencyService {

  private apiUrl = 'https://localhost:7217/api/Currency';

  constructor(private http: HttpClient) {}

  getCurrencies(): Observable<Currency[]> {
    return this.http.get<Currency[]>(this.apiUrl);
  }

  getCurrencyByCode(cCode : string | null): Observable<Currency> {
    return this.http.get<Currency>(`${this.apiUrl}/getCurrencyByCode/${cCode}`);
  }

  addCurrency(currency: Currency): Observable<any> {
    return this.http.post(this.apiUrl, currency);
  }

  updateCurrency(currency: Currency, currencyCode: string): Observable<any> {
    return this.http.put(`${this.apiUrl}/${currencyCode}`, currency);
  }

  deleteCurrency(currencyCode: string): Observable<any> {
    return this.http.delete(`${this.apiUrl}/${currencyCode}`);
  }

  exportCurrency(): Observable<any> {
    return this.http.post(`${this.apiUrl}/export`,{});
  }
}
