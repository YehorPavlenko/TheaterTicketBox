import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { SessionService } from 'src/shared/session.service';
import { HttpErrorResponse, HttpClient } from '@angular/common/http';
import { Session } from 'src/shared/session.model';


@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent implements OnInit {

  sessions:Session[];
  errorMessage: any;
  role:boolean;

  constructor(private service:SessionService,private http:HttpClient,private nav:Router) 
  {
    if(localStorage.getItem('IsAdmin') == 'true')
    {
      this.role = true;
    }
    else this.role = false;
  }

  ngOnInit() {
   return this.GetAllSessions();
  
  }

GetAllSessions()
{
  this.service.GetAllSessions().subscribe((data:any)=>
  {
    this.sessions = data;
    console.log("SessionsGet")
  },
  (err:HttpErrorResponse)=>{
    this.errorMessage = err.error['error'];
    console.log(err);
  });
}
RemoveSession(Id:number)
{
  this.service.RemoveSession(Id).subscribe((data:any)=>
  {
    console.log(data);
    this.ngOnInit();
  },
  (err:HttpErrorResponse)=>{
    this.errorMessage = err.error['error'];
    console.log(err);
  });
}
BuyTicket(session:Session)
{
  this.nav.navigate(['/sessions',session.Id] );
}
BookTicket(session:Session)
{
  this.nav.navigate(['/session',session.Id]);
}
}
