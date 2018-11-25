import { Component, OnInit, Input } from '@angular/core';
import { Task } from 'src/app/shared/imports';

@Component({
  selector: 'app-task-details',
  templateUrl: './task-details.component.html',
  styleUrls: ['./task-details.component.css']
})
export class TaskDetailsComponent implements OnInit {
@Input()
task:Task;
  constructor() { }

  ngOnInit() {
  }

}
