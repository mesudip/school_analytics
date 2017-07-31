using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Configuration;

namespace databaseBackend
{
    public static  class databaseManager // cannot inherit this class
    {
        //private static int counter = 0;
        //private static readonly object obj = new object();
        //private static databaseManager instance = null;
        //public static databaseManager GetInstance
        //{
        //    get
        //    {
        //        if (instance == null)
        //        {
        //            lock (obj)
        //            {
        //                if (instance == null)
        //                {
        //                    instance = new databaseManager();
        //                }
        //            }

        //        }
        //        return instance;
        //    }

        //}
        public static MySqlConnection connectDatabase(string path = "MySQL")
        {

            string myConnection = ConfigurationManager.ConnectionStrings[path].ToString();
            //string myConnection = "datasource=localhost;port=3306;username=root;password=12345";
            MySqlConnection myConn = new MySqlConnection(myConnection);
            return myConn;
        }
    }
}
  
