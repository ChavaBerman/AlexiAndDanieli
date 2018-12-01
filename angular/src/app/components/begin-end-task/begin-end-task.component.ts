import { Component, OnInit } from '@angular/core';
import {
  Project,
  ProjectService,
  Worker,
  WorkerService,
  PresentDay,
  PresentDayService
} from 'src/app/shared/imports';
import swal from 'sweetalert2';
import { SimpleTimer } from 'ng2-simple-timer';

@Component({
  selector: 'app-begin-end-task',
  templateUrl: './begin-end-task.component.html',
  styleUrls: ['./begin-end-task.component.css']
})
export class BeginEndTaskComponent implements OnInit {


  ticks = 0;
  minutesDisplay: number = 0;
  hoursDisplay: number = 0;
  secondsDisplay: number = 0;
  timer: any;
  worker: Worker;
  myProjects: Array<Project>;
  currentProject: Project;
  statBtnEnable: boolean = false;
  endBtnEnable: boolean = true;
  selectProjectEnable: boolean = false;
  idPresentDay: number;
  counter: any = null;
  interval: any;
  presentDay: PresentDay = new PresentDay();

  constructor(private projectService: ProjectService, private workerService: WorkerService, private presentDayService: PresentDayService, private st: SimpleTimer) { }

  ngOnInit() {
    //get current worker:
    this.worker = this.workerService.getCurrentWorker();
    //get all current worker's projects:
    this.projectService.getAllProjectsByWorker(this.worker.workerId).subscribe((res) => {
      this.myProjects = res;
      this.currentProject = this.myProjects[0];
    })
  }

  projectChange(event: Event) {
    //get selected project:
    let selectedOptions = event.target['options'];
    this.currentProject = this.myProjects[selectedOptions.selectedIndex];
  }

  start() {
    this.statBtnEnable = true;
    this.selectProjectEnable = true;
    this.endBtnEnable = false;
    //add present day to current worker:
    this.presentDay.workerId = this.worker.workerId;
    this.presentDay.ProjectId = this.currentProject.projectId;
    this.presentDay.timeBegin = new Date();
    this.presentDayService.addPresentDay(this.presentDay).subscribe(
      (res) => {
        this.presentDay.idPresentDay = res;
        swal({
          position: 'top-end',
          type: 'success',
          title: 'Began successfuly!',
          showConfirmButton: false,
          timer: 1500
        });
      }, (req) => {
        swal({
          type: 'error',
          title: 'Oops...',
          text: 'Did not succeed to begin.'
        });
      }
    );
    //raise the timer:
    this.timer = setInterval(() => this.getTimer(), 1000);
  }

  stop() {
    this.ticks = 0;
    this.minutesDisplay = 0;
    this.hoursDisplay = 0;
    this.secondsDisplay = 0;
    clearInterval(this.timer);
    //update present day with time end:
    this.presentDay.timeEnd = new Date();
    this.presentDayService.updatePresentDay(this.presentDay).subscribe(
      (res) => {
        this.statBtnEnable = false;
        this.selectProjectEnable = false;
        this.endBtnEnable = true;
        swal({
          position: 'top-end',
          type: 'success',
          title: 'Stopped successfuly!',
          showConfirmButton: false,
          timer: 1500
        });
      }, (req) => {
        swal({
          type: 'error',
          title: 'Oops...',
          text: 'Did not succeed to stop.'
        });
      }
    )
  }

  //each timer tick:
  getTimer(): any {
    this.ticks++;
    this.secondsDisplay = this.getSeconds(this.ticks);
    this.minutesDisplay = this.getMinutes(this.ticks);
    this.hoursDisplay = this.getHours(this.ticks);
  }

  private getSeconds(ticks: number) {
    return this.pad(ticks % 60);
  }

  private getMinutes(ticks: number) {
    return this.pad((Math.floor(ticks / 60)) % 60);
  }

  private getHours(ticks: number) {
    return this.pad(Math.floor((ticks / 60) / 60));
  }

  private pad(digit: any) {
    return digit <= 9 ? '0' + digit : digit;
  }

}








