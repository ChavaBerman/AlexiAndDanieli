import { Component, OnInit } from '@angular/core';
import { UserService } from 'src/app/shared/imports';

@Component({
  selector: 'app-worker',
  templateUrl: './worker.component.html',
  styleUrls: ['./worker.component.css']
})
export class WorkerComponent implements OnInit {

  constructor(private userservice:UserService) { }

  ngOnInit() {
  }
  logOut() {
    //log out the user
    this.userservice.logout();
  }
}
