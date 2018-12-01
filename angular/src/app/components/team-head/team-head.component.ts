import { Component } from '@angular/core';
import { WorkerService } from 'src/app/shared/imports';

@Component({
  selector: 'app-team-head',
  templateUrl: './team-head.component.html',
  styleUrls: ['./team-head.component.css']
})
export class TeamHeadComponent  {

  constructor(private workerService: WorkerService) { }

  logOut() {
    //log out the worker
    this.workerService.logout();
  }

}
