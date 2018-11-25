import { Injectable } from "@angular/core";
import { HttpClient } from '@angular/common/http'
import { Observable, Subject } from 'rxjs';
import { Global } from '../global';
import { Router } from "../../../../node_modules/@angular/router";
import { User } from '../imports';

@Injectable()
export class StatusService {
 
    constructor(private http: HttpClient, private router: Router) {

    }
    basicURL: string = Global.BASE_ENDPOINT;
   getAllStatus(): Observable<any>{
    let url: string = `${this.basicURL}/Status/GetAllStatuses`;
    return this.http.get(url);
   }

}