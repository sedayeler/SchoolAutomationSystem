using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace OkulOtomasyonSistemi
{
    class Sql_Connection
    {
        public SqlConnection Connection()
        {
            SqlConnection connection = new SqlConnection("Data Source=LAPTOP-DGNGEDDJ\\SQLEXPRESS01;Initial Catalog=OkulOtomasyonSistemi;Integrated Security=True");
            connection.Open();
            return connection;
        }
    }
}
