import { Component } from '@angular/core';
import { FormControl, FormGroup } from '@angular/forms';
import { WorkerService, Worker, EmailParams } from 'src/app/shared/imports';
import swal from 'sweetalert2';

@Component({
  selector: 'app-apply-to-manager',
  templateUrl: './apply-to-manager.component.html',
  styleUrls: ['./apply-to-manager.component.css']
})
export class ApplyToManagerComponent {

  formGroup: FormGroup;
  currentWorker: Worker;

  constructor(private workerService: WorkerService) {
    //declare all controls in form:
    let formGroupConfig = {
      subject: new FormControl(""),
      message: new FormControl("")
    };
    this.formGroup = new FormGroup(formGroupConfig);
    //get current worker:
    this.currentWorker = this.workerService.getCurrentWorker();
  }

  sendEmail() {
    let emailParams: EmailParams = new EmailParams();
    emailParams.idWorker = this.currentWorker.workerId;
    emailParams.message = this.formGroup.controls["message"].value;
    emailParams.subject = this.formGroup.controls["subject"].value;
    this.workerService.senEmail(emailParams).subscribe(
      (res) => {
        swal({
          position: 'top-end',
          type: 'success',
          title: 'Send successfuly!',
          showConfirmButton: false,
          timer: 1500
        });
      }, (req) => {
        swal({
          type: 'error',
          title: 'Oops...',
          text: 'Did not succeed to send.'
        });
      }
    )
  }

}
