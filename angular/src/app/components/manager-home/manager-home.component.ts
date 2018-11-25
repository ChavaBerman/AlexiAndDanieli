import { Component, OnInit } from '@angular/core';
import {User, UserService } from '../../shared/imports';


@Component({
  selector: 'app-manager-home',
  templateUrl: './manager-home.component.html',
  styleUrls: ['./manager-home.component.css']
})
export class ManagerHomeComponent implements OnInit {
  currentUser:User;
  constructor(private userService:UserService) { 
    this.userService.currentUserSubject.subscribe(
      {
        next: (user:User) => this.currentUser=user
      }
    );
  }

  ngOnInit() {
  }

}
