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
using System.IO;
using Microsoft.Win32;

namespace SEproject
{
    /// <summary>
    /// Interaction logic for Update.xaml
    /// </summary>
    public partial class Update : Page
    {
        string Gender, BusService = "No", HostelService = "No";
        bool checkLogin;
        public Update()
        {
            InitializeComponent();
            FillCombo();
        }
        void FillCombo()
        {
            string constring = "datasource=localhost;port=3306;username=root;password=12345";
            string Query = "select * from school_analytics_system.student  ;";
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
                    string sName = myReader.GetString("Name");
                    comboBox1.Items.Add(sName);

                }

           
             }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

}

        private void Male1_Checked(object sender, RoutedEventArgs e)
        {
            Gender = "Male";
        }

        private void Female1_Checked(object sender, RoutedEventArgs e)
        {
            Gender = "Female";
        }

        private void checkBox1_Checked(object sender, RoutedEventArgs e)
        {
            HostelService = "Yes";
        }

        private void checkBox_Checked(object sender, RoutedEventArgs e)
        {
            BusService = "Yes";
        }

        private void comboBox1_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void button1_Click_1(object sender, RoutedEventArgs e)
        {

        }

        private void button_Click(object sender, RoutedEventArgs e) // pressing the update button
        {
            bool c = checklogin1();
            try
            {
                if (c == true)
                {
                    string constring = "datasource=localhost;port=3306;username=root;password=12345";
                    string Query = "update school_analytics_system.student set RollNo= '" + this.RollNo.Text + "', Name='" + this.Name.Text + "', Address= '" + this.Address.Text + "', Class= '" + this.Class.Text + "', DOB='" + this.DatePicker.Text + "', FatherName= '" + this.FatherName.Text + "', Fphone= '" + this.Phone.Text + "', Fmobile= '" + this.MobileNumber.Text + "', Femail= '" + this.Email.Text + "', MotherName= '" + this.MotherName.Text + "', Mphone= '" + this.Phone1.Text + "', Mmobile= '" + this.MobileNumber1.Text + "', Memail='" + this.Email1.Text + "', Gender= '" + Gender + "' , Bus= '" + BusService + "', Hostel= '" + HostelService + "' where  RollNo='" + this.RollNo.Text + "' ;";
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
                else {
                    MessageBox.Show("please login as Admin first");
                }
                
            }
            catch {
                MessageBox.Show("Some Invalid Occurs");
            }

        }

        private void button1_Click(object sender, RoutedEventArgs e)// presssing the upload image
        {
            string constring = "datasource=localhost;port=3306;username=root;password=12345";
            string Query = "select * from school_analytics_system.student where Name= '" + comboBox1.Text + "' ;";
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
                    string sRollNo = myReader.GetString("RollNo");
                    string sName = myReader.GetString("Name");
                    string sAddress = myReader.GetString("Address");
                    string sClass = myReader.GetString("Class").ToString();
                    string sGender = myReader.GetString("Gender");
                    string sDOB = myReader.GetString("DOB");
                    string sFatherName = myReader.GetString("FatherName");
                    string sFphone = myReader.GetString("Fphone");
                    string sFmobile = myReader.GetString("Fmobile");
                    string sFemail = myReader.GetString("Femail");
                    string sMotherName = myReader.GetString("MotherName");
                    string sMphone = myReader.GetString("Mphone");
                    string sMmobile = myReader.GetString("Mmobile");
                    string sMemail = myReader.GetString("Memail");
                    string sBus = myReader.GetString("Bus");
                    string sHostel = myReader.GetString("Hostel");
                    RollNo.Text = sRollNo;
                    Name.Text = sName;
                    Address.Text = sAddress;
                    Class.Text = sClass;
                    //Gender.Text = sGender;
                    DatePicker.Text = sDOB;
                    FatherName.Text = sFatherName;
                    Phone.Text = sFphone;
                    Email.Text = sFemail;
                    MobileNumber.Text = sFmobile;
                    MotherName.Text = sMotherName;
                    Phone1.Text = sMphone;
                    MobileNumber1.Text = sMmobile;
                    Email1.Text = sMemail;
                   // checkBox.Text = sBus;
                   //checkBox1.Text = sHostel;
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

    }

      

       

        /*private void button2_Click(object sender, RoutedEventArgs e)//search Box
        {
            Stream myStream = null;
            OpenFileDialog openFileDialog1 = new OpenFileDialog();

            openFileDialog1.InitialDirectory = "c:\\Pictures";
            openFileDialog1.Filter = "JPG files (*.jpg)|*.jpg | PNG Files (*.png) |* .png|All files (*.*)|*.*";
            openFileDialog1.FilterIndex = 2;
            openFileDialog1.RestoreDirectory = true;

            if (openFileDialog1.ShowDialog() == true)
            {
                try
                {
                    if ((myStream = openFileDialog1.OpenFile()) != null)
                    {
                        using (myStream)
                        {
                            // Insert code to read the stream here.
                        }
                    }

                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: Could not read file from disk. Original error: " + ex.Message);
                }
            }



        }*/

       

      

     
    }
