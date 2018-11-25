import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup } from '@angular/forms';
import { UserService, User, EmailParams } from 'src/app/shared/imports';
import swal from 'sweetalert2';

@Component({
  selector: 'app-apply-to-manager',
  templateUrl: './apply-to-manager.component.html',
  styleUrls: ['./apply-to-manager.component.css']
})
export class ApplyToManagerComponent implements OnInit {

  formGroup: FormGroup;
  worker: User;

  constructor(private userService: UserService) {
    let formGroupConfig = {
      subject: new FormControl(""),
      message: new FormControl("")
    };
    this.formGroup = new FormGroup(formGroupConfig);

  this.worker = this.userService.getCurrentUser();
  }

  ngOnInit() {
  }
  sendEmail() {
    let emailParams:EmailParams=new EmailParams();
    emailParams.idUser=this.worker.userId;
    emailParams.message=this.formGroup.controls["message"].value;
    emailParams.subject=this.formGroup.controls["subject"].value;
    this.userService.senEmail(emailParams).subscribe(
      (res) => {
        swal({
          position: 'top-end',
          type: 'success',
          title: 'Send successfuly!',
          showConfirmButton: false,
          timer: 1500
        });
      },(req)=> {
          swal({
            type: 'error',
            title: 'Oops...',
            text: 'Did not succeed to send.' });
        }
    )
  }

}
