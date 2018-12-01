import { Injectable } from "@angular/core";
import { HttpClient } from '@angular/common/http'
import { Observable } from 'rxjs';
import { Global } from '../global';
import { Router } from "../../../../node_modules/@angular/router";

@Injectable()
export class StatusService {

    basicURL: string = Global.BASE_ENDPOINT;

    constructor(private http: HttpClient, private router: Router) {}

    //GET
    getAllStatus(): Observable<any> {
        let url: string = `${this.basicURL}/Status/GetAllStatuses`;
        return this.http.get(url);
    }

}