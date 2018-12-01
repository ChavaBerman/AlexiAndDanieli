import { Component, OnInit } from '@angular/core';
import {  Worker, WorkerService, TaskService } from 'src/app/shared/imports';

@Component({
  selector: 'app-my-hours',
  templateUrl: './my-hours.component.html',
  styleUrls: ['./my-hours.component.css']
})
export class MyHoursComponent implements OnInit {

  barChartOptions: any;
  barChartLabels: any;
  barChartType: any;
  barChartLegend: any;
  barChartData: any;
  reservingArray:any=[];
  givenArray:any=[];
  worker: Worker;

  constructor( private workerService: WorkerService,private taskService:TaskService) { }

  ngOnInit() {
    this.barChartOptions = {
      scaleShowVerticalLines: false,
      responsive: true
    };
    this.barChartLabels = [];
    this.barChartType = 'bar';
    this.barChartLegend = true;

    this.barChartData = [
      { data:[], label: 'reserving hours' },
      { data: [], label: 'given hours' }
    ];
    //get current worker:
    this.worker = this.workerService.getCurrentWorker();
    //get projects dictionary (with reserving and givn hours):
    this.taskService.getProectsDictionaryByWorkerId(this.worker.workerId).subscribe((res)=>{
      //create the chart data:
      Object.keys(res).map(key => {
         this.barChartLabels.push(key);
         this.reservingArray.push(res[key]["reservingHours"]);
         this.givenArray.push(res[key]["givenHours"]);
        });
        this.barChartData[0]["data"]=this.reservingArray;
        this.barChartData[1]["data"]=this.givenArray;
    });
  }

  public chartClicked(e: any): void {
    console.log(e);
  }

  public chartHovered(e: any): void {
    console.log(e);
  }
}
