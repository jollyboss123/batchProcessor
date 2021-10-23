using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dinersBatchProcessor
{
    class blobStorageHelperBaseClass
    {
        public static void updateContainer(string spName, string sourceConString)
        {
            //datetime
            string datetime = DateTime.Now.ToString("G");
            //destination
            //string destination = ConfigurationManager.AppSettings["simulateBlobCon"];

            try
            {
                //sql connection object
                using (SqlConnection connection = new SqlConnection(sourceConString))
                {
                    //SqlCommand object
                    SqlCommand cmd = new SqlCommand(spName, connection);

                    connection.Open();

                    //set the SqlCommand type to stored procedure & execute
                    cmd.CommandType = CommandType.StoredProcedure;
                    var jsonResult = new StringBuilder();
                    SqlDataReader dr = cmd.ExecuteReader();

                    StreamWriter sw = null;
                    //sw = new StreamWriter(destination);

                    Console.WriteLine(Environment.NewLine + string.Format("Retrieving data from database...{0}", datetime) + Environment.NewLine);

                    //check if there are records
                    if (dr.HasRows)
                    {
                        while (dr.Read())
                        {
                            jsonResult.Append(dr.GetValue(0).ToString());
                            Console.WriteLine(string.Format("Writing to blob...{0}\n", datetime));
                            Console.WriteLine(jsonResult);
                            //sw.Write();
                            Console.WriteLine(string.Format("Update to blob complete at {0}", datetime));
                        }
                    }
                    else
                    {
                        Console.WriteLine("No data found");
                    }

                    //close data reader
                    dr.Close();

                    connection.Close();
                }
            }
            catch (Exception exc)
            {
                //display error message
                Console.WriteLine(string.Format("Exception: {0}\n{1}", exc.Message, datetime));
            }
        }
    }
}
