import { Component, OnInit } from '@angular/core';
import { Worker, Project, WorkerService, ProjectService, Task } from '../../shared/imports';
import { FormGroup, FormControl } from '@angular/forms';
import { TaskService } from '../../shared/services/task.service';
import swal from 'sweetalert2';

@Component({
  selector: 'app-set-permission',
  templateUrl: './set-permission.component.html',
  styleUrls: ['./set-permission.component.css']
})
export class SetPermissionComponent implements OnInit {

  workers: Array<Worker>;
  projects: Array<Project>;
  formGroup: FormGroup;

  constructor(private workerService: WorkerService, private projectService: ProjectService, private taskService: TaskService) {
    //declare all controls in form:
    let formGroupConfig = {
      givenHours: new FormControl(""),
      idWorker: new FormControl(""),
      idProject: new FormControl(""),
    };
    this.formGroup = new FormGroup(formGroupConfig);
  }

  ngOnInit() {
    //get all workers:
    this.workerService.getAllWorkers().subscribe((res) => {
      this.workers = res;
    });
    //get all projects:
    this.projectService.getAllProjects().subscribe((res) => {
      this.projects = res;
    });
  }

  saveTask() {
    let newTask: Task = new Task();
    newTask = this.formGroup.value;
    console.log(newTask);
    this.taskService.addTask(newTask).subscribe(
      (res) => {
        swal({
          position: 'top-end',
          type: 'success',
          title: 'Added successfuly!',
          showConfirmButton: false,
          timer: 1500
        });
      }, (req) => {
        console.log(req);
        swal({
          type: 'error',
          title: 'Oops...',
          text: 'This worker already exists in this project.'
        });
      })
  }
}
