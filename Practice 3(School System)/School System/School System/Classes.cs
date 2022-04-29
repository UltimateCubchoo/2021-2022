using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using MySql.Data;
using MySql.Data.MySqlClient;

namespace School_System
{
    public class Queries
    {
        private static MySqlConnection conn = new MySqlConnection("SERVER = localhost;" +
                                                                  "USER = root;" +
                                                                  "PASSWORD = root;" +
                                                                  "DATABASE = SchoolDB;");

        public void ExecuteNonQuery(string query)
        {
            try
            {
                conn.Open();
                MySqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = query;
                cmd.ExecuteNonQuery();
                conn.Close();
            }
            catch(MySqlException ex)
            {
                conn.Close();
                throw ex;
            }
        }

        public DataTable ExecuteQuery(string query)
        {
            try
            {
                DataTable data = new DataTable("Data");
                conn.Open();
                MySqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = query;
                MySqlDataAdapter adapter = new MySqlDataAdapter(query, conn);
                adapter.Fill(data);
                conn.Close();
                return data;
            }
            catch(MySqlException ex)
            {
                conn.Close();
                throw ex;
            }
        }
            
    }

    public class Student : Queries
    {
        public int student_id { get; set; }
        public string fname { get; set; }
        public string lname { get; set; }
        public string address { get; set; }
        public string phone { get; set; }
        public string email { get; set; }

        //public void GetInfo()
        //{
        //    try
        //    {
        //        string query = $"SELECT user_id, name, type FROM users WHERE username = \'{this.username}\' && password = \'{this.password}\'";
        //        DataTable data = ExecuteQuery(query);
        //        this.student_id = Convert.ToInt32(data.Rows[0].ItemArray[0]);
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}

        public void SendToDB()
        {
            try
            {
                if (student_id == default(int))
                    throw new Exception("This item already exists in the database");
                string query = $"INSERT INTO students(first_name, last_name, address, phone, email) VALUES(\'{this.fname}\', \'{this.lname}\', \'{this.address}\', \'{this.phone}\', \'{this.email}\');";
                ExecuteNonQuery(query);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }

    public class User : Queries
    {
        public int user_id { get; set; }
        public string username { get; set; }
        public string password { get; set; }
        public string name { get; set; }
        public int type { get; set; }

        public User(string username, string password)
        {
            try
            {
                this.username = username;
                this.password = password;
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        public void GetInfo()
        {
            try
            {
                string query = $"SELECT user_id, name, type FROM users WHERE username = \'{this.username}\' && password = \'{this.password}\'";
                DataTable data = ExecuteQuery(query);
                this.user_id = Convert.ToInt32(data.Rows[0].ItemArray[0]);
                this.name = data.Rows[0].ItemArray[1].ToString();
                this.type = Convert.ToInt32(data.Rows[0].ItemArray[2]);
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        public void SendToDB()
        {
            try
            {
                if (user_id == default(int))
                    throw new Exception("This item already exists in the database");
                string query = $"INSERT INTO users(username, password, name, type ) VALUES(\'{this.username}\', \'{this.password}\', \'{this.name}\', b\'{this.type}\');";
                Queries _queries = new Queries();
                _queries.ExecuteNonQuery(query);
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        

    }
}
