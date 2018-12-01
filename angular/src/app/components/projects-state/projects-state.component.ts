import { Component, OnInit } from '@angular/core';
import {
  Project,
  ProjectService,
  Worker,
  WorkerService,
  Task,
  TaskService
} from 'src/app/shared/imports';

@Component({
  selector: 'app-projects-state',
  templateUrl: './projects-state.component.html',
  styleUrls: ['./projects-state.component.css']
})
export class ProjectsStateComponent implements OnInit {

  myProjects: Array<Project>;
  currentProjectTasks: Array<Task>;
  teamHead: Worker;
  currentProject: Project = null;

  constructor(private projectService: ProjectService, private workerService: WorkerService, private taskService: TaskService) { }

  ngOnInit() {
    //get current team head:
    this.teamHead = this.workerService.getCurrentWorker();
    //get current team head's projects:
    this.projectService.getAllProjectsByTeamHead(this.teamHead.workerId).subscribe((res) => {
      this.myProjects = res;
      this.currentProject = this.myProjects[0];
      this.GetAllTasks();
    })
  }
  changeProject(event: Event) {
    //get selected project:
    let selectedOptions = event.target['options'];
    this.currentProject = this.myProjects[selectedOptions.selectedIndex];
    this.GetAllTasks();
    this.projectService.projectIdSubject.next(this.currentProject.projectId);

  }
  GetAllTasks() {
    //get current (chosen) project's tasks:
    this.taskService.getAllTasksByProjectId(this.currentProject.projectId).subscribe((res) => {
      this.currentProjectTasks = res;
    });
  }

}
