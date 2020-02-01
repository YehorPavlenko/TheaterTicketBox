import { Component, OnInit } from '@angular/core';
import { Ticket } from 'src/shared/ticket.model';
import { TicketService } from 'src/shared/ticket.service';
import { HttpErrorResponse } from '@angular/common/http';

@Component({
  selector: 'app-my-tickets',
  templateUrl: './my-tickets.component.html',
  styleUrls: ['./my-tickets.component.css']
})
export class MyTicketsComponent implements OnInit {

  tickets:Ticket[] = new Array();
  errorMessage: any;
  constructor(private ticketService:TicketService) { }

  ngOnInit() {
    this.GetTickets(localStorage.getItem('Id'))
  }

  GetTickets(Id:string)
  {
    this.ticketService.GetTickets(Id).subscribe((data:any)=>
    {
      console.log(data);
      this.tickets = data;
    },
    (err:HttpErrorResponse)=>{
      this.errorMessage = err.error['error'];
      console.log(err);
    });
  }

  BuyTicket(id:number)
  {
      let t = new Ticket();
      t = this.tickets.find(x => x.Id == id);
      t .UserProfileId = localStorage.getItem('Id');
      t.Session = null;
      t .Status = "Bought";
      this.ticketService.UpdateTicket(t).subscribe((data:any)=>
      {
        console.log("TicketPut")
        this.ngOnInit();
     },
      (err:HttpErrorResponse)=>{
        this.errorMessage = err.error['error'];
        console.log(err);
      });
  }
  CancelTicket(id:number)
  {
      let t = new Ticket();
      t = this.tickets.find(x => x.Id == id);
      t .UserProfileId = localStorage.getItem('Id');
      t.Session = null;
      t .Status = "Canceled";
      this.ticketService.UpdateTicket(t).subscribe((data:any)=>
      {
        console.log("TicketPut")
        this.ngOnInit();
     },
      (err:HttpErrorResponse)=>{
        this.errorMessage = err.error['error'];
        console.log(err);
      });
  }

}
