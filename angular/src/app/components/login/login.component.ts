import { Component } from '@angular/core';
import { FormGroup, FormControl, ValidatorFn } from '@angular/forms';
import { checkStringLength } from '../../../app/shared/validaitors/validators'
import { UserService } from '../../shared/services/user.service'
import * as sha256 from 'async-sha256'
import { Router } from '../../../../node_modules/@angular/router';
import swal from 'sweetalert2';
import { User } from 'src/app/shared/imports';
@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent {

  //----------------PROPERTIRS-------------------
  formGroup: FormGroup;
  obj: typeof Object = Object;
  hashPassword: string;

  //----------------CONSTRUCTOR------------------
  constructor(private userservice: UserService, private router: Router) {
    let formGroupConfig = {
      userName: new FormControl("", checkStringLength("name", 3, 15)),
      userPassword: new FormControl("", checkStringLength("password", 6, 10)),
      rememberMe:new FormControl("")
    };

    this.formGroup = new FormGroup(formGroupConfig);
  }

  //----------------METHODS-------------------
  async  submitLogin() {


    this.hashPassword = await sha256(this.formGroup.controls["userPassword"].value);
    this.userservice.login(this.formGroup.controls["userName"].value, this.hashPassword).subscribe((res) => {
         let user:User=new User();
         user.userId=res.userId;
         
         user.userName=res.userName;
         user.email=res.email;
         user.isNewWorker=false;
         user.managerId=res.managerId;
         user.numHoursWork=res.numHoursWork;
         user.statusId=res.statusId;
         user.statusObj=res.statusObj;
      localStorage.setItem("user", JSON.stringify(user));
      if(this.formGroup.controls["rememberMe"].value==true)
      {

       this.userservice.getIp().subscribe((ip)=>{

         user.userComputer=ip["ip"];
         this.userservice.updateWorker(user).subscribe(
          (msg) => {
            swal({
              position: 'top-end',
              type: 'success',
              title: 'Update successfuly!',
              showConfirmButton: false,
              timer: 100
            });
          }, (req) => {
            swal({
              type: 'error',
              title: 'Oops...',
              text: 'this computer already registered.' });
          });
         
        });
       
      }
      this.userservice.navigate(res);

    }
    )
  };




}