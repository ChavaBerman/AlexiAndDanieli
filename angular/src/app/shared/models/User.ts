import {Status} from './Status';
export class User{
    userId:number
    userName:string
    password:string
    email:string
    userComputer:string
    numHoursWork:number
    managerId:number
    statusId:number
    statusObj:Status
    isNewWorker:boolean=true
}