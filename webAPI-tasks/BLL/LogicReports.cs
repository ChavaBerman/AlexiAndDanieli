using BOL;
using BOL.HelpModel;
using BOL.Models;
using DAL;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL
{
    public class LogicReports
    {
        public static List<ReportData> CreateReport()
        {
            int id = 1;
            List<ReportData> reportDataList = new List<ReportData>();
            List<Project> projects = new List<Project>();
            projects = LogicProjects.GetAllProjects();
            foreach (Project project in projects)
            {
                int parentId = id++;
                decimal givenHoursOfProject = 0;
                List<Worker> workersOfProject = new List<Worker>();
                workersOfProject = LogicWorker.GetWorkersByProjectId(project.ProjectId);
                foreach (Worker worker in workersOfProject)
                {
                    Task task = new Task();
                    task = LogicTask.GetTaskByIdProjectAndIdWorker(worker.WorkerId, project.ProjectId);
                    ReportData reportData = new ReportData
                    {
                        Id = id++,
                        ParentId = parentId,
                        Name = worker.WorkerName,
                        TeamHeader = LogicWorker.GetWorkerDetails(project.IdTeamHead).WorkerName,
                        ReservingHours = task.ReservingHours,
                        GivenHours = task.GivenHours,
                        DateBegin = null,
                        DateEnd = null
                    };
                    givenHoursOfProject += reportData.GivenHours;
                    reportDataList.Add(reportData);
                }
                reportDataList.Add(new ReportData
                {
                    Id = parentId,
                    ParentId = 0,
                    Name = project.ProjectName,
                    TeamHeader = LogicWorker.GetWorkerDetails(project.IdTeamHead).WorkerName,
                    ReservingHours = project.QAHours + project.UIUXHours + project.DevHours,
                    GivenHours = givenHoursOfProject,
                    Customer = project.CustomerName,
                    DateBegin = project.DateBegin,
                    DateEnd = project.DateEnd,
                    Days = (project.DateEnd - project.DateBegin).Days,
                    WorkedDays = (DateTime.Now > project.DateEnd) ? (project.DateEnd - project.DateBegin).Days : (DateTime.Now - project.DateBegin).Days
                });

            }
            return reportDataList;
        }

        public static List<ReportData> FilterReport(int requiredMonth, string projectName, string teamHeadName, string workerName)
        {
            int id = 1;
            List<ReportData> reportDataList = new List<ReportData>();
            List<Project> projects = new List<Project>();
            projects = LogicProjects.GetAllProjects();
            foreach (Project project in projects)
            {
                int parentId = id++;
                Worker teamHead = LogicWorker.GetWorkerDetails(project.IdTeamHead);
                if (projectName == "ok" || project.ProjectName == projectName)
                    if (requiredMonth == 0 || project.DateBegin.Month <= requiredMonth && project.DateEnd.Month >= requiredMonth)
                        if (teamHeadName == "ok" || teamHeadName == teamHead.WorkerName)
                        {
                            decimal givenHoursOfProject = 0;
                            List<Worker> workersOfProject = new List<Worker>();
                            workersOfProject = LogicWorker.GetWorkersByProjectId(project.ProjectId);
                            foreach (Worker worker in workersOfProject)
                            {
                                Task task = new Task();
                                task = LogicTask.GetTaskByIdProjectAndIdWorker(worker.WorkerId, project.ProjectId);
                                givenHoursOfProject += task.GivenHours;
                                if (workerName == "ok" || worker.WorkerName == workerName)
                                {
                                    ReportData reportData = new ReportData
                                    {
                                        Id = id++,
                                        ParentId = parentId,
                                        Name = worker.WorkerName,
                                        TeamHeader = LogicWorker.GetWorkerDetails(project.IdTeamHead).WorkerName,
                                        ReservingHours = task.ReservingHours,
                                        GivenHours = task.GivenHours,
                                        DateBegin = null,
                                        DateEnd = null
                                    };
                                    reportDataList.Add(reportData);
                                }
                            }
                            reportDataList.Add(new ReportData
                            {
                                Id = parentId,
                                ParentId = 0,
                                Name = project.ProjectName,
                                TeamHeader = LogicWorker.GetWorkerDetails(project.IdTeamHead).WorkerName,
                                ReservingHours = project.QAHours + project.UIUXHours + project.DevHours,
                                GivenHours = givenHoursOfProject,
                                Customer = project.CustomerName,
                                DateBegin = project.DateBegin,
                                DateEnd = project.DateEnd,
                                Days = (project.DateEnd - project.DateBegin).Days,
                                WorkedDays = (DateTime.Now > project.DateEnd) ? (project.DateEnd - project.DateBegin).Days : (DateTime.Now - project.DateBegin).Days
                            });
                        }
            }
            return reportDataList;
        }
        //public static bool ExportToExcel(List<ReportData> reportDataList)
        //{

        //    StringBuilder str = new StringBuilder();

        //    str.Append("<table border=`" + "1px" + "`b>");

        //    str.Append("<tr>");

        //    str.Append("<td><b><font face=Arial Narrow size=3>FName</font></b></td>");

        //    str.Append("<td><b><font face=Arial Narrow size=3>LName</font></b></td>");

        //    str.Append("<td><b><font face=Arial Narrow size=3>Address</font></b></td>");

        //    str.Append("</tr>");

        //    foreach (ReportData val in reportDataList)

        //    {

        //        str.Append("<tr>");

        //        str.Append("<td><font face=Arial Narrow size=" + "14px" + ">" + val.FName.ToString() + "</font></td>");

        //        str.Append("<td><font face=Arial Narrow size=" + "14px" + ">" + val.LName.ToString() + "</font></td>");

        //        str.Append("<td><font face=Arial Narrow size=" + "14px" + ">" + val.Address.ToString() + "</font></td>");

        //        str.Append("</tr>");

        //    }

        //    str.Append("</table>");

        //    HttpContext.Response.AddHeader("content-disposition", "attachment; filename=Information" + DateTime.Now.Year.ToString() + ".xls");

        //    this.Response.ContentType = "application/vnd.ms-excel";

        //    byte[] temp = System.Text.Encoding.UTF8.GetBytes(str.ToString());

        //    return File(temp, "application/vnd.ms-excel");
        //}
    }
}
