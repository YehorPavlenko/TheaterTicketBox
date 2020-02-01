import { Component, OnInit } from '@angular/core';
import { User } from 'src/shared/user.model';
import { HttpClient } from '@angular/common/http';
import { UserService } from 'src/shared/user.service';
import { NgForm } from '@angular/forms';
import { Router } from '@angular/router';

@Component({
  selector: 'app-sign-up',
  templateUrl: './sign-up.component.html',
  styleUrls: ['./sign-up.component.css']
})
export class SignUpComponent implements OnInit {
user:User
 

  constructor(private userService:UserService,private nav:Router) { 
  
  }

  ngOnInit() {
    this.user = new User();
  }

  
  public Registrate()
  {
  this.userService.registrateUser(this.user).subscribe(
    (resp)=>{
      console.log(resp);
      alert("You were registrated");
      this.nav.navigate(['\login']);
    },
  )}
}
