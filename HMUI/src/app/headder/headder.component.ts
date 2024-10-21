import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import {  LoginService } from '../shared/http/login.service'


@Component({
  selector: 'app-headder',
  templateUrl: './headder.component.html',
  styleUrls: ['./headder.component.scss']
})
export class HeadderComponent implements OnInit {
Rooms: any;

  constructor(
    private router: Router,
    private login :  LoginService,
  ) { }

  public userRole : any
  public user : any;
  
  


  ngOnInit(): void {
  
    this.userRole = sessionStorage.getItem('userRole');
    this.user = sessionStorage.getItem('loggedInUser'); 

  }

  onLogout() {
      this.login.onlogOut();
  }
}
