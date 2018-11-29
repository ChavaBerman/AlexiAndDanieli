import { Component, OnInit } from '@angular/core';
import { Worker, WorkerService, Task, TaskService } from 'src/app/shared/imports';

@Component({
  selector: 'app-update-hours',
  templateUrl: './update-hours.component.html',
  styleUrls: ['./update-hours.component.css']
})
export class UpdateHoursComponent implements OnInit {

  teamHead:Worker;
  myWorkers:Array<Worker>;
  currentWorker:Worker;
  currentWorkerTasks:Array<Task>=null;

  constructor(private workerService:WorkerService,private taskService:TaskService) { 
  this.teamHead= this.workerService.getCurrentWorker();
  }

  ngOnInit() {
    this.workerService.getAllWorkersByTeamHead(this.teamHead.workerId).subscribe((res)=>{
      this.myWorkers=res;
       this.currentWorker = this.myWorkers[0];
    this.GetTasks();
    }); 
   
  }
  changeWorker(event:Event){
    let selectedOptions = event.target['options'];
    this.currentWorker = this.myWorkers[selectedOptions.selectedIndex];
   this.GetTasks();

  }
  GetTasks(){
    this.taskService.GetTasksWithWorkerAndProjectByWorkerId(this.currentWorker.workerId).subscribe((res)=>{
      this.currentWorkerTasks=res;
    });
  }

}
