using BOL.Models;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BOL.Convertors
{
  public  class ConvertorPresentDay
    {
        public static PresentDay convertDBtoProjectWorker(MySqlDataReader readerRow)
        {
            return new PresentDay() {
                ProjectId=readerRow.GetInt32(0),
                UserId=readerRow.GetInt32(1)
            };
        }
    }
}
