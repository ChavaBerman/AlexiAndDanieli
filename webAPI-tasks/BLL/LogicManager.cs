
using DAL;
using BOL;
using BOL.Convertors;
using BOL.HelpModel;
using BOL.Models;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Linq;
using System.Net.Mail;

namespace BLL
{
    public class LogicManager
    {

        public static List<User> GetAllUsers()
        {
            string query = $"SELECT * FROM task.user JOIN task.status ON task.user.IdStatus=task.status.IdStatus;";

            Func<MySqlDataReader, List<User>> func = (reader) =>
            {
                List<User> users = new List<User>();
                while (reader.Read())
                {
                    users.Add(ConvertorUser.convertDBtoUser(reader));
                }
                return users;
            };

            return DBAccess.RunReader(query, func);
        }
        public static List<User> GetAllWorkersByTeamId(int id)
        {
            string query = $"SELECT * FROM task.user JOIN task.status ON task.user.IdStatus=task.status.IdStatus WHERE managerId={id};";

            Func<MySqlDataReader, List<User>> func = (reader) =>
            {
                List<User> users = new List<User>();
                while (reader.Read())
                {
                    users.Add(ConvertorUser.convertDBtoUser(reader));
                }
                return users;
            };

            return DBAccess.RunReader(query, func);
        }
        public static List<User> GetWorkersByTeamhead(int teamHeadId)
        {
            string query = $"SELECT * FROM task.user JOIN task.status ON task.user.IdStatus=task.status.IdStatus WHERE task.user.managerId={teamHeadId};";

            Func<MySqlDataReader, List<User>> func = (reader) =>
            {
                List<User> users = new List<User>();
                while (reader.Read())
                {
                    users.Add(ConvertorUser.convertDBtoUser(reader));
                }
                return users;
            };

            return DBAccess.RunReader(query, func);
        }
        public static List<User> GetWorkersByProjectId(int projectId)
        {
            string query = $"SELECT * FROM task.user JOIN task.TASK on task.user.idUser=task.task.idUser WHERE task.task.idProject={projectId};";

            Func<MySqlDataReader, List<User>> func = (reader) =>
            {
                List<User> users = new List<User>();
                while (reader.Read())
                {
                    users.Add(ConvertorUser.convertDBtoUser(reader));
                }
                return users;
            };

            return DBAccess.RunReader(query, func);
        }
        public static List<User> GetAllowedWorkers(int teamHeadId)
        {
            string query = $"SELECT * FROM task.user JOIN task.status ON task.user.IdStatus=task.status.IdStatus WHERE task.status.statusname!='TeamHead' and task.status.statusname!='Manager' and task.user.managerId!={teamHeadId};";

            Func<MySqlDataReader, List<User>> func = (reader) =>
            {
                List<User> users = new List<User>();
                while (reader.Read())
                {
                    users.Add(ConvertorUser.convertDBtoUser(reader));
                }
                return users;
            };

            return DBAccess.RunReader(query, func);
        }
        public static List<User> GetAllTeamHeads()
        {
            string query = $"SELECT * FROM task.user JOIN task.status ON task.user.IdStatus=task.status.IdStatus WHERE task.status.statusname='TeamHead';";

            Func<MySqlDataReader, List<User>> func = (reader) =>
            {
                List<User> users = new List<User>();
                while (reader.Read())
                {
                    users.Add(ConvertorUser.convertDBtoUser(reader));
                }
                return users;
            };

            return DBAccess.RunReader(query, func);
        }
        public static List<User> GetAllWorkers()
        {
            string query = $"SELECT * FROM task.user JOIN task.status ON task.user.IdStatus=task.status.IdStatus WHERE task.status.statusname!='TeamHead' and task.status.statusname!='Manager';";

            Func<MySqlDataReader, List<User>> func = (reader) =>
            {
                List<User> users = new List<User>();
                while (reader.Read())
                {
                    users.Add(ConvertorUser.convertDBtoUser(reader));
                }
                return users;
            };

            return DBAccess.RunReader(query, func);
        }
        public static User GetUserDetails(int id)
        {
            string query = $"SELECT * FROM task.user JOIN task.status ON user.IdStatus=status.IdStatus WHERE idUser={id}";
            List<User> users = new List<User>();
            Func<MySqlDataReader, List<User>> func = (reader) =>
            {
                List<User> projectsWorker = new List<User>();
                while (reader.Read())
                {
                    projectsWorker.Add(ConvertorUser.convertDBtoUser(reader));
                }
                return projectsWorker;
            };
            List<User> users1 = DBAccess.RunReader(query, func);
            return users1.Count > 0 ? users1[0] as User : null;
        }
        public static User GetManager()
        {
            string query = "SELECT * FROM task.user JOIN task.status ON task.user.IdStatus=task.status.IdStatus WHERE task.status.statusname='Manager';";
            List<User> managers = new List<User>();
            Func<MySqlDataReader, List<User>> func = (reader) =>
            {
                List<User> manager = new List<User>();
                while (reader.Read())
                {
                    manager.Add(ConvertorUser.convertDBtoUser(reader));
                }
                return manager;
            };
            managers = DBAccess.RunReader(query, func);
            return managers.Count > 0 ? managers[0] as User : null;
        }
        public static User GetUserDetailsByPassword(string password, string userName)
        {
            //TODO:לעשות פונקציה שבודקת תווים מיוחדים עי סטור ופונקציה
            string query = $"SELECT * FROM task.user JOIN task.status ON user.IdStatus=status.IdStatus  WHERE password='{password}' and username='{userName}'";

            Func<MySqlDataReader, List<User>> func = (reader) =>
            {
                List<User> users = new List<User>();
                while (reader.Read())
                {
                    users.Add(ConvertorUser.convertDBtoUser(reader));
                }
                return users;
            };

            List<User> usersLogin = DBAccess.RunReader(query, func);
            if (usersLogin != null && usersLogin.Count > 0)
            {

                return usersLogin[0];
            }
            return null;

        }
        public static ProjectReport GetWorkerInfoForProjectReport(int projectid,int workerId)
        {
            string query = $"SELECT * FROM task.task  WHERE idProject={projectid} AND idUser={workerId}";
            List<Task> tasks = new List<Task>();
            Func<MySqlDataReader, List<Task>> func = (reader) =>
            {
                List<Task> tasksList = new List<Task>();
                while (reader.Read())
                {
                    tasksList.Add(ConvertorTask.convertToTask(reader));
                }
                return tasksList;
            };
            List<Task> currentTask = DBAccess.RunReader(query, func);
            return currentTask.Count > 0 ? new ProjectReport { GivenHours= currentTask[0].GivenHours,ReservingHours=currentTask[0].ReservingHours } : null;
        }
        public static bool RemoveUser(int id)
        {
            string query = $"DELETE FROM task.user WHERE idUser={id};";
            return DBAccess.RunNonQuery(query) == 1;
        }

