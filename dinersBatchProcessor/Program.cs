using System;
using System.Data.SqlClient;

namespace dinersBatchProcessor
{
    class Program
    {
        static void Main(string[] args)
        {
            blobStorageHelper.updateFullDinerInfo();
        }
    }
}
