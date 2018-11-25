import { Component, OnInit } from '@angular/core';
import { Project, ProjectService, User, UserService, TaskService } from 'src/app/shared/imports';

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
  reservingArray:any=[];
  givenArray:any=[];
  projects: Array<Project>;
  teamHead: User;
  constructor(private projectService: ProjectService, private userService: UserService,private taskService:TaskService) { }

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
    this.teamHead = this.userService.getCurrentUser();
    this.projectService.getAllProjectsByTeamHead(this.teamHead.userId).subscribe((res) => {
      this.projects = res;
    })

  }
  changeProject(event:Event){
    this.barChartLabels=[];
    this.reservingArray=[];
    this.givenArray=[];
    let selectedOptions = event.target['options'];
    this.taskService.GetWorkersDictionary(this.projects[selectedOptions.selectedIndex].projectId).subscribe((res)=>{
      console.log(res);
     
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
