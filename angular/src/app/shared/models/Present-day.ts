import { Worker } from "./Worker";
import { Project } from "./Project";

export class PresentDay{
    idPresentDay:number;
    timeBegin:Date;
    timeEnd:Date;
    sumHoursDay:number;
    workerId:number;
    ProjectId:number;
    //---------------------
    worker:Worker;
    prot:Project;
}