import { HttpClient, HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Invoice } from './invoices/invoice.model';

@Injectable({
  providedIn: 'root'
})
export class InvoiceService {

  private apiUrl = 'https://localhost:7217/api/Invoice';

  constructor(private http: HttpClient) {}

  getInvoices(): Observable<Invoice[]> {
    return this.http.get<Invoice[]>(this.apiUrl);
  }

  getInvoicesByVendor(vCode : string,invoices : Invoice[]): Observable<Invoice[]> {
    // const params = new HttpParams().set('myList', JSON.stringify(invoices));
    return this.http.get<Invoice[]>(this.apiUrl+"/getByVendor/"+vCode);
  }

  getInvoicesByCurrency(cCode : string,invoices : Invoice[]): Observable<Invoice[]> {
    // const params = new HttpParams().set('myList', JSON.stringify(invoices));
    return this.http.get<Invoice[]>(this.apiUrl+"/getByCurrency/"+cCode);
  }

  getInvoiceByNumber(iNumber : number | null): Observable<Invoice> {
    return this.http.get<Invoice>(`${this.apiUrl}/getInvoiceByNumber/${iNumber}`);
  }

  addInvoice(invoice: Invoice): Observable<any> {
    return this.http.post(this.apiUrl, invoice);
  }

  updateInvoice(invoice: Invoice, invoiceId: number): Observable<any> {
    return this.http.put(`${this.apiUrl}/${invoiceId}`, invoice);
  }

  deleteInvoice(invoiceId: number): Observable<any> {
    return this.http.delete(`${this.apiUrl}/${invoiceId}`);
  }

  exportInvoices(): Observable<any> {
    return this.http.post(`${this.apiUrl}/export`,{});
  }
}
