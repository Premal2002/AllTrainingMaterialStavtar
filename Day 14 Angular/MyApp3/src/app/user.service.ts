import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { catchError, map, Observable, of, retry } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class UserService {

  constructor(private http : HttpClient) { }

  baseURL : string = "https://jsonplaceholder.typicode.com/users";

  getAllUsers() : Observable<any[]> {
    return this.http.get<any[]>(this.baseURL).pipe(
      retry(3),
      map(response=><any[]>response),
      catchError(error=>{
        console.log(error);
        return of([]);
        
      })
    );
  }
}
