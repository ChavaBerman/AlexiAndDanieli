using DAL;
using BOL;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.Types;
using System.Timers;

namespace BLL
{
    public class LogicProjects
    {

        public static List<Project> GetAllProjects()
        {
            string query = $"SELECT * FROM task.project;";

            Func<MySqlDataReader, List<Project>> func = (reader) =>
            {
                List<Project> projects = new List<Project>();
                while (reader.Read())
                {
                    projects.Add(new Project
                    {
                        ProjectId = reader.GetInt32(0),
                        ProjectName = reader.GetString(1),
                        CustomerName = reader.GetString(2),
                        QAHours = reader.GetInt32(3),
                        UIUXHours = reader.GetInt32(4),
                        DevHours = reader.GetInt32(5),
                        DateBegin = reader.GetMySqlDateTime(6).GetDateTime(),
                        DateEnd = reader.GetMySqlDateTime(7).GetDateTime(),
                        IdManager = reader.GetInt32(8),
                        IsFinish = reader.GetBoolean(9)
                    });
                }
                return projects;
            };

            return DBAccess.RunReader(query, func);
        }

        public static List<Project> GetAllProjectsByDeadLine()
        {
            string query = $"SELECT * FROM task.project where DATEDIFF(task.project.endDate,date(now()))=1;";

            Func<MySqlDataReader, List<Project>> func = (reader) =>
            {
                List<Project> projects = new List<Project>();
                while (reader.Read())
                {
                    projects.Add(new Project
                    {
                        ProjectId = reader.GetInt32(0),
                        ProjectName = reader.GetString(1),
                        CustomerName = reader.GetString(2),
                        QAHours = reader.GetInt32(3),
                        UIUXHours = reader.GetInt32(4),
                        DevHours = reader.GetInt32(5),
                        DateBegin = reader.GetMySqlDateTime(6).GetDateTime(),
                        DateEnd = reader.GetMySqlDateTime(7).GetDateTime(),
                        IdManager = reader.GetInt32(8),
                        IsFinish = reader.GetBoolean(9)
                    });
                }
                return projects;
            };

            return DBAccess.RunReader(query, func);
        }

        public static List<Project> GetAllProjectsByWorker(int workerId)
        {
            {
                string query = $"SELECT task.project.* FROM task.project join task.task on task.task.IdProject=task.project.idProject where task.task.idUser={workerId};";

                Func<MySqlDataReader, List<Project>> func = (reader) =>
                {
                    List<Project> projects = new List<Project>();
                    while (reader.Read())
                    {
                        projects.Add(new Project
                        {
                            ProjectId = reader.GetInt32(0),
                            ProjectName = reader.GetString(1),
                            CustomerName = reader.GetString(2),
                            QAHours = reader.GetInt32(3),
                            UIUXHours = reader.GetInt32(4),
                            DevHours = reader.GetInt32(5),
                            DateBegin = reader.GetMySqlDateTime(6).GetDateTime(),
                            DateEnd = reader.GetMySqlDateTime(7).GetDateTime(),
                            IdManager = reader.GetInt32(8),
                            IsFinish = reader.GetBoolean(9)
                        });
                    }
                    return projects;
                };

                return DBAccess.RunReader(query, func);
            }
        }

        public static List<Project> GetAllProjectsByTeamHead(int TeamHeadId)
        {
            {
                string query = $"SELECT * FROM task.project WHERE TeamHeadId={TeamHeadId};";

                Func<MySqlDataReader, List<Project>> func = (reader) =>
                {
                    List<Project> projects = new List<Project>();
                    while (reader.Read())
                    {
                        projects.Add(new Project
                        {
                            ProjectId = reader.GetInt32(0),
                            ProjectName = reader.GetString(1),
                            CustomerName = reader.GetString(2),
                            QAHours = reader.GetInt32(3),
                            UIUXHours = reader.GetInt32(4),
                            DevHours = reader.GetInt32(5),
                            DateBegin = reader.GetMySqlDateTime(6).GetDateTime(),
                            DateEnd = reader.GetMySqlDateTime(7).GetDateTime(),
                            IdManager = reader.GetInt32(8),
                            IsFinish = reader.GetBoolean(9)
                        });
                    }
                    return projects;
                };

                return DBAccess.RunReader(query, func);
            }
        }

        public static Project GetProjectDetails(string projectName)
        {
            string query = $"SELECT * FROM task.project WHERE name='{projectName}'";
            Func<MySqlDataReader, List<Project>> func = (reader) =>
            {
                List<Project> projects = new List<Project>();
                while (reader.Read())
                {
                    projects.Add(new Project
                    {
                        ProjectId = reader.GetInt32(0),
                        ProjectName = reader.GetString(1),
                        CustomerName = reader.GetString(2),
                        QAHours = reader.GetInt32(3),
                        UIUXHours = reader.GetInt32(4),
                        DevHours = reader.GetInt32(5),
                        DateBegin = reader.GetMySqlDateTime(6).GetDateTime(),
                        DateEnd = reader.GetMySqlDateTime(7).GetDateTime(),
                        IdManager = reader.GetInt32(8),
                        IsFinish = reader.GetBoolean(9)

                    });
                }
                return projects;
            };
            List<Project> proj = DBAccess.RunReader(query, func);
            if (proj != null && proj.Count > 0)
            {

                return proj[0];
            }
            return null;


        }


