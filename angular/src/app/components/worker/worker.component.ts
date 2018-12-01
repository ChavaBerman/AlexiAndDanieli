import { Component } from '@angular/core';
import { WorkerService } from 'src/app/shared/imports';

@Component({
  selector: 'app-worker',
  templateUrl: './worker.component.html',
  styleUrls: ['./worker.component.css']
})
export class WorkerComponent {

  constructor(private workerService: WorkerService) { }

  logOut() {
    //log out the worker
    this.workerService.logout();
  }
}
