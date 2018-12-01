import { Component, OnInit, Input } from '@angular/core';
import { Task } from 'src/app/shared/imports';

@Component({
  selector: 'app-task-details-for-worker',
  templateUrl: './task-details-for-worker.component.html',
  styleUrls: ['./task-details-for-worker.component.css']
})
export class TaskDetailsForWorkerComponent  {

  @Input()
  task:Task;
  
  constructor() { }

}
