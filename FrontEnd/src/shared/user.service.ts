import { Injectable } from '@angular/core';
import {HttpClient, HttpHeaders} from '@angular/common/http';
import {Observable} from 'rxjs';
import { User } from './user.model';
import { userLogin } from './userRegistration.model';
 
@Injectable({
  providedIn: 'root'
})
export class UserService {
  readonly rootUrl = 'https://localhost:44310';
  constructor(private http:HttpClient) { }

  registrateUser(user:User)
  {
     return this.http.post<string>(this.rootUrl +'/Registrate',JSON.stringify(user),{
      headers:new HttpHeaders()
      .set('Content-Type','application/json')
      });
  }

  userAuthentication(user:userLogin)
  {
    let data = "username="+user.Email+"&password="+user.Password+"&grant_type=password";
    let header = new HttpHeaders({"Content-Type":"application/x-www-urlencoded"});
    return this.http.post(this.rootUrl+'/token',data,{headers:header});
  }

  getUserId(email:string)
  {
    return this.http.get(this.rootUrl+'/User/GetId?Email='+email,
    {headers:new HttpHeaders()
      .set('Content-Type','application/json')
      });
  }

  CheckIsAdmin(email:string)
  {
    return this.http.get(this.rootUrl+'/User/IsAdmin?Email='+email,
    {headers:new HttpHeaders()
      .set('Content-Type','application/json')
      });
    }
  }
