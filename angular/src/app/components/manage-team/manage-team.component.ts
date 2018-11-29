import { Component, OnInit } from '@angular/core';
import { Worker, WorkerService } from 'src/app/shared/imports';
import { FormControl, FormGroup } from '@angular/forms';
import swal from 'sweetalert2';

@Component({
  selector: 'app-manage-team',
  templateUrl: './manage-team.component.html',
  styleUrls: ['./manage-team.component.css']
})
export class ManageTeamComponent implements OnInit {

  workers:Array<Worker>;
  teamHeads:Array<Worker>;
  formGroup: FormGroup;
  workerForChange:Worker;
  constructor( private workerService: WorkerService) { 
    let formGroupConfig = {
      idWorker: new FormControl(""),
      idTeamHead: new FormControl("")
    };
    this.formGroup = new FormGroup(formGroupConfig);
  }

  ngOnInit() {
    this.workerService.getAllWorkers().subscribe((res)=>{this.workers=res;});
    this.workerService.getAllTeamHeads().subscribe((res)=>{this.teamHeads=res;});
  }

  changeWorker(event:Event){
    let selectedOptions = event.target['options'];
    this.workerForChange = this.workers[selectedOptions.selectedIndex];
    this.formGroup.patchValue({
      idTeamHead: this.workerForChange.managerId
    });
  }

  saveTeamHead(){
    this.workerForChange.managerId=this.formGroup.controls["idTeamHead"].value;
    this.workerService.updateWorker(this.workerForChange).subscribe(
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
}
