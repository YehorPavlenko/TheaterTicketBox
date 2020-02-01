import { Injectable } from '@angular/core';
import { Ticket } from './ticket.model';
import { HttpClient, HttpHeaders } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class TicketService {
  readonly rootUrl = 'https://localhost:44310';
  constructor(private http:HttpClient) { }

  UpdateTicket(ticket:Ticket)
  {
    return this.http.put<string>(this.rootUrl +'/Tickets/' + ticket.Id,JSON.stringify(ticket),{
      headers:new HttpHeaders()
      .set('Content-Type','application/json')
      });
  }
  BookTicket(ticket:Ticket)
  {
    return this.http.put<string>(this.rootUrl +'/Tickets/' + ticket.Id,JSON.stringify(ticket),{
      headers:new HttpHeaders()
      .set('Content-Type','application/json')
      });
  }
  GetTickets(Id:string)
  {
    return this.http.get<Ticket>(this.rootUrl + '/Users/' + Id + '/Tickets',
    {
    headers:new HttpHeaders()
      .set('Content-Type','application/json')
      });
  }
}
