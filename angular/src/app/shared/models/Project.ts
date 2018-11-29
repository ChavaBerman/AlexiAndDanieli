import { Worker } from "./Worker";
import { Task } from "./Task";

export class Project {
    projectId: number;
    projectName: string;
    customerName: string;
    dateBegin: Date;
    dateEnd: Date;
    isFinish: boolean;
    idManager: number;
    DevHours: number;
    QAHours: number;
    UIUXHours: number;
    tasks:Array<Task>=new Array<Task>();
    //-------------------------
    manager: Worker;
    workers:Array<Worker>;


}
