import { Component, OnInit } from '@angular/core';
import {
  Project,
  ProjectService,
  Worker,
  WorkerService,
  TaskService
} from 'src/app/shared/imports';

@Component({
  selector: 'app-hours-chart',
  templateUrl: './hours-chart.component.html',
  styleUrls: ['./hours-chart.component.css']
})
export class HoursChartComponent implements OnInit {

  barChartOptions: any;
  barChartLabels: any;
  barChartType: any;
  barChartLegend: any;
  barChartData: any;
  reservingArray: any = [];
  givenArray: any = [];
  projects: Array<Project>;
  teamHead: Worker;

  constructor(private projectService: ProjectService, private workerService: WorkerService, private taskService: TaskService) { }

  ngOnInit() {
    this.barChartOptions = {
      scaleShowVerticalLines: false,
      responsive: true
    };
    this.barChartLabels = [];
    this.barChartType = 'bar';
    this.barChartLegend = true;

    this.barChartData = [
      { data: [], label: 'reserving hours' },
      { data: [], label: 'given hours' }
    ];
    //get current team head:
    this.teamHead = this.workerService.getCurrentWorker();
    //get current team head projects:
    this.projectService.getAllProjectsByTeamHead(this.teamHead.workerId).subscribe((res) => {
      this.projects = res;
    })
  }

  changeProject(event: Event) {
    this.barChartLabels = [];
    this.reservingArray = [];
    this.givenArray = [];
    //get selected project:
    let selectedOptions = event.target['options'];
    this.taskService.getWorkersDictionary(this.projects[selectedOptions.selectedIndex].projectId).subscribe((res) => {
      Object.keys(res).map(key => {
        this.barChartLabels.push(key);
        this.reservingArray.push(res[key]["reservingHours"]);
        this.givenArray.push(res[key]["givenHours"]);
      });
      this.barChartData[0]["data"] = this.reservingArray;
      this.barChartData[1]["data"] = this.givenArray;
    });
  }

  public chartClicked(e: any): void {
    console.log(e);
  }

  public chartHovered(e: any): void {
    console.log(e);
  }
}
