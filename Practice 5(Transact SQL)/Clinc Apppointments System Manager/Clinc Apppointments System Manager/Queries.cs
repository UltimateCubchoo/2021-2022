using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.Sql;
using System.Data.SqlClient;

namespace Clinc_Apppointments_System_Manager
{
    class Queries
    {
        static public SqlConnection conn = new SqlConnection("Data Source = ZCM-797301620\\SQLEXPRESS; Database = ClinicDB; Integrated Security = True;");
        public virtual void ExecuteNonQuery(string query)
        {
            try
            {
                conn.Open();
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = query;
                cmd.ExecuteNonQuery();
                conn.Close();
            }
            catch(SqlException ex)
            {
                conn.Close();
                throw ex;
            }
        }
        public static DataTable ExecuteQuery(string query)
        {
            try
            {
                DataTable table = null;
                conn.Open();
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = query;
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                table = new DataTable();
                adapter.Fill(table);
                Console.WriteLine(table);
                conn.Close();
                return table;
            }
            catch (SqlException ex)
            {
                conn.Close();
                throw ex;
            }
        }
        

    }
}
