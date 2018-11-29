import { Component, OnInit, Input } from '@angular/core';
import { FormGroup, FormControl } from '@angular/forms';
import { checkStringLength, confirmPassword, checkEmail, StatusService, Status, WorkerService, Worker } from '../../shared/imports';
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
  constructor(private statusService: StatusService, private workerService: WorkerService,private router:Router) {

    let formGroupConfig = {
      workerName: new FormControl("", checkStringLength("name", 3, 15)),
      password: new FormControl("", checkStringLength("password", 6, 10)),
      email: new FormControl("", checkEmail()),
      statusId: new FormControl(""),
      managerId: new FormControl("")
    };

    this.formGroup = new FormGroup(formGroupConfig);
    this.formGroup.addControl("confirmPassword", new FormControl("", confirmPassword(this.formGroup)));

     this.currentWorker = this.workerService.getCurrentWorker();
  }

  ngOnInit() {
    this.getAllStatus();
  }

  getAllStatus() {
    this.statusService.getAllStatus().subscribe((res) => {
      this.statusArray = res;
    }
    )
  }
  changeManager(event: Event) {
    let selectedOptions = event.target['options'];
    let status = this.statusArray[selectedOptions.selectedIndex];
    if (status.statusName != 'TeamHead') {
      this.workerService.getAllTeamHeads().subscribe((res) => {
        this.managersArray = res;
      });
    }
    else {
      this.managersArray = null;
      this.managersArray = new Array();
      this.managersArray.push(this.currentWorker);
    }
  }
  async  submitNewWorker() {
    this.newWorker = new Worker();
    this.newWorker = this.formGroup.value;
    this.newWorker.password = await sha256(this.newWorker.password);
    console.log(this.newWorker);
    this.workerService.addWorker(this.newWorker).subscribe((res) => {
      swal({
        position: 'top-end',
        type: 'success',
        title: 'Added successfuly!',
        showConfirmButton: false,
        timer: 100
      });
      this.router.navigate(['taskManagement/manager']);
    },(req)=> {
      let errorMsg="";
      req.error.forEach(err => {
        errorMsg+=err+" ";
      });
        swal({
          type: 'error',
          title: 'Oops...',
          text: errorMsg });
      })



  }

}


