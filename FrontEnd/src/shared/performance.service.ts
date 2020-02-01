import { Injectable } from '@angular/core';
import {HttpClient, HttpHeaders} from '@angular/common/http';
import { headersToString } from 'selenium-webdriver/http';
import { Performance } from 'src/shared/performance.model';

@Injectable({
  providedIn: 'root'
})
export class PerformanceService {

  readonly rootUrl = 'https://localhost:44310';
  constructor(private http:HttpClient) { }

  GetAllPerformance()
  {
    return this.http.get<Performance[]>(this.rootUrl +'/Performances',
    {
      headers:new HttpHeaders()
      .set('Content-Type','application/json')
      });
  }
  
  RemovePerformance(Id:number)
  {
    return this.http.delete<string>(this.rootUrl + '/Performances/' + Id,
    {
      headers:new HttpHeaders()
      .set('Content-Type','application/json')
      });
  }
  CreatePerformance(performance:Performance)
  {
    return this.http.post<string>(this.rootUrl +'/Performances',JSON.stringify(performance),{
      headers:new HttpHeaders()
      .set('Content-Type','application/json')
      });
  }
}
