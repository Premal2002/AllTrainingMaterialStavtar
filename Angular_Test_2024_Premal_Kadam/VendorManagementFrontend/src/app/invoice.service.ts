import { HttpClient, HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Invoice } from './invoices/invoice.model';

@Injectable({
  providedIn: 'root'
})
export class InvoiceService {

  private apiUrl = 'http://localhost:5274/api/Invoice';

  constructor(private http: HttpClient) {}

  getInvoices(): Observable<Invoice[]> {
    return this.http.get<Invoice[]>(this.apiUrl);
  }

  // getInvoicesByVendor(vCode : string): Observable<Invoice[]> {
  //   return this.http.get<Invoice[]>(this.apiUrl+"/getByVendor/"+vCode);
  // }

  // getInvoicesByCurrency(cCode : string): Observable<Invoice[]> {
  //   return this.http.get<Invoice[]>(this.apiUrl+"/getByCurrency/"+cCode);
  // }

  getFilteredInvoices(cId : number,vId : number,pageNo : number): Observable<any> {
    return this.http.get<Invoice[]>(`${this.apiUrl}/getFilteredInvoices/${cId}/${vId}/${pageNo}`);
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
