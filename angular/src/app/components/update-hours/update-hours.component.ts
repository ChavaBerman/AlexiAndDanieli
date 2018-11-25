import { Component, OnInit } from '@angular/core';
import { User, UserService, Task, TaskService } from 'src/app/shared/imports';

@Component({
  selector: 'app-update-hours',
  templateUrl: './update-hours.component.html',
  styleUrls: ['./update-hours.component.css']
})
export class UpdateHoursComponent implements OnInit {

  teamHead:User;
  myWorkers:Array<User>;
  currentWorker:User;
  currentWorkerTasks:Array<Task>=null;

  constructor(private userService:UserService,private taskService:TaskService) { 
  this.teamHead= this.userService.getCurrentUser();
  }

  ngOnInit() {
    this.userService.getAllWorkersByTeamHead(this.teamHead.userId).subscribe((res)=>{
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
    this.taskService.GetTasksWithUserAndProjectByUserId(this.currentWorker.userId).subscribe((res)=>{
      this.currentWorkerTasks=res;
    });
  }

}
