import { User } from "./user";
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
    manager: User;
    workers:Array<User>;


}
