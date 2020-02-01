import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { PerformanceService } from 'src/shared/performance.service';
import { HttpErrorResponse, HttpClient } from '@angular/common/http';
import { Route } from '@angular/compiler/src/core';
import { Performance } from 'src/shared/performance.model';

@Component({
  selector: 'app-repertory',
  templateUrl: './repertory.component.html',
  styleUrls: ['./repertory.component.css']
})
export class RepertoryComponent implements OnInit {

  performances:Performance[]
  errorMessage: any;
  selectedFile:File = null;
  role:boolean;

  constructor(private service:PerformanceService,private http:HttpClient,private nav:Router) 
  {
    if(localStorage.getItem('IsAdmin') == 'true')
    {
      this.role = true;
    }
    else this.role = false;
   }

  ngOnInit() {
    this.GetAllPerformances();
  }

  GetAllPerformances()
  {
    this.service.GetAllPerformance().subscribe((data:any)=>
    {
      this.performances = data;
      console.log("PerformancesGet")
    },
    (err:HttpErrorResponse)=>{
      this.errorMessage = err.error['error'];
      console.log(err);
    });
  }
  RemovePerformance(Id:number)
  {
    this.service.RemovePerformance(Id).subscribe((data:any)=>
    {
      console.log(data);
      this.ngOnInit();
    },
    (err:HttpErrorResponse)=>{
      this.errorMessage = err.error['error'];
      console.log(err);
    });
  }
  LoadPhoto(event)
  {
    this.selectedFile = <File>event.target.files[0];
  }

  onUpload(Id:number)
  {
    const fd = new FormData();
    fd.append('image',this.selectedFile,this.selectedFile.name)
    this.http.patch('https://localhost:44310/Performances/' + Id,fd)
    .subscribe(res=>{
      console.log(res);
      this.ngOnInit();
    });
  }

}

