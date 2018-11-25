import { Component, OnInit } from '@angular/core';
import { UserService } from 'src/app/shared/imports';
import { Router } from '@angular/router';

@Component({
  selector: 'app-team-head',
  templateUrl: './team-head.component.html',
  styleUrls: ['./team-head.component.css']
})
export class TeamHeadComponent implements OnInit {
  currentuser: boolean;

  constructor(private userservice: UserService, private router: Router) { }

  ngOnInit() {
    //take value from local storage 
    if (localStorage['currentuser']!=null)
      this.currentuser = true;
  }

  logOut() {
    //log out the user
    this.userservice.logout();
  }
}
