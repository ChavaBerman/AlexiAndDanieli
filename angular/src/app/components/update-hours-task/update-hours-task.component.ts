import { Component, OnInit, Input } from '@angular/core';
import { Task, checkInt, TaskService } from 'src/app/shared/imports';
import { FormControl, FormGroup } from '@angular/forms';
import swal from 'sweetalert2';

@Component({
  selector: 'app-update-hours-task',
  templateUrl: './update-hours-task.component.html',
  styleUrls: ['./update-hours-task.component.css']
})
export class UpdateHoursTaskComponent implements OnInit {

  @Input()
  task: Task;
  formGroup: FormGroup;

  constructor(private taskService: TaskService) {
    //declare all controls in form: 
    let formGroupConfig = {
      givenHours: new FormControl("", checkInt("", 0, 100))
    };
    this.formGroup = new FormGroup(formGroupConfig);
  }

  ngOnInit() {
  }

  updateHour() {
    this.task.givenHours = this.formGroup.controls["givenHours"].value;
    this.taskService.updateTask(this.task).subscribe(
      (res) => {
        swal({
          position: 'top-end',
          type: 'success',
          title: 'Update successfuly!',
          showConfirmButton: false,
          timer: 1500
        });
      }, (req) => {
        console.log(req);
        swal({
          type: 'error',
          title: 'Oops...',
          text: req.error[0]
        });
      });
  }
}