        //-------------------------------------------
        public static bool UpdateUser(User user)
        {
            string query = $"UPDATE task.user SET IdStatus={user.StatusId} ,managerId={user.ManagerId},userComputer='{user.UserComputer}'  WHERE idUser={user.UserId} ;";
            return DBAccess.RunNonQuery(query) == 1;
        }
        public static bool AddUser(User user)
        {

            //TODO:איזה דפרטמנט
            string query = $"INSERT INTO `task`.`user`(`userName`,`password`,`email`,`IdStatus`,`totalhours`,`managerId`,`userComputer`) VALUES('{user.UserName}','{user.Password}','{user.Email}',{user.StatusId},{user.NumHoursWork},{user.ManagerId},'{user.UserComputer}'); ";
            return DBAccess.RunNonQuery(query) == 1;
        }
        public static User GetUserDetailsComputerUser(string computerUser)
        {
            string query = $"USE task;SELECT * FROM task.user JOIN task.status ON user.IdStatus=status.IdStatus WHERE userComputer='{computerUser}'";

            Func<MySqlDataReader, List<User>> func = (reader) =>
            {
                List<User> users = new List<User>();
                while (reader.Read())
                {
                    users.Add(ConvertorUser.convertDBtoUser(reader));

                }
                return users;
            };

            List<User> usersLogin = DBAccess.RunReader(query, func);
            if (usersLogin != null && usersLogin.Count > 0)
            {

                return usersLogin[0];
            }
            return null;
        }
        public static bool sendEmailToManager(int idUser, string message, string subject)
        {
            User manager = GetManager();
            User user = GetUserDetails(idUser);
            if (manager == null)
                return false;
            message += $"< br />< span style = 'color:red' > sincerly,{ user.UserName}< span />";
            return sendMessage(manager, message, subject);

        }
        public static bool sendMessage(User user, string message, string subject)
        {
          
            if (user == null)
                return false;
            SmtpClient client = new SmtpClient();
            client.DeliveryMethod = SmtpDeliveryMethod.Network;
            client.EnableSsl = true;
            client.Host = "smtp.gmail.com";
            client.Port = 587;
            System.Net.NetworkCredential credentials = new System.Net.NetworkCredential("task.FrishmanBerman@gmail.com", "task1234");
            client.UseDefaultCredentials = false;
            client.Credentials = credentials;
            MailMessage msg = new MailMessage();

            msg.From = new MailAddress("task.FrishmanBerman@gmail.com");
            msg.To.Add(new MailAddress(user.Email));
            msg.Subject = subject;
            msg.IsBodyHtml = true;
            msg.Body = string.Format($"<html><head>הודעה שנשלחה</head><body><p>{message}</br></p></body>");
            try
            {
                client.Send(msg);
                return true;
            }
            catch
            {
                return false;

            }
        }
    }
}


