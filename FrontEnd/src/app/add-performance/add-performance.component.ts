import { Component, OnInit } from '@angular/core';
import { Performance } from 'src/shared/performance.model';
import { User } from 'src/shared/user.model';
import { PerformanceService } from 'src/shared/performance.service';
import { Router } from '@angular/router';
import { HttpErrorResponse } from '@angular/common/http';

@Component({
  selector: 'app-add-performance',
  templateUrl: './add-performance.component.html',
  styleUrls: ['./add-performance.component.css']
})
export class AddPerformanceComponent implements OnInit {

  performance:Performance
  errorMessage: any;
  constructor(private service:PerformanceService,private nav:Router) { }

  ngOnInit() {
    this.performance = new Performance();
  }

  CreatePerformance()
  {
    this.service.CreatePerformance(this.performance).subscribe((data:any)=>
    {
      console.log(data);
      this.nav.navigate(['/repertory']);
    },
    (err:HttpErrorResponse)=>{
      this.errorMessage = err.error['error'];
      console.log(err);
    });
  }

}
