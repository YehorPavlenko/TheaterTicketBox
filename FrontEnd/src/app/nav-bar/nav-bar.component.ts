import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';

@Component({
  selector: 'app-nav-bar',
  templateUrl: './nav-bar.component.html',
  styleUrls: ['./nav-bar.component.css']
})
export class NavBarComponent implements OnInit {

  constructor(private nav:Router) { }

  ngOnInit() {
  }

  Logout()
  {
    localStorage.removeItem('userToken');
    localStorage.removeItem('IsAdmin');
    localStorage.removeItem('Id');
    this.nav.navigate(['\login']);
  }
}
