import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { HttpClientModule } from '@angular/common/http'
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { ReactiveFormsModule, FormsModule } from '@angular/forms';
import { ChartsModule } from "ng2-charts/ng2-charts";
import { SimpleTimer } from 'ng2-simple-timer';
import {TreeTableModule} from 'primeng/treetable';

import {
  ManagerComponent,
  LoginComponent,
  UserService,
  ReportService,
  MainComponent,
  HeaderComponent,
  FooterComponent,
  AddProjectComponent,
  AddWorkerComponent,
  EditWorkerComponent,
  ManageReportsComponent,
  ManageTeamComponent,
  SetPermissionComponent,
  ManagerHomeComponent,
  StatusService,
  ProjectService,
  TaskService,
  TeamHeadComponent,
  TeamHeadHomeComponent,
  HoursChartComponent,
  ProjectsStateComponent,
  UpdateHoursComponent,
  TaskDetailsComponent,
  UpdateHoursTaskComponent,
  ProjectChartComponent,
  WorkerComponent,
  WorkerHomeComponent,
  ApplyToManagerComponent,
  MyTasksComponent,
  MyHoursComponent,
  BeginEndTaskComponent,
  PresentDayService,
  TaskDetailsForWorkerComponent,
  ClockComponent,
  ProjectReportComponent,
  ProjectWorkersReportComponent,
  WorkersReportComponent
} from './shared/imports';




@NgModule({
  declarations: [
    AppComponent,
    LoginComponent,
    ManagerComponent,
    MainComponent,
    FooterComponent,
    HeaderComponent,
    AddWorkerComponent,
    AddProjectComponent,
    SetPermissionComponent,
    EditWorkerComponent,
    ManageTeamComponent,
    ManageReportsComponent,
    ManagerHomeComponent,
    TeamHeadComponent,
    TeamHeadHomeComponent,
    HoursChartComponent,
    ProjectsStateComponent,
    UpdateHoursComponent,
    TaskDetailsComponent,
    UpdateHoursTaskComponent,
    ProjectChartComponent,
    WorkerComponent,
    WorkerHomeComponent,
    ApplyToManagerComponent,
    MyTasksComponent,
    MyHoursComponent,
    BeginEndTaskComponent,
    TaskDetailsForWorkerComponent,
    ClockComponent,
    ProjectReportComponent,
    ProjectWorkersReportComponent,
    WorkersReportComponent,
    


  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    ReactiveFormsModule,
    FormsModule,
    HttpClientModule,
    ChartsModule,
    TreeTableModule
  ],
  providers: [UserService, StatusService, ProjectService, ReportService,TaskService,PresentDayService,SimpleTimer],
  bootstrap: [AppComponent]
})
export class AppModule { }
