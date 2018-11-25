import { Component, OnInit, Input } from '@angular/core';
import { FormGroup, FormControl } from '@angular/forms';
import { checkStringLength, checkInt, StatusService, Status, UserService, User, validateDateEnd, createValidatorDateBegin, ProjectService, Task } from '../../shared/imports';
import { Router } from '@angular/router';
import * as sha256 from 'async-sha256';
import swal from 'sweetalert2';
import { Project } from '../../shared/models/Project';
import { async } from '../../../../node_modules/rxjs/internal/scheduler/async';

@Component({
  selector: 'app-add-project',
  templateUrl: './add-project.component.html',
  styleUrls: ['./add-project.component.css']
})
export class AddProjectComponent implements OnInit {

  formGroup: FormGroup;
  obj: typeof Object = Object;
  teamHeadsArray: Array<User>;
  allowedWorkers: Array<User> = new Array<User>();
  choosenWorkers: Array<User> = new Array<User>();
  teamHeadWorkers: Array<User> = new Array<User>();
  currentUser: User;
  newProject: Project;
  constructor(private statusService: StatusService, private userService: UserService, private projectService: ProjectService, private router: Router) {

    let formGroupConfig = {
      projectName: new FormControl("", checkStringLength("name", 3, 15)),
      customerName: new FormControl("", checkStringLength("customer name", 6, 10)),
      dateBegin: new FormControl("", createValidatorDateBegin("Date begin")),
      idManager: new FormControl(""),
      DevHours: new FormControl("", checkInt("Dev Hours", 1, 900)),
      QAHours: new FormControl("", checkInt("QA Hours", 1, 900)),
      UIUXHours: new FormControl("", checkInt("UIUX Hours", 1, 900))
    };

    this.formGroup = new FormGroup(formGroupConfig);
    this.formGroup.addControl("dateEnd", new FormControl("", validateDateEnd(this.formGroup)));

    this.currentUser = this.userService.getCurrentUser();
  }

  ngOnInit() {
    this.getAllTeamHeads();
  }

  getAllTeamHeads() {
    this.userService.getAllTeamHeads().subscribe((res) => {
      this.teamHeadsArray = res;
      this.getAllowedWorkers(this.teamHeadsArray[0].userId)
    });
  }
  getAllowedWorkers(idTeamHead: number) {
    this.userService.getAllowedWorkers(idTeamHead).subscribe((res) => {
      this.allowedWorkers = res;
    });
  }

  changeTeamHead(event: Event) {
    this.allowedWorkers.splice(0, this.allowedWorkers.length - 1);
    this.choosenWorkers.splice(0, this.choosenWorkers.length - 1);
    let selectedOptions = event.target['options'];
    let teamHead = this.teamHeadsArray[selectedOptions.selectedIndex];
    this.getAllowedWorkers(teamHead.userId);
    this.userService.getAllWorkersByTeamHead(teamHead.userId).subscribe((res) => {
      this.teamHeadWorkers = res;
    })

  }

  changeWorker(event: Event) {
    let selectedOptions = event.target['options'];
    let worker = this.allowedWorkers[selectedOptions.selectedIndex];
    this.choosenWorkers.push(worker);
    this.allowedWorkers.splice(selectedOptions.selectedIndex, 1);
  }
  removeWorker(event: Event) {
    let selectedOptions = event.target['options'];
    let worker = this.choosenWorkers[selectedOptions.selectedIndex];
    this.allowedWorkers.push(worker);
    this.choosenWorkers.splice(selectedOptions.selectedIndex, 1);
  }


  submitNewProject() {
    this.teamHeadWorkers.forEach(element => {
      this.choosenWorkers.push(element);
    });
    this.newProject = new Project();
    this.newProject = this.formGroup.value;
    this.newProject.tasks = new Array<Task>();
    this.choosenWorkers.forEach(async (element) => {
      let task: Task = new Task();
      task.idUser = element.userId;
      //  const {value: reservingHours} = await swal({
      //    title: 'enter resering hours for: '+element.userName,
      //    input: 'number',
      //    inputPlaceholder: '1'
      //  })
      let reservingHours = NaN;
      while (isNaN(reservingHours)) {
        
          reservingHours = Number(prompt("enter reserving hours for: " + element.userName, "1"));
       if(isNaN(reservingHours))
       alert("enter number only!!!");
      
      }
      task.reservingHours = reservingHours;
      this.newProject.tasks.push(task);

    });
    this.newProject.workers = this.choosenWorkers;
    console.log(this.newProject);
    this.projectService.addProject(this.newProject).subscribe((res) => {
      swal({
        position: 'top-end',
        type: 'success',
        title: 'Added successfuly!',
        showConfirmButton: false,
        timer: 1500
      });
      this.router.navigate(['taskManagement/manager']);
    }, (req) => {
      swal({
        type: 'error',
        title: 'Oops...',
        text: 'Did not succeed to add.'
      });
    })



  }
}
