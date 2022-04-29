using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace Clinc_Apppointments_System_Manager
{
    class User
    {
        public string username { get; set; }
        public string password { get; set; }
        
        public User(string username, string password)
        {
            this.username = username;
            this.password = password;
        }
        public bool checkUser()
        {
            DataTable tempTable = Queries.ExecuteQuery($"select count(user_id) from Users where username = \'{username}\' and password = \'{password}\'");
            string result = tempTable.Rows[0].ItemArray[0].ToString();
            int count = Convert.ToInt32(result);
            if (count == 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public bool checkAdmin()
        {
            DataTable tempTable = Queries.ExecuteQuery($"select * from Users where username = \'{username}\' and password = \'{password}\'");
            int adminCheck = Convert.ToInt32(tempTable.Rows[0].ItemArray[3]);
            if (adminCheck == 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}
