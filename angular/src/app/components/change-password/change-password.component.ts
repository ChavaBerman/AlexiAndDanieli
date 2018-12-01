import { Component } from '@angular/core';
import { FormGroup, FormControl } from '@angular/forms';
import { ActivatedRoute } from '@angular/router';
import { checkStringLength, confirmPassword, WorkerService } from 'src/app/shared/imports';
import * as sha256 from 'async-sha256';
import swal from 'sweetalert2';
@Component({
  selector: 'app-change-password',
  templateUrl: './change-password.component.html',
  styleUrls: ['./change-password.component.css']
})
export class ChangePasswordComponent  {

  obj: typeof Object = Object;
  formGroup: FormGroup;
  requestId: number;

  constructor(private route: ActivatedRoute, private workerService: WorkerService) {
    //declare all controls in form:
    let formGroupConfig = {
      password: new FormControl("", checkStringLength("password", 6, 6)),
      workerName: new FormControl("")
    };
    this.formGroup = new FormGroup(formGroupConfig);
    //add confirmPassword control to form:
    this.formGroup.addControl("confirmPassword", new FormControl("", confirmPassword(this.formGroup)));
    //get requestId from url:
    this.requestId = parseInt(this.route.snapshot.paramMap.get('requestId'));
  }

  async submitNewPassword() {
    //hash password:
    let hashPassword = await sha256(this.formGroup.controls["password"].value);
    this.workerService.sendNewPassword(hashPassword, this.requestId, this.formGroup.controls["workerName"].value).subscribe(
      (res) => {
        swal({
          position: 'top-end',
          type: 'success',
          title: res,
          showConfirmButton: false,
          timer: 100
        });
      }, (req) => {

        swal({
          type: 'error',
          title: 'Oops...',
          text: req.error
        });
      });
  }
}
