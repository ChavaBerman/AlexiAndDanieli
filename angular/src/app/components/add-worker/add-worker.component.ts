import { Component, OnInit } from '@angular/core';
import { FormGroup, FormControl } from '@angular/forms';
import {
  checkStringLength,
  confirmPassword,
  checkEmail,
  StatusService,
  Status,
  WorkerService,
  Worker
} from '../../shared/imports';
import { Router } from '@angular/router';
import * as sha256 from 'async-sha256';
import swal from 'sweetalert2';

@Component({
  selector: 'app-add-worker',
  templateUrl: './add-worker.component.html',
  styleUrls: ['./add-worker.component.css']
})
export class AddWorkerComponent implements OnInit {

  formGroup: FormGroup;
  obj: typeof Object = Object;
  statusArray: Array<Status>;
  managersArray: Array<Worker>;
  currentWorker: Worker;
  newWorker: Worker;

  constructor(private statusService: StatusService, private workerService: WorkerService, private router: Router) {
    //declare all controls in form:
    let formGroupConfig = {
      workerName: new FormControl("", checkStringLength("name", 3, 15)),
      password: new FormControl("", checkStringLength("password", 6, 10)),
      email: new FormControl("", checkEmail()),
      statusId: new FormControl(""),
      managerId: new FormControl("")
    };
    this.formGroup = new FormGroup(formGroupConfig);
    //add confirmPassword control to formGroup:
    this.formGroup.addControl("confirmPassword", new FormControl("", confirmPassword(this.formGroup)));
    this.currentWorker = this.workerService.getCurrentWorker();
  }

  ngOnInit() {
    //get status array:
    this.statusService.getAllStatus().subscribe((res) => {
      this.statusArray = res;
    });
  }

  changeStatus(event: Event) {
    //get selected status:
    let selectedOptions = event.target['options'];
    let status = this.statusArray[selectedOptions.selectedIndex];
    //if user chose DEV/QA/UIUX he can choose one of the team head to be the new worker's manager:
    if (status.statusName != 'TeamHead') {
      this.workerService.getAllTeamHeads().subscribe((res) => {
        this.managersArray = res;
      });
    }
    //if user chose TeamHead only the manaeger can be the new worker's manager:
    else {
      this.managersArray = null;
      this.managersArray = new Array();
      this.managersArray.push(this.currentWorker);
    }
  }
  async  submitNewWorker() {
    //create the new worker:
    this.newWorker = new Worker();
    this.newWorker = this.formGroup.value;
    //hash the password:
    this.newWorker.password = await sha256(this.newWorker.password);
    this.workerService.addWorker(this.newWorker).subscribe((res) => {
      swal({
        position: 'top-end',
        type: 'success',
        title: 'Added successfuly!',
        showConfirmButton: false,
        timer: 100
      });
      this.router.navigate(['taskManagement/manager']);
    }, (req) => {
      let errorMsg = "";
      req.error.forEach(err => {
        errorMsg += err + " ";
      });
      swal({
        type: 'error',
        title: 'Oops...',
        text: errorMsg
      });
    })



  }

}


