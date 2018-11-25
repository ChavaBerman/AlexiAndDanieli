import { Routes, RouterModule } from '@angular/router';

import {
    LoginComponent,
    ManagerComponent,
    AddWorkerComponent,
    ManageTeamComponent,
    ManageReportsComponent,
    AddProjectComponent,
    EditWorkerComponent,
    SetPermissionComponent,
    ManagerHomeComponent,
    TeamHeadComponent,
    TeamHeadHomeComponent,
    HoursChartComponent,
    ProjectsStateComponent,
    UpdateHoursComponent,
    WorkerComponent,
    WorkerHomeComponent,
    ApplyToManagerComponent,
    MyTasksComponent,
    MyHoursComponent,

} from './shared/imports';

const appRoutes: Routes = [
    {

        path: 'taskManagement', children: [
            {
                path: 'login', component: LoginComponent
            },
            {
                path: 'manager', component: ManagerComponent, children: [
                    { path: 'manage-reports', component: ManageReportsComponent },
                    { path: '', component: ManagerHomeComponent },
                    { path: 'manage-team', component: ManageTeamComponent },
                    { path: 'manage-users/add-worker', component: AddWorkerComponent },
                    { path: 'manage-users/set-permission', component: SetPermissionComponent },
                    { path: 'manage-users/edit-worker', component: EditWorkerComponent },
                    { path: 'add-project', component: AddProjectComponent }
                ]
            },
            {
                path: 'teamHead', component: TeamHeadComponent, children: [
                    { path: '', component: TeamHeadHomeComponent },
                    { path: 'hours-chart', component: HoursChartComponent },
                    { path: 'projects-state', component: ProjectsStateComponent },
                    { path: 'update-hours', component: UpdateHoursComponent }
                ]
            },
            {
                path: 'worker', component: WorkerComponent, children: [
                    { path: '', component: WorkerHomeComponent },
                    { path: 'apply-to-manager', component: ApplyToManagerComponent },
                    { path: 'my-tasks', component: MyTasksComponent },
                    { path: 'my-hours', component: MyHoursComponent }
                ]
            }
           
        ]
    },
    { path: '', component: LoginComponent },
    // // otherwise redirect to LoginComponent
    { path: '**', component: LoginComponent }
];

export const AppRoutingModule = RouterModule.forRoot(appRoutes);