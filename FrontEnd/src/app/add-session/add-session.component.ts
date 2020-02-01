import { Component, OnInit } from '@angular/core';
import { Hall } from 'src/shared/Hall.model';
import { HallService } from 'src/shared/hall.service';
import { HttpClient, HttpErrorResponse } from '@angular/common/http';
import { Router } from '@angular/router';
import { PerformanceService } from 'src/shared/performance.service';
import { SessionService } from 'src/shared/session.service';
import { Session } from 'src/shared/session.model';

@Component({
  selector: 'app-add-session',
  templateUrl: './add-session.component.html',
  styleUrls: ['./add-session.component.css']
})
export class AddSessionComponent implements OnInit {

  halls:Hall[]
  errorMessage: any;
  performances:Performance[];
  PerformanceId:number;
  HallId:number;
  session:Session
 
  constructor(private HallService:HallService,private PerformanceService:PerformanceService,private SessionService:SessionService
    ,private http:HttpClient,private nav:Router) {
      
    }

  ngOnInit() {
    this.GetAllHalls();
    this.GetAllPerformances();
    this.session = new Session();
  }

  GetAllPerformances()
  {
    this.PerformanceService.GetAllPerformance().subscribe((data:any)=>
    {
      this.performances = data;
      console.log("PerfromancesGet")
    },
    (err:HttpErrorResponse)=>{
      this.errorMessage = err.error['error'];
      console.log(err);
    });
  }
  GetAllHalls()
  {
    this.HallService.GetAllHalls().subscribe((data:any)=>
    {
      this.halls = data;
      console.log("HallGet")
    },
    (err:HttpErrorResponse)=>{
      this.errorMessage = err.error['error'];
      console.log(err);
    });
  }
  CreateSession()
  {
    this.SessionService.CreateSession(this.session).subscribe((data:any)=>
    {
      console.log(data);
      this.nav.navigate(['/sessions']);
    },
    (err:HttpErrorResponse)=>{
      this.errorMessage = err.error['error'];
      console.log(err);
    });
  }
  SelectHall(event:any)
  {
    this.session.HallId = event.target.value;
  }
  SelectPerformance(event:any)
  {
    this.session.PerformanceId = event.target.value;
  }

}
