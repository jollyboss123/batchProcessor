using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data;

namespace dinersBatchProcessor
{
    class sqlDbHelper
    {
        public static void updateSqlDb()
        {
            //connection string
            string conString = ConfigurationManager.ConnectionStrings["sqlDbcon"].ConnectionString;

            try
            {
                //sql connection object
                using (SqlConnection connection = new SqlConnection(conString))
                {
                    string spName = "";

                    //define SqlCommand object
                    SqlCommand cmd = new SqlCommand(spName, connection);

                    connection.Open();

                    //set the SQLCommand type to StoredProcedure
                    cmd.CommandType = CommandType.StoredProcedure;

                    Console.WriteLine(Environment.NewLine + "Executing stored procedure..." + DateTime.Now + Environment.NewLine);

                    //execute the stored procedure
                    cmd.ExecuteNonQuery();

                    Console.WriteLine(Environment.NewLine + "The db has been successfully updated" + DateTime.Now + Environment.NewLine);

                    connection.Close();
                }
            }
            catch (Exception exc)
            {
                //display error message
                Console.WriteLine("Exception: " + exc.Message);
            }


        }
    }
}
