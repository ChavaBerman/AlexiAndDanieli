import { Component, OnInit } from '@angular/core';
import { UserService } from '../../shared/services/user.service';
import { Router } from '@angular/router';


@Component({
  selector: 'app-manager',
  templateUrl: './manager.component.html',
  styleUrls: ['./manager.component.css']
})
export class ManagerComponent implements OnInit {

  currentuser: boolean;

  constructor(private userservice: UserService,private router:Router) { }

  ngOnInit() {
    //take value from local storage 
    if (localStorage['currentuser'])
      this.currentuser = true;
  }

  logOut() {
    //log out the user
    this.userservice.logout();
   

  }
}
