using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.IO;

namespace dinersBatchProcessor
{
    class blobStorageHelper : blobStorageHelperBaseClass
    {
        public static void updateFullDinerInfo() => updateContainer("dbo.spGetFullDinerInfo", ConfigurationManager.ConnectionStrings["sqlDbCon"].ConnectionString);

        public static void updateOperatingHoursContainer() => updateContainer("spGetAllDinersOperatingHours", ConfigurationManager.ConnectionStrings["sqlDbCon"].ConnectionString);
    }
}
