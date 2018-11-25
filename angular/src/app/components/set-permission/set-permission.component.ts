import { Component, OnInit } from '@angular/core';
import { User, Project, UserService, ProjectService, Task } from '../../shared/imports';
import { FormGroup, FormControl } from '@angular/forms';
import { TaskService } from '../../shared/services/task.service';
import swal from 'sweetalert2';

@Component({
  selector: 'app-set-permission',
  templateUrl: './set-permission.component.html',
  styleUrls: ['./set-permission.component.css']
})
export class SetPermissionComponent implements OnInit {

  workers: Array<User>;
  projects: Array<Project>;
  formGroup: FormGroup;

  constructor(private userService: UserService, private projectService: ProjectService, private taskService: TaskService) {
    let formGroupConfig = {
      givenHours: new FormControl(""),
      idUser: new FormControl(""),
      idProject: new FormControl(""),
    };
    this.formGroup = new FormGroup(formGroupConfig);
  }

  ngOnInit() {
    this.userService.getAllWorkers().subscribe((res) => {
      this.workers = res;
    });
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
          text: 'This worker already exists in this project.' });


      })
  }

}
