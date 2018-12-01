import { Injectable } from "@angular/core";
import { HttpClient } from '@angular/common/http'
import { Observable } from 'rxjs';
import { Global } from '../global';
import { Router } from "../../../../node_modules/@angular/router";
import { Task } from '../imports';

@Injectable({
  providedIn: 'root'
})
export class TaskService {

  basicURL: string = Global.BASE_ENDPOINT;

  constructor(private http: HttpClient, private router: Router) { }

  //GET
  getAllTasksByProjectId(projectId: number): Observable<any> {
    let url: string = `${this.basicURL}/Tasks/GetTasksWithWorkerAndProjectByProjectId/${projectId}`;
    return this.http.get(url);
  }

  //GET
  getTasksWithWorkerAndProjectByWorkerId(workerId: number): Observable<any> {
    let url: string = `${this.basicURL}/Tasks/GetTasksWithWorkerAndProjectByWorkerId/${workerId}`;
    return this.http.get(url);
  }

  //GER
  getWorkersDictionary(projectId: number): Observable<any> {
    let url: string = `${this.basicURL}/Tasks/GetWorkersDictionary/${projectId}`;
    return this.http.get(url);
  }

  //GET
  getProectsDictionaryByWorkerId(workerId: number): Observable<any> {
    let url: string = `${this.basicURL}/Tasks/GetWorkerTasksDictionary/${workerId}`;
    return this.http.get(url);
  }

  //POST
  addTask(task: Task): Observable<any> {
    let url: string = `${this.basicURL}/Tasks/AddTask`;
    return this.http.post(url, task);
  }

  //PUT
  updateTask(task: Task): Observable<any> {
    let url: string = `${this.basicURL}/Tasks/UpdateTask`;
    return this.http.put(url, task);
  }
}
