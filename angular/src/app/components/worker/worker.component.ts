import { Component, OnInit } from '@angular/core';
import { WorkerService } from 'src/app/shared/imports';

@Component({
  selector: 'app-worker',
  templateUrl: './worker.component.html',
  styleUrls: ['./worker.component.css']
})
export class WorkerComponent implements OnInit {

  constructor(private workerService:WorkerService) { }

  ngOnInit() {
  }
  logOut() {
    //log out the worker
    this.workerService.logout();
  }
}
