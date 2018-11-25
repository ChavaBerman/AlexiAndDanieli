import { Component, OnInit } from '@angular/core';
import {  User, UserService, TaskService } from 'src/app/shared/imports';

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
  worker: User;
  constructor( private userService: UserService,private taskService:TaskService) { }

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
    this.worker = this.userService.getCurrentUser();
    this.taskService.GetProectsDictionaryByWorkerId(this.worker.userId).subscribe((res)=>{
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
