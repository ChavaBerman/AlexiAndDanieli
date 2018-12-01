import { Component, OnInit } from '@angular/core';
import { Worker, WorkerService, Task, TaskService } from 'src/app/shared/imports';

@Component({
  selector: 'app-update-hours',
  templateUrl: './update-hours.component.html',
  styleUrls: ['./update-hours.component.css']
})
export class UpdateHoursComponent implements OnInit {

  teamHead: Worker;
  myWorkers: Array<Worker>;
  currentWorker: Worker;
  currentWorkerTasks: Array<Task> = null;

  constructor(private workerService: WorkerService, private taskService: TaskService) {
    //get current team head:
    this.teamHead = this.workerService.getCurrentWorker();
  }

  ngOnInit() {
    //get all workers witch belong to current team head:
    this.workerService.getAllWorkersByTeamHead(this.teamHead.workerId).subscribe((res) => {
      this.myWorkers = res;
      this.currentWorker = this.myWorkers[0];
      this.GetTasks();
    });

  }
  changeWorker(event: Event) {
    //get selested  worker:
    let selectedOptions = event.target['options'];
    this.currentWorker = this.myWorkers[selectedOptions.selectedIndex];
    this.GetTasks();

  }
  GetTasks() {
    //get all selected worker's tasks;
    this.taskService.getTasksWithWorkerAndProjectByWorkerId(this.currentWorker.workerId).subscribe((res) => {
      this.currentWorkerTasks = res;
    });
  }

}
