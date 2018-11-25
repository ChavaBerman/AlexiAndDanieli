import { User } from "./user";
import { Project } from "./Project";

export class PresentDay{
    idPresentDay:number;
    timeBegin:Date;
    timeEnd:Date;
    sumHoursDay:number;
    userId:number;
    ProjectId:number;
    //---------------------
    user:User;
    prot:Project;
}