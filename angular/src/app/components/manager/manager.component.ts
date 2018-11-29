import { Component, OnInit } from '@angular/core';
import { WorkerService } from '../../shared/services/worker.service';
import { Router } from '@angular/router';


@Component({
  selector: 'app-manager',
  templateUrl: './manager.component.html',
  styleUrls: ['./manager.component.css']
})
export class ManagerComponent implements OnInit {

  currentWorker: boolean;

  constructor(private workerService: WorkerService,private router:Router) { }

  ngOnInit() {
    //take value from local storage 
    if (localStorage['currentWorker'])
      this.currentWorker = true;
  }

  logOut() {
    //log out the worker
    this.workerService.logout();
   

  }
}
