import { Component, OnInit } from '@angular/core';
import { Task, TaskService, User, UserService } from 'src/app/shared/imports';

@Component({
  selector: 'app-my-tasks',
  templateUrl: './my-tasks.component.html',
  styleUrls: ['./my-tasks.component.css']
})
export class MyTasksComponent implements OnInit {

  myTasks:Array<Task>;
  worker:User;

  constructor(private taskService:TaskService,private userService:UserService) { 
   this.worker= this.userService.getCurrentUser();
  }

  ngOnInit() {
    this.taskService.GetTasksWithUserAndProjectByUserId(this.worker.userId).subscribe((res)=>{
      this.myTasks=res;
    })
  }

}
