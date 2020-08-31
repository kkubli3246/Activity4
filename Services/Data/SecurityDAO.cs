using Activity1part3.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using NLog;

namespace Activity1part3.Services.Data
{
    public class SecurityDAO
    {
        public bool FindByUser(UserModel model)
        {
            string conStr = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=Test;Integrated Security=True";
            using (SqlConnection conn = new SqlConnection(conStr))
            {
                conn.Open();

                using (SqlCommand command = new SqlCommand(string.Format("Select * From Users Where USERNAME='{0}' AND PASSWORD='{1}' ",model.Username, model.Password), conn)) 
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        
                        if (reader.Read())
                        {
                            return true;
                        }
                        else
                        {
                            return false;
                        }
                    }
                }
            }
             
        }
    }
}