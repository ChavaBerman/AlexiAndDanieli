import {Status} from './Status';
export class Worker{
    workerId:number
    workerName:string
    password:string
    email:string
    workerComputer:string
    numHoursWork:number
    managerId:number
    statusId:number
    statusObj:Status
    isNewWorker:boolean=true
}