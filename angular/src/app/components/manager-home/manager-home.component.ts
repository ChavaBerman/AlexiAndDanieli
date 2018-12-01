import { Component, OnInit } from '@angular/core';
import {Worker, WorkerService } from '../../shared/imports';


@Component({
  selector: 'app-manager-home',
  templateUrl: './manager-home.component.html',
  styleUrls: ['./manager-home.component.css']
})
export class ManagerHomeComponent {
  currentWorker:Worker;
  constructor(private workerService:WorkerService) { 
    this.workerService.currentWorkerSubject.subscribe(
      {
        next: (worker:Worker) => this.currentWorker=worker
      }
    );
  }
}
