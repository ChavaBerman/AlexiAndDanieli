import { Injectable } from "@angular/core";
import { HttpClient } from '@angular/common/http'
import { Observable } from 'rxjs';
import { Global } from '../global';
import { Router } from "../../../../node_modules/@angular/router";
import * as XLSX from 'xlsx'
import * as FileSaver from 'file-saver';

const EXCEL_TYPE = 'application/vnd.openxmlformats-officedocument.spreadsheetml.sheet;charset=UTF-8';
const EXCEL_EXTENSION = '.xlsx';

@Injectable()
export class ReportService {

    constructor(private http: HttpClient, private router: Router) {

    }
    basicURL: string = Global.BASE_ENDPOINT;
    createReport(): Observable<any> {
        let url: string = `${this.basicURL}/Reports/GetReportData`;
        return this.http.get(url);
    }
    filterReport(requiredMonth: number, projectName: string, teamHeadName: string, workerName: string): Observable<any> {
        let url: string = `${this.basicURL}/Reports/FilterReport/${requiredMonth}/${projectName}/${teamHeadName}/${workerName}`;
        return this.http.get(url);
    }
    exportAsExcelFile(json: any[], excelFileName: string): void {
        json.forEach(element => {
            element["Project-Worker"] = element.parentId==0?"Project":"Worker";
            delete element.id;
            delete element.parentId;

        });
        const worksheet: XLSX.WorkSheet = XLSX.utils.json_to_sheet(json);
        const workbook: XLSX.WorkBook = { Sheets: { 'data': worksheet }, SheetNames: ['data'] };
        const excelBuffer: any = XLSX.write(workbook, { bookType: 'xlsx', type: 'array' });
        this.saveAsExcelFile(excelBuffer, excelFileName);
      }
     saveAsExcelFile(buffer: any, fileName: string): void {
         const data: Blob = new Blob([buffer], {type: EXCEL_TYPE});
         FileSaver.saveAs(data, fileName + '_export_' + new  Date().getTime() + EXCEL_EXTENSION);
      }


}