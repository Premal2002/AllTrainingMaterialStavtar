import { HttpClient, HttpClientModule } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { User } from './user/user.model';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class UserServiceService {
  baseURL : string = "http://localhost:3000/users";

  constructor(private http : HttpClient) { }

  getAllUsers():Observable<User[]>{
    return this.http.get<User[]>(this.baseURL);
  }

  addUser(user:User)  : Observable<User>{
    return this.http.post<User>(this.baseURL,user);
  }

  getById(id:string | null) : Observable<User>{
    return this.http.get<User>(this.baseURL+'/'+id);
  }

  updateById(id:string,user : User){
    this.http.put<User>(this.baseURL+"/"+id,user);
  }

  deleteById(id:string) : Observable<void>{
    return this.http.delete<void>(this.baseURL+"/"+id);
  }

}
