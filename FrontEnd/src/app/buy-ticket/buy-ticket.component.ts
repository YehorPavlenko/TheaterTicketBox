import { Component, OnInit } from '@angular/core';
import {ActivatedRoute, Router} from '@angular/router'
import { Session } from 'src/shared/session.model'
import { SessionService } from 'src/shared/session.service';
import { HttpErrorResponse } from '@angular/common/http';
import { Seat } from 'src/shared/seat.mode';
import { Ticket } from 'src/shared/ticket.model';
import { find } from 'rxjs/operators';
import { element } from 'protractor';
import { TicketService } from 'src/shared/ticket.service';

@Component({
  selector: 'app-buy-ticket',
  templateUrl: './buy-ticket.component.html',
  styleUrls: ['./buy-ticket.component.css']
})


export class BuyTicketComponent implements OnInit {

  sessionId:number;
  session:Session;
  errorMessage: any;
  seats:Ticket[][];
  tickets:Ticket[] = new Array();
  price:number;
  
  constructor(private service:SessionService,private rout:ActivatedRoute,private ticketService:TicketService,private nav:Router) { 
  
  }

  ngOnInit() {
    this.sessionId = parseInt(this.rout.snapshot.paramMap.get('id')); 
    this.price = 0;
    this.GetSession(this.sessionId);
 }
  

ChooseTicket(Id:number)
{
  let t = this.session.Tickets.find(item => item.Id == Id);
  if(!this.tickets.includes(t))
  {
    this.tickets.push(t);
    this.price += t.Price;
    this.price = parseFloat(this.price.toFixed(2));
  
  }
  else
  {
    t = this.tickets.find(item => item.Id == Id)
   var newtickets = this.tickets.filter(item => item.Id != t.Id);
   this.tickets = newtickets;
    this.price -= t.Price;
    this.price = parseFloat(this.price.toFixed(2));
  }

}

  GetSession(Id:number)
  {
    this.service.GetSession(Id).subscribe((data:any)=>
    {
      this.session = data;
      console.log('SessionGet');
      this.seats = [];
      for(var i: number = 0,k:number = 0; i < this.session.Hall.NumberOfRows; i++) {
        this.seats[i] = [];
        for(var j: number = 0; j< this.session.Hall.NumberOfSeatsInRow; j++) {
          this.seats[i][j] = this.session.Tickets[k];
          k++;
        }
    }
    },
    (err:HttpErrorResponse)=>{
      this.errorMessage = err.error['error'];
      console.log(err);
    });
  }
  BuyTickets()
  {
  
    for(var i = 0;i < this.tickets.length;i++)
    {
      this.tickets[i].UserProfileId = localStorage.getItem('Id');
      this.tickets[i].Status = "Bought";
      this.ticketService.UpdateTicket(this.tickets[i]).subscribe((data:any)=>
      {
        console.log(data)
     },
      (err:HttpErrorResponse)=>{
        this.errorMessage = err.error['error'];
        console.log(err);
      });
    }
    this.tickets = new Array();
    this.price = 0;
  }
  BookTickets()
  {
    
    for(var i = 0;i < this.tickets.length;i++)
    {
      this.tickets[i].UserProfileId = localStorage.getItem('Id');
      this.tickets[i].Status = "Booking";
      this.ticketService.UpdateTicket(this.tickets[i]).subscribe((data:any)=>
      {
        console.log(data)  
      },
      (err:HttpErrorResponse)=>{
        this.errorMessage = err.error['error'];
        console.log(err);
      });;
      }
      this.tickets = new Array();
      this.price = 0;
  }
  
}
