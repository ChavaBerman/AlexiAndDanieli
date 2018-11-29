import { Injectable } from "@angular/core";
import { HttpClient } from '@angular/common/http'
import { Observable, Subject } from 'rxjs';
import { Global } from '../global';
import { Router } from "@angular/router";
import { Worker, EmailParams } from '../imports';
import { TreeNode } from 'primeng/api';

@Injectable()
export class WorkerService {


    constructor(private http: HttpClient, private router: Router) {

    }
    //----------------PROPERTIRS-------------------
    currentWorkerSubject = new Subject();
    basicURL: string = Global.BASE_ENDPOINT;

    login(email: string, password: string): Observable<any> {
        let url: string = `${this.basicURL}/Workers/loginByPassword`;
        let data = { WorkerName: email, Password: password };
        return this.http.post(url, data);

    }
    logout(): any {
        localStorage.removeItem("currentWorker");
        this.navigateToLogin();
    }
    navigateToLogin() {
        this.router.navigate(['taskManagement/login']);
    }
    navigate(worker: Worker) {

        //update current worker by subject
        this.currentWorkerSubject.next(worker);

        switch (worker.statusObj.statusName) {
            case 'Manager':
                this.router.navigate(['taskManagement/manager'])
                break;
            case 'TeamHead':
                this.router.navigate(['taskManagement/teamHead'])
                break;
            default: this.router.navigate(['taskManagement/worker'])
                break;
        }
    }

    getAllTeamHeads(): Observable<any> {
        let url: string = `${this.basicURL}/Workers/GetAllTeamHeads`;
        return this.http.get(url);
    }
    getIp(): Observable<any> {
        let url: string = `https://api.ipify.org/?format=json`;
        return this.http.get(url);
    }
    getCurrentWorker() {
        return JSON.parse(localStorage.getItem("currentWorker"));
    }
    getCurrentWorkerByIp(ip): Observable<any> {
        let url: string = `${this.basicURL}/Workers/LoginByComputerWorker`;
        let data: object = { computerIp: ip };
        return this.http.post(url, data);
    }
    addWorker(worker: Worker): Observable<any> {
        let url: string = `${this.basicURL}/Workers/addWorker`;
        return this.http.post(url, worker);
    }
    sendNewPassword(newPassword: string, requestId: number, workerName: string): Observable<any> {
        let url: string = `${this.basicURL}/Workers/SetNewPassword`;
        return this.http.post(url, { password: newPassword, requestId: requestId, workerName: workerName });
    }
    getAllowedWorkers(idTeamHead: number): Observable<any> {
        let url: string = `${this.basicURL}/Workers/GetAllowedWorkers/${idTeamHead}`;
        return this.http.get(url);
    }
    getAllWorkersByTeamHead(idTeamHead: number): Observable<any> {
        let url: string = `${this.basicURL}/Workers/GetWorkersByTeamhead/${idTeamHead}`;
        return this.http.get(url);
    }
    getAllWorkers(): Observable<any> {
        let url: string = `${this.basicURL}/Workers/getWorkers`;
        return this.http.get(url);
    }
    updateWorker(worker: Worker): Observable<any> {
        let url: string = `${this.basicURL}/Workers/UpdateWorker`;
        return this.http.put(url, worker);
    }
    removeWorker(id: number) {
        let url: string = `${this.basicURL}/Workers/RemoveWorker/${id}`;
        return this.http.delete(url);
    }
    senEmail(emailParams: EmailParams): Observable<any> {
        let url: string = `${this.basicURL}/Workers/sendMessageToManager`;
        return this.http.post(url, emailParams);
    }
    getFilesystem(): Observable<any> {
        return this.http.get(`${this.basicURL}/Workers/getJson`);

    }

    sendForgotPassword(email: string, workerName: string): Observable<any> {
        let url: string = `${this.basicURL}/Workers/ForgotPassword/${email}/${workerName}`;
        return this.http.get(url);
    }








}