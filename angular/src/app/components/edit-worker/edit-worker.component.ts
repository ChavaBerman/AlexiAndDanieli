import { Component, OnInit } from '@angular/core';
import { User, Project, UserService, ProjectService, TaskService, StatusService, Status, } from '../../shared/imports';
import { FormGroup, FormControl } from '@angular/forms';
import swal from 'sweetalert2';

@Component({
  selector: 'app-edit-worker',
  templateUrl: './edit-worker.component.html',
  styleUrls: ['./edit-worker.component.css']
})
export class EditWorkerComponent implements OnInit {


  workers: Array<User>;
  statuses: Array<Status>;
  teamHeads: Array<User>;
  formGroup: FormGroup;
  currentWorker: User;

  constructor(private userService: UserService, private statusService: StatusService) {
    let formGroupConfig = {
      idUser: new FormControl(""),
      idStatus: new FormControl(""),
      idTeamHead: new FormControl("")
    };
    this.formGroup = new FormGroup(formGroupConfig);
  }

  ngOnInit() {
    this.userService.getAllWorkers().subscribe((res) => {
      this.workers = res;
    })
    this.userService.getAllTeamHeads().subscribe((res) => {
      this.teamHeads = res;
    })
    this.statusService.getAllStatus().subscribe((res) => {
      this.statuses = res;
    })
  }

  chooseWorker(event: Event) {
    let selectedOptions = event.target['options'];
    this.currentWorker = this.workers[selectedOptions.selectedIndex];
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
    this.userService.updateWorker(this.currentWorker).subscribe(
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
          text: 'Did not succeed to update.' });
      })

  }

  removeUser(){
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
      //remove user:
        this.userService.removeUser(this.currentWorker.userId).subscribe(
          (res)=>{
            swal({
              position: 'top-end',
              type: 'success',
              title: 'Removed successfuly!',
              showConfirmButton: false,
              timer: 1500
            });
            this.workers.splice(this.workers.indexOf(this.currentWorker),1);
          }
          ,(req)=>{
            swal({
              type: 'error',
              title: 'Oops...',
              text: 'Did not succeed to remove.' });
          }
        );
      }
    })
  }

}
