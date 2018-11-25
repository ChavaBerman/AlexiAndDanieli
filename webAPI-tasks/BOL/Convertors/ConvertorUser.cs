
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BOL.Convertors
{
  public class ConvertorUser
    {
        public static User convertDBtoUser(MySqlDataReader readerRow)
        {
            //TODO:לעדכן את הסטטוס של המשתמש באוביקט
            return new User() {
                UserId = readerRow.GetInt32(0),
                UserName = readerRow.GetString(1),
                Email = readerRow.GetString(3),
                IsNewWorker=false,
                StatusId = readerRow.GetInt32(4),
                NumHoursWork = readerRow.GetInt32(5),
                ManagerId = readerRow.GetInt32(6),
                 UserComputer= readerRow.GetString(7),
                statusObj=new Status()
                {
                    Id=readerRow.GetInt32(8),
                    StatusName=readerRow.GetString(9)
                }
            };
        }
    }
}
