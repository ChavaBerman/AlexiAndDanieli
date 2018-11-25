using BOL;
using BOL.HelpModel;
using BOL.Models;
using DAL;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;

namespace BLL
{
    public class LogicReports
    {
        public static List<ProjectReport> CreateProjectReport()
        {
            int id = 1;

            List<Project> projects = LogicProjects.GetAllProjects();
            List<ProjectReport> projectReports = new List<ProjectReport>();

            foreach (Project project in projects)
            {
                decimal reservingHoursPerProject = 0;
                int parentId = id++;
                List<User> allWorkers = new List<User>();
                allWorkers = LogicManager.GetWorkersByProjectId(project.ProjectId);
                foreach (User worker in allWorkers)
                {
                    reservingHoursPerProject += worker.NumHoursWork;
                    ProjectReport workerForProjectReport = new ProjectReport();
                    workerForProjectReport = LogicManager.GetWorkerInfoForProjectReport(project.ProjectId, worker.UserId);
                    workerForProjectReport.Name = worker.UserName;
                    workerForProjectReport.ParentId = parentId;
                    workerForProjectReport.Id = id++;
                    projectReports.Add(workerForProjectReport);
                }
                projectReports.Add(new ProjectReport { Id = parentId, Name = project.ProjectName, GivenHours = project.QAHours + project.UIUXHours + project.DevHours, ReservingHours =reservingHoursPerProject });
            }
            return projectReports;
        }

        public static List<WorkerReport> CreateWorkerReport()
        {
            int id = 1;

            List<User> workers = LogicManager.GetAllWorkers();
            List<WorkerReport> workerReports = new List<WorkerReport>();

            foreach (User worker in workers)
            {
                decimal reservingHoursPerProject = 0;
                int parentId = id++;
                List<Task> allTasks = new List<Task>();
                allTasks = LogicTask.GetTasksWithUserAndProjectByUserId(worker.UserId);
                foreach (Task task in allTasks)
                {
                    reservingHoursPerProject += task.GivenHours;
                    WorkerReport taskForWorkerReport = new WorkerReport { Id=id++,IdParent=parentId, GivenHours=task.GivenHours,Name=task.projectName};
                    workerReports.Add(taskForWorkerReport);
                }
                workerReports.Add(new WorkerReport { Id = parentId, Name = worker.UserName, GivenHours = reservingHoursPerProject });
            }
            return workerReports;
        }
    }
}
