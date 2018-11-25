import { Component, OnInit } from '@angular/core';
import { Project, ProjectService, User, UserService, Task, TaskService } from 'src/app/shared/imports';

@Component({
  selector: 'app-projects-state',
  templateUrl: './projects-state.component.html',
  styleUrls: ['./projects-state.component.css']
})
export class ProjectsStateComponent implements OnInit {

  myProjects: Array<Project>;
  currentProjectTasks: Array<Task>;
  teamHead: User;
  currentProject:Project=null;

  constructor(private projectService: ProjectService, private userService: UserService, private taskService: TaskService) { }

  ngOnInit() {
     this.teamHead = this.userService.getCurrentUser();
    this.projectService.getAllProjectsByTeamHead(this.teamHead.userId).subscribe((res) => {
      this.myProjects = res;
      this.currentProject = this.myProjects[0];
      this.GetAllTasks();
    })
  }
  changeProject(event:Event){
    let selectedOptions = event.target['options'];
    this.currentProject = this.myProjects[selectedOptions.selectedIndex];
    this.GetAllTasks();
    this.projectService.projectIdSubject.next(this.currentProject.projectId);
    
  }
  GetAllTasks(){
    this.taskService.GetAllTasksByProjectId(this.currentProject.projectId).subscribe((res)=>{
      this.currentProjectTasks=res;
    });
  }

}
