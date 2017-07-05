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
    /// Interaction logic for StaffUpdate.xaml
    /// </summary>
    public partial class StaffUpdate : Page
    {
        string Gender, profession;
        bool checkLogin;
        public StaffUpdate()
        {
            InitializeComponent();
            FillCombo();
        }

      

        private void button1_Click(object sender, RoutedEventArgs e)
        {

        }

        private void comboBox_SelectionChanged_1(object sender, SelectionChangedEventArgs e)
        {
            if (comboBox.SelectedIndex == 0)
            {
                profession = "Admin";
            }
            else if (comboBox.SelectedIndex == 1)
            {
                profession = "Accountant";
            }
            else if (comboBox.SelectedIndex == 2)
            {
                profession = "Teacher";
            }
            else
            {
                profession = "Staff";
            }

        }

        private void comboBox1_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (comboBox1.SelectedIndex == 0)
            {
                Gender = "Male";
            }
            else
            {
                Gender = "Female";
            }
        }

        private void comboBox2_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void SearchButton_Click(object sender, RoutedEventArgs e)
        {
            string constring = "datasource=localhost;port=3306;username=root;password=12345";
            string Query = "select * from school_analytics_system.staff where username= '" + comboBox2.Text + "' ;";
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
                    
                    Email1.Text = email;
                    FatherName.Text = fatherName;
                    MotherName.Text = motherName;
                   


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

        private void button_Click(object sender, RoutedEventArgs e)
        {
            bool c = checklogin1();
            try
            {
                if (c)
                {

                    string constring = "datasource=localhost;port=3306;username=root;password=12345";
                    string Query = "update school_analytics_system.staff set username= '" + this.Name.Text + "', password='" + this.password.Text + "', user_id= '" + this.Id.Text + "', address= '" + this.Address.Text + "', mobile='" + this.mobile.Text + "', gender= '" + Gender + "', dob= '" + this.DatePicker.Text + "', email= '" + this.Email1.Text + "', fatherName= '" + this.FatherName.Text + "', motherName= '" + this.MotherName.Text + "', profession= '" + profession + "' ;";
                    MySqlConnection conDatabase = new MySqlConnection(constring);
                    MySqlCommand cmdDatabase = new MySqlCommand(Query, conDatabase);
                    MySqlDataReader myReader;

                    try
                    {
                        conDatabase.Open();
                        myReader = cmdDatabase.ExecuteReader();
                        MessageBox.Show("Data has been Updated");
                        while (myReader.Read())
                        {
                        }


                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error in Updating " + ex.Message);
                    }
                }
                else
                {
                    MessageBox.Show("please login as Admin first");
                }

            }
            catch {
                MessageBox.Show("Some Invalid Occurs");

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
                    comboBox2.Items.Add(sName);




                }


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
