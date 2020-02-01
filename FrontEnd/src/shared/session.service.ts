import { Injectable } from '@angular/core';
import {HttpClient, HttpHeaders} from '@angular/common/http';
import { Session } from './session.model';
import { Ticket } from './ticket.model';


@Injectable({
  providedIn: 'root'
})
export class SessionService {

  readonly rootUrl = 'https://localhost:44310';
  constructor(private http:HttpClient) { }


  GetAllSessions()
  {
    return this.http.get<Session[]>(this.rootUrl +'/Sessions',
    {
      headers:new HttpHeaders()
      .set('Content-Type','application/json')
      });
  }
  CreateSession(session:Session)
  {
    return this.http.post<string>(this.rootUrl +'/Sessions',JSON.stringify(session),{
      headers:new HttpHeaders()
      .set('Content-Type','application/json')
      });
  }
  RemoveSession(Id:number)
  {
    return this.http.delete<string>(this.rootUrl + '/Sessions/' + Id,
    {
      headers:new HttpHeaders()
      .set('Content-Type','application/json')
      });
  }
  GetSession(Id:number)
  {
    return this.http.get<Session>(this.rootUrl + '/Sessions/' + Id,
    {
    headers:new HttpHeaders()
      .set('Content-Type','application/json')
      });
  }
 
}
