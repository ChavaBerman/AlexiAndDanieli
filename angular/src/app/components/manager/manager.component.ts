import { Component } from '@angular/core';
import { WorkerService } from '../../shared/services/worker.service';


@Component({
  selector: 'app-manager',
  templateUrl: './manager.component.html',
  styleUrls: ['./manager.component.css']
})
export class ManagerComponent  {

  currentWorker: boolean;

  constructor(private workerService: WorkerService) { }

  logOut() {
    //log out the worker
    this.workerService.logout();
   

  }
}
