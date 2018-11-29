import { Component, OnInit } from '@angular/core';
import { FormGroup, FormControl, ValidatorFn } from '@angular/forms';
import { checkStringLength } from '../../../app/shared/validaitors/validators'
import { WorkerService } from '../../shared/services/worker.service'
import * as sha256 from 'async-sha256'
import { Router } from '../../../../node_modules/@angular/router';
import swal from 'sweetalert2';
import { Worker } from 'src/app/shared/imports';
@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit{


  //----------------PROPERTIRS-------------------
  formGroup: FormGroup;
  obj: typeof Object = Object;
  hashPassword: string;

  //----------------CONSTRUCTOR------------------
  constructor(private workerService: WorkerService, private router: Router) {
    let formGroupConfig = {
      workerName: new FormControl("", checkStringLength("name", 3, 15)),
      workerPassword: new FormControl("", checkStringLength("password", 6, 10)),
      rememberMe:new FormControl("")
    };

    this.formGroup = new FormGroup(formGroupConfig);
  }

  //----------------METHODS-------------------
  ngOnInit() {
    this.workerService.getIp().subscribe((res) => {
      console.log(res);
      this.workerService.getCurrentWorkerByIp(res["ip"]).subscribe((worker) => {
        if (worker != null) {
          localStorage.setItem("currentWorker", JSON.stringify(worker));
          this.workerService.navigate(JSON.parse(JSON.stringify(worker)));
        }
        else this.workerService.navigateToLogin();
      })
    })
  }
  async  submitLogin() {


    this.hashPassword = await sha256(this.formGroup.controls["workerPassword"].value);
    this.workerService.login(this.formGroup.controls["workerName"].value, this.hashPassword).subscribe((res) => {
         let worker:Worker=new Worker();
         worker.workerId=res.workerId;
         
         worker.workerName=res.workerName;
         worker.email=res.email;
         worker.isNewWorker=false;
         worker.managerId=res.managerId;
         worker.numHoursWork=res.numHoursWork;
         worker.statusId=res.statusId;
         worker.statusObj=res.statusObj;
      localStorage.setItem("currentWorker", JSON.stringify(worker));
      if(this.formGroup.controls["rememberMe"].value==true)
      {

       this.workerService.getIp().subscribe((ip)=>{

         worker.workerComputer=ip["ip"];
         this.workerService.updateWorker(worker).subscribe(
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
      this.workerService.navigate(res);

    }
    )
  };

  forgotPassword(){
    this.router.navigate(['taskManagement/forgot-password']);
  }


}