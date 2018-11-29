using BOL.Models;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BOL.Convertors
{
   public class ConvertorTask
    {
        public static Models.Task convertToTask(MySqlDataReader readerRow)
        {
            return new Models.Task
            {
                IdTask=readerRow.GetInt32(0),
                ReservingHours=readerRow.GetInt32(1),
                GivenHours=readerRow.GetInt32(2),
                IdProject=readerRow.GetInt32(3),
                IdWorker=readerRow.GetInt32(4),
            };
        }
        public static Models.Task convertToProjectWithProjectAndWorker(MySqlDataReader readerRow)
        {
            return new Models.Task
            {
                IdTask = readerRow.GetInt32(0),
                ReservingHours = readerRow.GetInt32(1),
                GivenHours = readerRow.GetInt32(2),
                IdProject = readerRow.GetInt32(3),
                IdWorker = readerRow.GetInt32(4),
                projectName=readerRow.GetString(5),
                workerName=readerRow.GetString(6)
                
            };
        }
    }
}
