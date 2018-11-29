import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup } from '@angular/forms';
import { checkStringLength, confirmPassword, WorkerService, checkEmail } from 'src/app/shared/imports';
import { ActivatedRoute } from '@angular/router';
import * as sha256 from 'async-sha256';
import swal from 'sweetalert2';

@Component({
  selector: 'app-forgot-password',
  templateUrl: './forgot-password.component.html',
  styleUrls: ['./forgot-password.component.css']
})
export class ForgotPasswordComponent implements OnInit {
  obj: typeof Object = Object;
  formGroup:FormGroup;
  requestId:number;
  constructor(private  route: ActivatedRoute,private workerService:WorkerService) {
    let formGroupConfig = {
      email: new FormControl("",checkEmail()),
      workerName: new FormControl("")
    };

    this.formGroup = new FormGroup(formGroupConfig);
   }

  ngOnInit() {
  }
 async sendEmail(){
    this.workerService.sendForgotPassword(this.formGroup.controls["email"].value,this.formGroup.controls["workerName"].value).subscribe(
      (res) => {
        swal({
          position: 'top-end',
          type: 'success',
          title: res,
          showConfirmButton: false,
          timer: 100
        });
      },(req)=> {
       
          swal({
            type: 'error',
            title: 'Oops...',
            text: req.error });
        }
    )

  }
}
