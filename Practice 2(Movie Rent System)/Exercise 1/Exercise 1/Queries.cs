using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace Exercise_1
{
    class Queries
    {
        static public SqlConnection movieConn = new SqlConnection("Data Source = ZCM-797301620\\SQLEXPRESS; Database = MovieDB; Integrated Security = True;");
       
        public void ExecuteNonQuery(string query)
        {
            try
            {
                movieConn.Open();
                SqlCommand cmd = movieConn.CreateCommand();
                cmd.CommandText = query;
                cmd.ExecuteNonQuery();
                movieConn.Close();
            }
            catch(SqlException ex)
            {
                movieConn.Close();
                throw ex;
            }
        }

        public static DataTable ExecuteQuery(string query)
        {
            try
            {
                DataTable table = null;
                movieConn.Open();
                SqlCommand cmd = movieConn.CreateCommand();
                cmd.CommandText = query;
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                table = new DataTable();
                adapter.Fill(table);
                Console.WriteLine(table);
                movieConn.Close();
                return table;
            }
            catch(SqlException ex)
            {
                movieConn.Close();
                throw ex;
            }
        }
            
            
    }
}
