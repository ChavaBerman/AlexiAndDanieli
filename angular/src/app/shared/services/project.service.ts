import { Injectable } from "@angular/core";
import { HttpClient } from '@angular/common/http'
import { Observable, Subject } from 'rxjs';
import { Global } from '../global';
import { Router } from "../../../../node_modules/@angular/router";
import { Project } from '../imports';


@Injectable()
export class ProjectService {

    projectIdSubject: Subject<number> = new Subject()
    basicURL: string = Global.BASE_ENDPOINT;

    constructor(private http: HttpClient, private router: Router) { }

    //GET
    getAllProjects(): Observable<any> {
        let url: string = `${this.basicURL}/Projects/GetAllProjects`;
        return this.http.get(url);
    }

    //GET
    getAllProjectsByTeamHead(teamHeadId: number): Observable<any> {
        let url: string = `${this.basicURL}/Projects/GetAllProjectsByTeamHead/${teamHeadId}`;
        return this.http.get(url);
    }

    //GET
    getAllProjectsByWorker(workerId: number): Observable<any> {
        let url: string = `${this.basicURL}/Projects/GetAllProjectsByWorker/${workerId}`;
        return this.http.get(url);
    }

    //GET
    getProjectState(projectId: number): Observable<any> {
        let url: string = `${this.basicURL}/Projects/GetProjectState/${projectId}`;
        return this.http.get(url);
    }

    //POST
    addProject(project: Project): Observable<any> {
        let url: string = `${this.basicURL}/Projects/AddProject`;
        return this.http.post(url, project);
    }

}