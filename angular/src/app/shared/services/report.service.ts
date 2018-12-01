import { Injectable } from "@angular/core";
import { HttpClient } from '@angular/common/http'
import { Observable, Subject } from 'rxjs';
import { Global } from '../global';
import { Router } from "../../../../node_modules/@angular/router";
import { Worker } from '../imports';

@Injectable()
export class ReportService {

    basicURL: string = Global.BASE_ENDPOINT;

    constructor(private http: HttpClient, private router: Router) { }

    //GET
    createProjectReport(): Observable<any> {
        let url: string = `${this.basicURL}/Reports/GetProjectReportData`;
        return this.http.get(url);
    }

}