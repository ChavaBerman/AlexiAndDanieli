import { Component, OnInit } from '@angular/core';
import { TreeNode } from 'primeng/api';
import {  ReportService, ProjectReport, WorkerForProjectReport } from 'src/app/shared/imports';

@Component({
  selector: 'app-workers-report',
  templateUrl: './workers-report.component.html',
  styleUrls: ['./workers-report.component.css']
})
export class WorkersReportComponent implements OnInit {
  files1: TreeNode[]=[];
  files2: TreeNode[];
  cols: any[];
  projectReportData:Array<ProjectReport>;
  countriesTreeNodes: TreeNode[];
  constructor(private reportService:ReportService) { }

  ngOnInit() {
      this.reportService.createProjectReport().subscribe(data => {
        console.log(data);
        this.projectReportData=data;
        this.projectReportData.forEach(element => {
          //this.files1.push(this.dataToTreeNode(element));
        });
        let x={
          "data":
          [
              {
                  "data":{
                      "name":"Documents",
                      "size":"75kb",
                      "type":"Folder"
                  },
                  "children":[
                      {
                          "data":{
                              "name":"Work",
                              "size":"55kb",
                              "type":"Folder"
                          },
                          "children":[
                              {
                                  "data":{
                                      "name":"Expenses.doc",
                                      "size":"30kb",
                                      "type":"Document"
                                  }
                              },
                              {
                                  "data":{
                                      "name":"Resume.doc",
                                      "size":"25kb",
                                      "type":"Resume"
                                  }
                              }
                          ]
                      },
                      {
                          "data":{
                              "name":"Home",
                              "size":"20kb",
                              "type":"Folder"
                          },
                          "children":[
                              {
                                  "data":{
                                      "name":"Invoices",
                                      "size":"20kb",
                                      "type":"Text"
                                  }
                              }
                          ]
                      }
                  ]
              },
              {
                  "data":{
                      "name":"Pictures",
                      "size":"150kb",
                      "type":"Folder"
                  },
                  "children":[
                      {
                          "data":{
                              "name":"barcelona.jpg",
                              "size":"90kb",
                              "type":"Picture"
                          }
                      },
                      {
                          "data":{
                              "name":"primeui.png",
                              "size":"30kb",
                              "type":"Picture"
                          }
                      },
                      {
                          "data":{
                              "name":"optimus.jpg",
                              "size":"30kb",
                              "type":"Picture"
                          }
                      }
                  ]
              }
          ]
      };
      x["data"].forEach(element => {
         this.files1.push(this.dataToTreeNode(element));
      });
    
        console.log(this.files1);
      
        this.cols = [
          { field: 'name', header: 'Name' },
           { field: 'size', header: 'Size' },
           { field: 'type', header: 'Type' }
       ];
});
       
  }
  

  private countryToTreeNode(country: WorkerForProjectReport) : TreeNode {
    return {
        //label: country.userName,
        data: country
    }}
   dataToTreeNode(cont: object): TreeNode{
    this.countriesTreeNodes = [];

    
        for (let c of cont["children"]) {
            this.countriesTreeNodes.push(this.countryToTreeNode(c));
           
    
    return {
        //label: cont.projectInfo.projectName,
        data: cont["data"],
        children: this.countriesTreeNodes
        }
    };
}

 
}
