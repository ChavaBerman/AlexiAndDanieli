using BOL;
using DAL;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
 public
        class Logicstatus
    {
        public static List<Status> GetAllstatuses()
        {
            string query = $"SELECT * FROM task.status WHERE task.status.statusName!='Manager';";

            Func<MySqlDataReader, List<Status>> func = (reader) => {
                List<Status> statuses = new List<Status>();
                while (reader.Read())
                {
                    statuses.Add(new Status
                    {
                        Id=reader.GetInt32(0),
                        StatusName =reader.GetString(1)
                    });
                }
                return statuses;
            };

            return DBAccess.RunReader(query, func);
        }
    }
}