        public static Project GetProjectDetails(int projectId)
        {
            string query = $"SELECT * FROM task.project WHERE projectId={projectId}";
            Func<MySqlDataReader, List<Project>> func = (reader) =>
            {
                List<Project> projects = new List<Project>();
                while (reader.Read())
                {
                    projects.Add(new Project
                    {
                        ProjectId = reader.GetInt32(0),
                        ProjectName = reader.GetString(1),
                        CustomerName = reader.GetString(2),
                        QAHours = reader.GetInt32(3),
                        UIUXHours = reader.GetInt32(4),
                        DevHours = reader.GetInt32(5),
                        DateBegin = reader.GetMySqlDateTime(6).GetDateTime(),
                        DateEnd = reader.GetMySqlDateTime(7).GetDateTime(),
                        IdManager = reader.GetInt32(8),
                        IsFinish = reader.GetBoolean(9),
                    });
                }
                return projects;
            };

            return (DBAccess.RunReader(query, func).Count() != 0 ? DBAccess.RunReader(query, func)[0] : null);

        }

        public static decimal GetProjectState(int projectId)
        {
            string query = $"select sum(task.task.givenHours)*(task.project.QAHours+task.project.devHours+task.project.UIUXHours)/100 from task.task join task.project on task.project.idProject = task.task.idProject where task.task.idProject = {projectId}";
            return Convert.ToDecimal(DBAccess.RunScalar(query));
        }


        public static bool RemoveProject(string projectName)
        {
            //  int projectId = GetProjectDetails(projectName).Id;
            //  string query = $"DELETE FROM task.projectworker WHERE projectid={projectId}";
            //if(DBAccess.RunNonQuery(query)!=1)
            //      return false;
            //  query = $"DELETE FROM task.projectworker WHERE projectid={projectId}";
            //  if (DBAccess.RunNonQuery(query) != 1)
            //      return false;
            string query = $"DELETE FROM task.hourfordepartment WHERE Name={projectName}";
            return DBAccess.RunNonQuery(query) == 1;
        }



        public static bool AddWorkerToProject(int projectId, List<User> workers)
        {

            foreach (var item in workers)
            {
                string query = $"INSERT INTO `task`.`projectworker`(`projectId`,`workerId`)VALUES({ projectId},{ item.UserId});";
                if (DBAccess.RunNonQuery(query) != 1)
                    return false;
            }
            return true;
        }


        public static bool AddProject(Project project)
        {
            //TODO:איזה דפרטמנט
            string dateBegin = project.DateBegin.ToString("yyy-MM-dd");
            string dateEnd = project.DateEnd.ToString("yyy-MM-dd");
            string query = $"INSERT INTO `task`.`project`(`name`,`startdate`,`Enddate`,`isFinished`,`customerName`,`DevHours`,`QAHours`,`UIUXHours`,`teamheadId`) VALUES('{project.ProjectName}','{dateBegin}','{dateEnd}',{project.IsFinish},'{project.CustomerName}',{project.DevHours},{project.QAHours},{project.UIUXHours},{project.IdManager}); ";
            if (DBAccess.RunNonQuery(query) == 1)
            {
                Project currentProject = GetProjectDetails(project.ProjectName);
                foreach (BOL.Models.Task task in project.tasks)
                {
                    query = $"INSERT INTO `task`.`task`(`reservingHours`,`givenHours`,`idProject`,`idUser`)VALUES({task.ReservingHours},0,{currentProject.ProjectId},{task.IdUser });";
                    DBAccess.RunNonQuery(query);
                }
                return true;
            }
            return false;

        }

        public static void CheckDeadLine()
        {
            List<Project> deadProjects = new List<Project>();
            deadProjects = GetAllProjectsByDeadLine();
            foreach (Project proj in deadProjects)
            {
                User teamHead = new User();
                teamHead = LogicManager.GetUserDetails(proj.IdManager);
                List<User> workers = new List<User>();
                workers = LogicManager.GetAllWorkersByTeamId(proj.IdManager);
                LogicManager.sendMessage(teamHead,$"Hi {teamHead.UserName}, <br/>Project: {proj.ProjectName} is about to reach the deadline tomorrow. This project is under your responsibility, please hurry up!!!","ATTENTION");
                foreach (User worker in workers)
                {
                    LogicManager.sendMessage(worker, $"Hi {worker.UserName}, <br/>Project: {proj.ProjectName} is about to reach the deadline tomorrow. you are subscribed to this project, please hurry up!!!", "ATTENTION");
                }

            }
        }
        private static Timer aTimer;
        public static void RaiseTimer()
        {
            SetTimer();

            System.Diagnostics.Debug.WriteLine("\nPress the Enter key to exit the application...\n");
            System.Diagnostics.Debug.WriteLine("The application started at {0:HH:mm:ss.fff}", DateTime.Now);
            Console.ReadLine();
            aTimer.Stop();
            aTimer.Dispose();

            System.Diagnostics.Debug.WriteLine("Terminating the application...");
        }
        private static void SetTimer()
        {
            // Create a timer with a two second interval.
            aTimer = new Timer(1000);
            // Hook up the Elapsed event for the timer. 
            aTimer.Elapsed += OnTimedEvent;
            aTimer.AutoReset = true;
            aTimer.Enabled = true;
        }

        private static void OnTimedEvent(Object source, ElapsedEventArgs e)
        {
            System.Diagnostics.Debug.WriteLine("ll");

            if (DateTime.Now.ToShortTimeString() == "14:25")
                LogicProjects.CheckDeadLine();


        }
    }
}
