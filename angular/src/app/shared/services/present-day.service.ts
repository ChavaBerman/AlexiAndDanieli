import { Injectable } from "@angular/core";
import { HttpClient } from '@angular/common/http'
import { Observable } from 'rxjs';
import { Global } from '../global';
import { Router } from "../../../../node_modules/@angular/router";
import { PresentDay } from '../imports';


@Injectable()
export class PresentDayService {

    constructor(private http: HttpClient, private router: Router) {

    }
    basicURL: string = Global.BASE_ENDPOINT;

    addPresentDay(presentDay: PresentDay): Observable<any> {
        let url: string = `${this.basicURL}/PresentDay/AddPresent`;
        return this.http.post(url, presentDay);
    }

    updatePresentDay(presentDay: PresentDay): Observable<any> {
        let url: string = `${this.basicURL}/PresentDay/UpdatePresentDay`;
        return this.http.put(url, presentDay);
    }



}