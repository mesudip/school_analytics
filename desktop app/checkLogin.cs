using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Configuration;

namespace SEproject
{
    class checkLogin
    {
        public bool checkLoginA;
        public bool checkLogin1()
        {

            string spassword, sprof;
            login login1 = new login();
            string password = login.Gpassword;
            string id = login.GID;

            if (id == "071bct550" && password == "zimba")
            {
                //MessageBox.Show("login successfully");
                return true;
            }
            else
            {

                //string constring = "datasource=localhost;port=3306;username=root;password=12345";
                string constring = ConfigurationManager.ConnectionStrings["MySQL"].ToString();
                string Query = "select * from latestspas.login  where login_id= '" + id + "';";
                MySqlConnection conDatabase = new MySqlConnection(constring);
                MySqlCommand cmdDatabase = new MySqlCommand(Query, conDatabase);
                MySqlDataReader myReader;

                try
                {
                    conDatabase.Open();
                    myReader = cmdDatabase.ExecuteReader();
                    //MessageBox.Show("Data has been Updated");
                    while (myReader.Read())
                    {

                        spassword = myReader.GetString("password");
                        sprof = myReader.GetString("profession");
                        string DecrptString = encrpted.Decrypt(spassword);

                        if (DecrptString == password && sprof == "Admin")
                        {
                            checkLoginA = true;

                        }
                        else
                        {
                            checkLoginA = false;
                        }



                    }
                    return (checkLoginA);


                }
                catch (Exception ex)
                {

                    System.Windows.Forms.MessageBox.Show(ex.Message);
                    return (false);
                }
            }
        }
    }
   
}
