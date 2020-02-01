import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Hall } from './Hall.model';

@Injectable({
  providedIn: 'root'
})
export class HallService {

  readonly rootUrl = 'https://localhost:44310';
  constructor(private http:HttpClient) { }

  GetAllHalls()
  {
    return this.http.get<Hall[]>(this.rootUrl +'/Halls',
    {
      headers:new HttpHeaders()
      .set('Content-Type','application/json')
      });
  }
}
