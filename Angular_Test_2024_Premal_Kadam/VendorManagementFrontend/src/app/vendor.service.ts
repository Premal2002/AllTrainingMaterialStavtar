import { HttpClient, HttpErrorResponse } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { catchError, Observable, throwError } from 'rxjs';
import { Vendor } from './vendors/vendor.model';

@Injectable({
  providedIn: 'root'
})
export class VendorService {

  private apiUrl = 'https://localhost:7217/api/Vendor'; 

  constructor(private http: HttpClient) {}

  getVendors(): Observable<Vendor[]> {
    return this.http.get<Vendor[]>(`${this.apiUrl}`);
  }

  getPaginatedVendors(pageNo : number): Observable<any> {
    return this.http.get<Vendor[]>(`${this.apiUrl}/${pageNo}`);
  }

  getVendorByCode(vCode : string | null): Observable<Vendor> {
    return this.http.get<Vendor>(`${this.apiUrl}/getVendorByCode/${vCode}`);
  }

  addVendor(vendor: Vendor): Observable<any> {
    return this.http.post(this.apiUrl, vendor);
  }

  updateVendor(vendor: Vendor, vendorCode: string ): Observable<any> {
    return this.http.put(`${this.apiUrl}/${vendorCode}`, vendor);
  }

  deleteVendor(vendorCode: string): Observable<any> {
    return this.http.delete(`${this.apiUrl}/${vendorCode}`);
  }
  exportVendors(): Observable<any> {
    return this.http.post(`${this.apiUrl}/export`,{});
  }

  

  // private handleError(error: HttpErrorResponse) {
  //   let errorMessage = '';

  //   // if (error.error instanceof ErrorEvent) {
  //   //   // Client-side or network error
  //   //   errorMessage = `Client-side error: ${error.error.message}`;
  //   // } else {
  //   //   // Server-side error
  //   //   errorMessage = `Server error: ${error.status}\nMessage: ${error.message}`;
  //   // }

  //   // // Optionally, you can display the error message in the UI using an alert or toast notification
  //   // console.error(errorMessage);

  //   // // Return an observable with a user-facing error message
  //   alert(error.error);
  //   return throwError(() => new Error(error.error));
  // }
}
