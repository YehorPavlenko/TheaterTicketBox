import { Component, OnInit } from '@angular/core';
import { UserService } from 'src/shared/user.service';
import { Router } from '@angular/router';
import { userLogin } from 'src/shared/userRegistration.model';
import { HttpErrorResponse } from '@angular/common/http';

@Component({
  selector: 'app-sign-in',
  templateUrl: './sign-in.component.html',
  styleUrls: ['./sign-in.component.css']
})
export class SignInComponent implements OnInit {
  user:userLogin
  errorMessage:string;  

  constructor(private userService:UserService,private nav:Router)
  {
    this.user = new userLogin();
   }

  ngOnInit() {
  }

  Authenticate()
  {
    this.userService.userAuthentication(this.user).subscribe((data:any)=>
    {
      localStorage.setItem('userToken',data.access_token);
      this.userService.CheckIsAdmin(this.user.Email).subscribe((data:any)=>
      {
       if(data == true)
       {
       this.nav.navigate(['/sessions']);
       localStorage.setItem('IsAdmin','true')
       }
       else{ this.nav.navigate(['/sessions'])
       localStorage.setItem('IsAdmin','false')
      }
      })
      this.userService.getUserId(this.user.Email).subscribe((data:any)=>{
      localStorage.setItem('Id',data)})
   },
    (err:HttpErrorResponse)=>{
      this.errorMessage = err.error['error'];
      console.log(err);
    });
   
   
  }
}
