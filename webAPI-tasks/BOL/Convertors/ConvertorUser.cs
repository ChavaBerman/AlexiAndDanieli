
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BOL.Convertors
{
  public class ConvertorWorker
    {
        public static Worker convertDBtoWorker(MySqlDataReader readerRow)
        {
            //TODO:לעדכן את הסטטוס של המשתמש באוביקט
            return new Worker() {
                WorkerId = readerRow.GetInt32(0),
                WorkerName = readerRow.GetString(1),
                Email = readerRow.GetString(3),
                IsNewWorker=false,
                StatusId = readerRow.GetInt32(4),
                NumHoursWork = readerRow.GetInt32(5),
                ManagerId = readerRow.GetInt32(6),
                 WorkerComputer= readerRow.GetString(7),
                statusObj=new Status()
                {
                    Id=readerRow.GetInt32(8),
                    StatusName=readerRow.GetString(9)
                }
            };
        }
        public static Worker convertDBtoWorkerWithPassword(MySqlDataReader readerRow)
        {
            //TODO:לעדכן את הסטטוס של המשתמש באוביקט
            return new Worker()
            {
                WorkerId = readerRow.GetInt32(0),
                WorkerName = readerRow.GetString(1),
                Password=readerRow.GetString(2),
                Email = readerRow.GetString(3),
                IsNewWorker = false,
                StatusId = readerRow.GetInt32(4),
                NumHoursWork = readerRow.GetInt32(5),
                ManagerId = readerRow.GetInt32(6),
                WorkerComputer = readerRow.GetString(7),
                statusObj = new Status()
                {
                    Id = readerRow.GetInt32(8),
                    StatusName = readerRow.GetString(9)
                }
            };
        }
    }
}
