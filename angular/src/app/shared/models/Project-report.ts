import { Project } from "./Project";
import { WorkerForProjectReport } from "./Worker-for-project-report";

export class ProjectReport
{
      projectInfo :Project
      projectStateByPrecents:number 
      workers:Array<WorkerForProjectReport>
}