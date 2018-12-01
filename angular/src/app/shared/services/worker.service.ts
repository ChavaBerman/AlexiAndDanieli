import { Injectable } from "@angular/core";
import { HttpClient } from '@angular/common/http'
import { Observable, Subject } from 'rxjs';
import { Global } from '../global';
import { Router } from "@angular/router";
import { Worker, EmailParams } from '../imports';

@Injectable()
export class WorkerService {

    //----------------PROPERTIRS-------------------
    currentWorkerSubject = new Subject();
    basicURL: string = Global.BASE_ENDPOINT;

    constructor(private http: HttpClient, private router: Router) {}


    getCurrentWorker() {
        return JSON.parse(localStorage.getItem("currentWorker"));
    }

    //POST
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

    //GET
    getAllTeamHeads(): Observable<any> {
        let url: string = `${this.basicURL}/Workers/GetAllTeamHeads`;
        return this.http.get(url);
    }

    //GET
    getIp(): Observable<any> {
        let url: string = `https://api.ipify.org/?format=json`;
        return this.http.get(url);
    }

    //GET
    getAllowedWorkers(idTeamHead: number): Observable<any> {
        let url: string = `${this.basicURL}/Workers/GetAllowedWorkers/${idTeamHead}`;
        return this.http.get(url);
    }

    //GET
    getAllWorkersByTeamHead(idTeamHead: number): Observable<any> {
        let url: string = `${this.basicURL}/Workers/GetWorkersByTeamhead/${idTeamHead}`;
        return this.http.get(url);
    }

    //GET
    getAllWorkers(): Observable<any> {
        let url: string = `${this.basicURL}/Workers/getWorkers`;
        return this.http.get(url);
    }

    //GET
    getFilesystem(): Observable<any> {
        return this.http.get(`${this.basicURL}/Workers/getJson`);
    }

    //GET
    sendForgotPassword(email: string, workerName: string): Observable<any> {
        let url: string = `${this.basicURL}/Workers/ForgotPassword/${email}/${workerName}`;
        return this.http.get(url);
    }
    
    //POST
    loginByComputer(ip): Observable<any> {
        let url: string = `${this.basicURL}/Workers/LoginByComputerWorker`;
        let data: object = { computerIp: ip };
        return this.http.post(url, data);
    }

    //POST
    addWorker(worker: Worker): Observable<any> {
        let url: string = `${this.basicURL}/Workers/addWorker`;
        return this.http.post(url, worker);
    }

    //POST
    sendNewPassword(newPassword: string, requestId: number, workerName: string): Observable<any> {
        let url: string = `${this.basicURL}/Workers/SetNewPassword`;
        return this.http.post(url, { password: newPassword, requestId: requestId, workerName: workerName });
    }
    
    //POST
    senEmail(emailParams: EmailParams): Observable<any> {
        let url: string = `${this.basicURL}/Workers/sendMessageToManager`;
        return this.http.post(url, emailParams);
    }

    //PUT
    updateWorker(worker: Worker): Observable<any> {
        let url: string = `${this.basicURL}/Workers/UpdateWorker`;
        return this.http.put(url, worker);
    }

    //DELETE
    removeWorker(id: number) {
        let url: string = `${this.basicURL}/Workers/RemoveWorker/${id}`;
        return this.http.delete(url);
    }

}