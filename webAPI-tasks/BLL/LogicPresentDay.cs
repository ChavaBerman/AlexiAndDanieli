using DAL;
using BOL;
using BOL.Models;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
   public class LogicPresentDay
    {

        public static List<PresentDay> GetAllPresents()
        {
            string query = $"SELECT * FROM task.PresentDayUser;";
            //TODO:לגמור לעדכן
            Func<MySqlDataReader, List<PresentDay>> func = (reader) =>
            {
                List<PresentDay> presentDays = new List<PresentDay>();
                while (reader.Read())
                {
                    presentDays.Add(new PresentDay
                    {
                        ProjectId=reader.GetInt32(0),
                        UserId = reader.GetInt32(1),
                        TimeBegin=reader.GetDateTime(2),
                        TimeEnd=reader.GetDateTime(3),
                        sumHoursDay=reader.GetInt32(4)
                    });
                }
                return presentDays;
            };

            return DBAccess.RunReader(query, func);
        }

        public static PresentDay GetPresent(int idWorker,int idProject,DateTime dateBegin)
        {
            string query = $"SELECT * FROM task.PresentDay WHERE idproject={idProject} and iduser={idWorker} and startHour='{dateBegin.ToString("yyyy-MM-dd HH:mm:ss")}'";
            Func<MySqlDataReader, List<PresentDay>> func = (reader) =>
            {
                List<PresentDay> presentDays = new List<PresentDay>();
                while (reader.Read())
                {
                    presentDays.Add(new PresentDay
                    {
                        ProjectId = reader.GetInt32(0),
                        UserId = reader.GetInt32(1),
                        TimeBegin = reader.GetMySqlDateTime(2).GetDateTime(),
                        TimeEnd = reader.GetMySqlDateTime(3).GetDateTime(),
                        sumHoursDay = reader.GetInt32(4),
                        IdPresentDay=reader.GetInt32(5)
                    });
                }
                return presentDays;
            };

            return DBAccess.RunReader(query, func)[0];
        }
        public static PresentDay GetPresentById(int id)
        {
            string query = $"SELECT * FROM task.PresentDay WHERE  IdpresentDay={id}";



            Func<MySqlDataReader, List<PresentDay>> func = (reader) =>
            {
                List<PresentDay> presentDays = new List<PresentDay>();
                while (reader.Read())
                {
                    presentDays.Add(new PresentDay
                    {
                        ProjectId = reader.GetInt32(0),
                        UserId = reader.GetInt32(1),
                        TimeBegin = reader.GetDateTime(2),
                        TimeEnd = reader.GetDateTime(3),
                        sumHoursDay = reader.GetInt32(4),
                        IdPresentDay=reader.GetInt32(5)
                    });
                }
                return presentDays;
            };

            return DBAccess.RunReader(query, func)[0];
        }

        public static bool RemovePresent(int id)
        {
            string query = $"DELETE FROM task.PresentDay WHERE presentid={id}";
            return DBAccess.RunNonQuery(query) == 1;
        }

        public static bool UpdatePresent(PresentDay presentDay)
        {
            PresentDay currentPresentDay = GetPresentById(presentDay.IdPresentDay);
            TimeSpan t = DateTime.Parse(presentDay.TimeEnd.ToLocalTime().ToString("yyyy-MM-dd HH:mm:ss")) - DateTime.Parse(currentPresentDay.TimeBegin.ToString("yyyy-MM-dd HH:mm:ss"));
            
            double addedHours = t.TotalHours;
               
            string query = $"UPDATE task.PresentDay SET EndHour='{presentDay.TimeEnd.ToLocalTime().ToString("yyyy-MM-dd HH:mm:ss")}',TotalHours={addedHours} WHERE IdPresentDay={presentDay.IdPresentDay}";
            if (DBAccess.RunNonQuery(query) == 1)
            {
                BOL.Models.Task currentTask = LogicTask.GetTaskByIdProjectAndIdUser(currentPresentDay.UserId, currentPresentDay.ProjectId);
                currentTask.GivenHours +=(decimal)addedHours;
                if (LogicTask.UpdateTask(currentTask))
                {
                   User Currentuser =LogicManager.GetUserDetails(currentPresentDay.UserId);
                    Currentuser.NumHoursWork +=(decimal) addedHours;
                  if(  LogicManager.UpdateUser(Currentuser))
                        return true;
                }
            }
            return false;
        }

        public static int AddPresent(PresentDay presentDay)
        {
            //TODO:לעדכן את סך השעות שהעובד עבד
            string query = $"INSERT INTO `task`.`PresentDay`(`IdProject`,`IdUser`,`startHour`,`EndHour`,`Totalhours`) VALUES({presentDay.ProjectId},{presentDay.UserId},'{presentDay.TimeBegin.ToLocalTime().ToString("yyyy-MM-dd HH:mm:ss tt")}','{presentDay.TimeEnd.ToLocalTime().ToString("yyyy-MM-dd HH:mm:ss")}',{presentDay.sumHoursDay}); ";
            if (DBAccess.RunNonQuery(query) == 1)
            {
                try {
                return  GetPresent(presentDay.UserId, presentDay.ProjectId, presentDay.TimeBegin.ToLocalTime()).IdPresentDay;
                }
                catch
                {
                    return 0;
                }
            }
            return 0;


        }
    }
}
