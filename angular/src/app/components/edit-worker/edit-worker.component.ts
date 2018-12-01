import { Component, OnInit } from '@angular/core';
import { Worker, WorkerService, StatusService, Status, } from '../../shared/imports';
import { FormGroup, FormControl } from '@angular/forms';
import swal from 'sweetalert2';

@Component({
  selector: 'app-edit-worker',
  templateUrl: './edit-worker.component.html',
  styleUrls: ['./edit-worker.component.css']
})
export class EditWorkerComponent implements OnInit {


  workers: Array<Worker>;
  statuses: Array<Status>;
  teamHeads: Array<Worker>;
  formGroup: FormGroup;
  currentWorker: Worker;

  constructor(private workerService: WorkerService, private statusService: StatusService) {
    //declare all controls in form:
    let formGroupConfig = {
      idWorker: new FormControl(""),
      idStatus: new FormControl(""),
      idTeamHead: new FormControl("")
    };
    this.formGroup = new FormGroup(formGroupConfig);
  }

  ngOnInit() {
    //get all workers:
    this.workerService.getAllWorkers().subscribe((res) => {
      this.workers = res;
    })
    //get all team heads:
    this.workerService.getAllTeamHeads().subscribe((res) => {
      this.teamHeads = res;
    })
    //get all statuses:
    this.statusService.getAllStatus().subscribe((res) => {
      this.statuses = res;
    })
  }

  chooseWorker(event: Event) {
    //get choosen worker:
    let selectedOptions = event.target['options'];
    this.currentWorker = this.workers[selectedOptions.selectedIndex];
    //show user his details:
    this.formGroup.patchValue({
      idStatus: this.currentWorker.statusId,
      idTeamHead: this.currentWorker.managerId
    });
  }

  saveWorker() {
    let idTeamHead: number = this.formGroup.controls["idTeamHead"].value;
    let idStatus: number = this.formGroup.controls["idStatus"].value;
    this.currentWorker.managerId = idTeamHead;
    this.currentWorker.statusId = idStatus;
    this.workerService.updateWorker(this.currentWorker).subscribe(
      (res) => {
        swal({
          position: 'top-end',
          type: 'success',
          title: 'Update successfuly!',
          showConfirmButton: false,
          timer: 1500
        });
      }, (req) => {
        swal({
          type: 'error',
          title: 'Oops...',
          text: 'Did not succeed to update.'
        });
      })
  }

  removeWorker() {
    swal({
      title: 'Are you sure?',
      text: "You won't be able to revert this!",
      type: 'warning',
      showCancelButton: true,
      confirmButtonColor: '#3085d6',
      cancelButtonColor: '#d33',
      confirmButtonText: 'Yes, delete it!'
    }).then((result) => {
      if (result.value) {
        //remove worker:
        this.workerService.removeWorker(this.currentWorker.workerId).subscribe(
          (res) => {
            swal({
              position: 'top-end',
              type: 'success',
              title: 'Removed successfuly!',
              showConfirmButton: false,
              timer: 1500
            });
            this.workers.splice(this.workers.indexOf(this.currentWorker), 1);
          }
          , (req) => {
            swal({
              type: 'error',
              title: 'Oops...',
              text: 'Did not succeed to remove.'
            });
          }
        );
      }
    })
  }

}
