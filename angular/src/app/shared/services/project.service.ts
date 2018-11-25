import { Injectable } from "@angular/core";
import { HttpClient } from '@angular/common/http'
import { Observable, Subject } from 'rxjs';
import { Global } from '../global';
import { Router } from "../../../../node_modules/@angular/router";
import { Project } from '../imports';


@Injectable()
export class ProjectService {
 
    constructor(private http: HttpClient, private router: Router) {
    }

    projectIdSubject:Subject<number>=new Subject()
    basicURL: string = Global.BASE_ENDPOINT;

    addProject(project:Project): Observable<any> {
        let url: string = `${this.basicURL}/Projects/AddProject`;
        return this.http.post(url, project);
    }

    getAllProjects(): Observable<any> {
        let url: string = `${this.basicURL}/Projects/GetAllProjects`;
        return this.http.get(url);
    }
    getAllProjectsByTeamHead(teamHeadId:number): Observable<any> {
        let url: string = `${this.basicURL}/Projects/GetAllProjectsByTeamHead/${teamHeadId}`;
        return this.http.get(url);
    }
    
    GetAllProjectsByWorker(workerId:number): Observable<any> {
        let url: string = `${this.basicURL}/Projects/GetAllProjectsByWorker/${workerId}`;
        return this.http.get(url);
    }
    GetProjectState(projectId:number): Observable<any> {
        let url: string = `${this.basicURL}/Projects/GetProjectState/${projectId}`;
        return this.http.get(url);
    }
    

}