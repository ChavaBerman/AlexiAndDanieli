using BOL;
using BOL.Convertors;
using BOL.HelpModel;
using BOL.Models;
using DAL;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class LogicTask
    {
        public static bool AddTask(BOL.Models.Task task)
        {
            string query = $"INSERT INTO `task`.`task`(`reservingHours`,`givenHours`,`idProject`,`idUser`)VALUES({task.ReservingHours},{task.GivenHours },{task.IdProject},{task.IdUser});";
            return DBAccess.RunNonQuery(query) == 1;
        }

        public static bool CheckIfExists(BOL.Models.Task task)
        {
            string query = $"SELECT * FROM task.task WHERE idProject={task.IdProject} and idUser={task.IdUser};";
            List<BOL.Models.Task> projects = new List<BOL.Models.Task>();
            Func<MySqlDataReader, List<BOL.Models.Task>> func = (reader) =>
            {
                List<BOL.Models.Task> projectsWorker = new List<BOL.Models.Task>();
                while (reader.Read())
                {
                    projectsWorker.Add(ConvertorTask.convertToTask(reader));
                }
                return projectsWorker;
            };

            List<BOL.Models.Task> ProjectWorker = DBAccess.RunReader(query, func);
            if (ProjectWorker != null && ProjectWorker.Count > 0)
                return true;
            return false;
        }

        public static List<BOL.Models.Task> GetTasksWithUserAndProjectByUserId(int userId)
        {
            string query = $"SELECT task.task.*,task.project.name,task.user.userName FROM task.task join task.user on task.user.idUser=task.task.idUser join task.project on task.project.idProject=task.task.idProject where task.task.idUser={userId};";
            Func<MySqlDataReader, List<BOL.Models.Task>> func = (reader) =>
            {
                List<BOL.Models.Task> tasks = new List<BOL.Models.Task>();
                while (reader.Read())
                {
                    tasks.Add(ConvertorTask.convertToProjectWithProjectAndUser(reader));
                }
                return tasks;
            };

            List<BOL.Models.Task> tasksList = DBAccess.RunReader(query, func);

            return tasksList;

        }

        public static BOL.Models.Task GetTaskByIdProjectAndIdUser(int userId, int projectId)
        {
            string query = $"SELECT * FROM task.task  where task.task.idUser={userId} and task.task.idProject={projectId};";
            Func<MySqlDataReader, List<BOL.Models.Task>> func = (reader) =>
            {
                List<BOL.Models.Task> tasks = new List<BOL.Models.Task>();
                while (reader.Read())
                {
                    tasks.Add(ConvertorTask.convertToTask(reader));
                }
                return tasks;
            };

            List<BOL.Models.Task> tasksList = DBAccess.RunReader(query, func);

            return tasksList[0];

        }

        public static List<BOL.Models.Task> GetTasksWithUserAndProjectByProjectId(int idProject)
        {
            string query = $"SELECT task.task.*,task.project.name,task.user.userName FROM task.task join task.user on task.user.idUser=task.task.idUser join task.project on task.project.idProject=task.task.idProject where task.task.idProject={idProject};";
            Func<MySqlDataReader, List<BOL.Models.Task>> func = (reader) =>
            {
                List<BOL.Models.Task> tasks = new List<BOL.Models.Task>();
                while (reader.Read())
                {
                    tasks.Add(ConvertorTask.convertToProjectWithProjectAndUser(reader));
                }
                return tasks;
            };

            List<BOL.Models.Task> tasksList = DBAccess.RunReader(query, func);

            return tasksList;

        }
        public static Dictionary<string,Hours> GetWorkersDictionary(int projectId)
        {
            List<BOL.Models.Task> tasks = new List<BOL.Models.Task>();
            Dictionary<string, Hours> dictionary = new Dictionary<string, Hours>();
            tasks = GetTasksWithUserAndProjectByProjectId(projectId);
            foreach (BOL.Models.Task item in tasks)
            {
                dictionary.Add(item.userName, new Hours { GivenHours = item.GivenHours, ReservingHours = item.ReservingHours });
            }
            return dictionary;
        }
        public static Dictionary<string, Hours> GetWorkerTasksDictionary(int workerId)
        {
            List<BOL.Models.Task> tasks = new List<BOL.Models.Task>();
            Dictionary<string, Hours> dictionary = new Dictionary<string, Hours>();
            tasks = GetTasksWithUserAndProjectByUserId(workerId);
            foreach (BOL.Models.Task item in tasks)
            {
                dictionary.Add(item.projectName, new Hours { GivenHours = item.GivenHours, ReservingHours = item.ReservingHours });
            }
            return dictionary;
        }
       
        public static bool UpdateTask(BOL.Models.Task task)
        {
            string query = $"UPDATE `task`.`task` SET `reservingHours` = {task.ReservingHours},`givenHours` = {task.GivenHours} WHERE `idTask` = {task.IdTask};";
            return DBAccess.RunNonQuery(query) == 1;
        }


    }
}
