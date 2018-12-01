import { Component, OnInit } from '@angular/core';
import { FormGroup, FormControl } from '@angular/forms';
import {
  checkStringLength,
  checkInt,
  StatusService,
  WorkerService,
  Worker,
  validateDateEnd,
  createValidatorDateBegin,
  ProjectService,
  Task
} from '../../shared/imports';
import { Router } from '@angular/router';
import swal from 'sweetalert2';
import { Project } from '../../shared/models/Project';

@Component({
  selector: 'app-add-project',
  templateUrl: './add-project.component.html',
  styleUrls: ['./add-project.component.css']
})
export class AddProjectComponent implements OnInit {


  formGroup: FormGroup;
  obj: typeof Object = Object;
  teamHeadsArray: Array<Worker>;
  //all workers that are not belong to choosen team head
  allowedWorkers: Array<Worker> = new Array<Worker>();
  //all workers that user chose (from allowedWorkers)
  choosenWorkers: Array<Worker> = new Array<Worker>();
  //all workers that are belong to current team head
  teamHeadWorkers: Array<Worker> = new Array<Worker>();
  currentWorker: Worker;
  newProject: Project;

  constructor(private statusService: StatusService, private workerService: WorkerService, private projectService: ProjectService, private router: Router) {
    //declare all controls in form:
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
    //add dateEnd control:
    this.formGroup.addControl("dateEnd", new FormControl("", validateDateEnd(this.formGroup)));

    //get current worker:
    this.currentWorker = this.workerService.getCurrentWorker();
  }

  ngOnInit() {
    //get all team heads:
    this.workerService.getAllTeamHeads().subscribe((res) => {
      this.teamHeadsArray = res;
      this.getAllowedWorkers(this.teamHeadsArray[0].workerId)
    });
  }

  //get all workers that are not belong to current team head:
  getAllowedWorkers(idTeamHead: number) {
    this.workerService.getAllowedWorkers(idTeamHead).subscribe((res) => {
      this.allowedWorkers = res;
    });
  }

  changeTeamHead(event: Event) {
    //clear arrays:
    this.allowedWorkers.splice(0, this.allowedWorkers.length - 1);
    this.choosenWorkers.splice(0, this.choosenWorkers.length - 1);
    //get selected team head:
    let selectedOptions = event.target['options'];
    let teamHead = this.teamHeadsArray[selectedOptions.selectedIndex];
    this.getAllowedWorkers(teamHead.workerId);
    this.workerService.getAllWorkersByTeamHead(teamHead.workerId).subscribe((res) => {
      this.teamHeadWorkers = res;
    });
  }

  changeWorker(event: Event) {
    //get selected worker:
    let selectedOptions = event.target['options'];
    let worker = this.allowedWorkers[selectedOptions.selectedIndex];
    //add selected worker to choosenWorkers array:
    this.choosenWorkers.push(worker);
    //remove him from allowedWorkers:
    this.allowedWorkers.splice(selectedOptions.selectedIndex, 1);
  }

  removeWorker(event: Event) {
    //get selecte worker:
    let selectedOptions = event.target['options'];
    let worker = this.choosenWorkers[selectedOptions.selectedIndex];
    //add him to allowedWorkers back:
    this.allowedWorkers.push(worker);
    //remove him from choosenWorkers:
    this.choosenWorkers.splice(selectedOptions.selectedIndex, 1);
  }

  submitNewProject() {
    //add teamHeadWorkers to choosenWorkers (so that all of them will be connected to the new project):
    this.teamHeadWorkers.forEach(element => {
      this.choosenWorkers.push(element);
    });
    this.newProject = new Project();
    this.newProject = this.formGroup.value;
    this.newProject.tasks = new Array<Task>();
    //add workers to project:
    this.choosenWorkers.forEach(async (element) => {
      let task: Task = new Task();
      task.idWorker = element.workerId;
      let reservingHours = NaN;
      //get the cuurent worker's hours from user:
      while (isNaN(reservingHours)) {
        reservingHours = Number(prompt("enter reserving hours for: " + element.workerName, "1"));
        if (isNaN(reservingHours))
          alert("enter number only!!!");
      }
      task.reservingHours = reservingHours;
      this.newProject.tasks.push(task);
    });
    this.newProject.workers = this.choosenWorkers;
    this.projectService.addProject(this.newProject).subscribe(
      (res) => {
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
