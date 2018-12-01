import { Component, OnInit, Input } from '@angular/core';
import { ProjectService } from 'src/app/shared/imports';

@Component({
  selector: 'app-project-chart',
  templateUrl: './project-chart.component.html',
  styleUrls: ['./project-chart.component.css']
})
export class ProjectChartComponent implements OnInit {

  public pieChartLabels: string[] = ['Done', 'Todo'];
  public pieChartData: number[] = [];
  public pieChartType: string = 'pie';
  @Input()
  projectId: number;

  constructor(private projectService: ProjectService) {
    this.projectService.projectIdSubject.subscribe(
      {
        next: (v: number) => {
          this.projectId = v;
          this.getData();
        }
      }
    );
  }

  ngOnInit() {
    this.getData();
  }

  getData() {
    //get project state (DONE-TODO)
    this.projectService.getProjectState(this.projectId).subscribe((res) => {
      this.pieChartData = [res, 100 - res];
    })
  }

  chartHovered(e: any): void {
    console.log(e);
  }

}
