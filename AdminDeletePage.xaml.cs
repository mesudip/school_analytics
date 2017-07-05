using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using MySql.Data.MySqlClient;

namespace SEproject
{
    /// <summary>
    /// Interaction logic for AdminDeletePage.xaml
    /// </summary>
    public partial class AdminDeletePage : Page
    {
        bool checkLogin;
        public AdminDeletePage()
        {
            InitializeComponent();
            FillCombo();
        }

        private void Deletebutton_Click(object sender, RoutedEventArgs e)
        {
            bool c = checklogin1();
            try
            {
                if (c == true)
                {

                    string constring = "datasource=localhost;port=3306;username=root;password=12345";
                    string Query = "delete from school_analytics_system.staff where user_id = '" + this.Id.Text + "';";
                    MySqlConnection conDatabase = new MySqlConnection(constring);
                    MySqlCommand cmdDatabase = new MySqlCommand(Query, conDatabase);
                    MySqlDataReader myReader;

                    try
                    {
                        conDatabase.Open();
                        myReader = cmdDatabase.ExecuteReader();
                        MessageBox.Show("Data has been Deleted Successfully");
                        while (myReader.Read())
                        {
                        }


                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error in Deleting " + ex.Message);
                    }

                }
                else
                {
                    MessageBox.Show("please login as Admin first");
                }
            }
            catch
            {
                MessageBox.Show("Some Invalid Occurs");
            }
        }
        void FillCombo()
        {
            string constring = "datasource=localhost;port=3306;username=root;password=12345";
            string Query = "select * from school_analytics_system.staff  ;";
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
                    string sName = myReader.GetString("username");
                    //string sRollNo = myReader.GetString("RollNo");
                    comboBox.Items.Add(sName);




                }


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Searchbutton_Click(object sender, RoutedEventArgs e)
        {
            string constring = "datasource=localhost;port=3306;username=root;password=12345";
            string Query = "select * from school_analytics_system.staff where username= '" + comboBox.Text + "' ;";
            MySqlConnection conDatabase = new MySqlConnection(constring);
            MySqlCommand cmdDatabase = new MySqlCommand(Query, conDatabase);
            MySqlDataReader myReader;
            conDatabase.Open();

            try
            {

                myReader = cmdDatabase.ExecuteReader();
                // MessageBox.Show("Data has been Updated " + comboBox1.Text);

                if (myReader.Read())
                {
                    //MessageBox.Show("Data has been Updated");
                    //myReader.Read();
                    string username = myReader.GetString("username");
                    string user_id = myReader.GetString("user_id");
                    string address = myReader.GetString("address");
                    string smobile = myReader.GetString("mobile").ToString();
                    string gender = myReader.GetString("gender");
                    string dob = myReader.GetString("dob");
                    string email = myReader.GetString("email");
                    string fatherName = myReader.GetString("fatherName");
                    string motherName = myReader.GetString("motherName");
                    string profession = myReader.GetString("profession");


                    Id.Text = user_id;
                    Name.Text = username;
                    Address.Text = address;
                    mobile.Text = smobile;
                    Email1_Copy1.Text = gender;
                    Email1_Copy.Text = dob;
                    Email1.Text = email;
                    FatherName.Text = fatherName;
                    MotherName.Text = motherName;
                    password_Copy.Text = profession;


                    // myReader.Read();

                }



                myReader.Close();
                conDatabase.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private bool checklogin1()
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
                string constring = "datasource=localhost;port=3306;username=root;password=12345";
                string Query = "select * from school_analytics_system.staff  where user_id= '" + id + "';";
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


                        if (spassword == password && sprof == "Admin")
                        {
                            checkLogin = true;

                        }
                        else
                        {
                            checkLogin = false;
                        }



                    }
                    return (checkLogin);


                }
                catch (Exception ex)
                {

                    MessageBox.Show(ex.Message);
                    return (false);
                }
            }
        }

        private void comboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
