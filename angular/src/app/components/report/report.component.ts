import { Component, OnInit } from '@angular/core';
import { TreeNode } from '../../../../node_modules/primeng/api';
import { ReportData, ReportService, UserService, User, Project, ProjectService } from '../../shared/imports';
import { FormControl, FormGroup } from '../../../../node_modules/@angular/forms';

@Component({
  selector: 'app-report',
  templateUrl: './report.component.html',
  styleUrls: ['./report.component.css']
})
export class ReportComponent implements OnInit {
  teamHeadsArray: Array<User>;
  monthArray: string[] = ["January",
    "Fabruary",
    "March",
    "April", "May",
    "June",
    "July",
    "August",
    "September",
    "October",
    "November",
    "December"];
  workersArray: Array<User>;
  projectsArray: Array<Project>;
  reportDataTreeNodeList: TreeNode[] = [];
  cols: any[];
  formGroup: FormGroup;
  reportDataList: Array<ReportData>;
  children: TreeNode[] = [];

  constructor(private reportService: ReportService, private userService: UserService, private projectService: ProjectService) {
    let formGroupConfig = {
      month: new FormControl(""),
      teamHead: new FormControl(""),
      project: new FormControl(""),
      worker: new FormControl("")
    };

    this.formGroup = new FormGroup(formGroupConfig);
  }

  ngOnInit() {
    this.userService.getAllTeamHeads().subscribe((res) => {
      this.teamHeadsArray = res;
    });
    this.userService.getAllWorkers().subscribe((res) => {
      this.workersArray = res;
    });
    this.projectService.getAllProjects().subscribe((res) => {
      this.projectsArray = res;
    })
    this.reportService.createReport().subscribe(data => {
      this.reportDataList = data;
      this.convertDataToTreeNodeArray();
    });
    this.cols = [
      { field: 'name', header: 'Name' },
      { field: 'teamHeader', header: 'Team Header' },
      { field: 'reservingHours', header: 'Reserving Hours' },
      { field: 'givenHours', header: 'Given Hours' },
      { field: 'dateBegin', header: 'Date Begin' },
      { field: 'dateEnd', header: 'Date End' },
      { field: 'days', header: 'Days' },
      { field: 'workedDays', header: 'Worked Days' }
    ];
  }

  convertDataToTreeNodeArray() {
    this.reportDataTreeNodeList=[];
    this.reportDataList.forEach(reportData => {
      if (reportData.parentId == 0) {
        this.children=[];
        this.reportDataList.forEach(child => {
          if (child.parentId == reportData.id)
            this.children.push(this.childToTreeNode(child))
        });

        this.reportDataTreeNodeList.push(this.parentToTreeNode(reportData, this.children));
      }
    });
  }
  childToTreeNode(child: ReportData): TreeNode {
    return {
      data: child
    }
  }
  parentToTreeNode(parent: ReportData, children: TreeNode[]): TreeNode {
    return {
      label: parent.name,
      data: parent,
      children: children
    }
  }
  generateExcel() {
    this.reportService.exportAsExcelFile(this.reportDataList, "ReportData.xlsx");
  }

  selectFilterParameters() {
    let monthValue=this.formGroup.controls["month"].value!=""?this.formGroup.controls["month"].value:"ok";
    let projectValue=this.formGroup.controls["project"].value!=""?this.formGroup.controls["project"].value:"ok";
    let teamHeadValue=this.formGroup.controls["teamHead"].value!=""?this.formGroup.controls["teamHead"].value:"ok";
    let workerValue=this.formGroup.controls["worker"].value!=""?this.formGroup.controls["worker"].value:"ok";
    this.reportService.filterReport(monthValue,projectValue,teamHeadValue,workerValue)
      .subscribe((res) => {
        this.reportDataList = res;
        this.convertDataToTreeNodeArray();
      })
  }
}

