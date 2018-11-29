import { Component, OnInit } from '@angular/core';
import { WorkerService } from 'src/app/shared/imports';
import { Router } from '@angular/router';

@Component({
  selector: 'app-team-head',
  templateUrl: './team-head.component.html',
  styleUrls: ['./team-head.component.css']
})
export class TeamHeadComponent implements OnInit {
  currentWorker: boolean;

  constructor(private workerService: WorkerService, private router: Router) { }

  ngOnInit() {
    //take value from local storage 
    if (localStorage['currentWorker']!=null)
      this.currentWorker = true;
  }

  logOut() {
    //log out the worker
    this.workerService.logout();
  }
}
