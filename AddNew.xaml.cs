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
    /// Interaction logic for AddNew.xaml
    /// </summary>
    public partial class AddNew : Page
    {
        string Gender,BusService="No",HostelService="No";
        bool checkLogin;
        int studentNumber;
        public AddNew()
        {
            InitializeComponent();
        }

        private void button_Click(object sender, RoutedEventArgs e) // pressing the apply button
        {
            bool c = checklogin1();


            try
            {
                if (c==true)
                {
                    string constring = "datasource=localhost;port=3306;username=root;password=12345";
                    string Query = "insert into school_analytics_system.student (RollNo, Name, Address, Class, DOB, FatherName, Fphone, Fmobile, Femail, MotherName, Mphone, Mmobile, Memail, Gender, Bus, Hostel ) values ('" + this.RollNo.Text + "','" + this.Name.Text + "', '" + this.Address.Text + "', '" + this.Class.Text + "', '" + this.DatePicker.Text + "', '" + this.FatherName.Text + "', '" + this.Phone.Text + "', '" + this.MobileNumber.Text + "', '" + this.Email.Text + "', '" + this.MotherName.Text + "', '" + this.Phone1.Text + "', '" + this.MobileNumber1.Text + "', '" + this.Email1.Text + "', '" + Gender + "' , '" + BusService + "', '" + HostelService + "') ;";
                    MySqlConnection conDatabase = new MySqlConnection(constring);
                    MySqlCommand cmdDatabase = new MySqlCommand(Query, conDatabase);
                    MySqlDataReader myReader;

                    try
                    {
                        conDatabase.Open();
                        myReader = cmdDatabase.ExecuteReader();
                        addStudentNumber();
                        
                        MessageBox.Show("Data has been Saved Successfully");
                        while (myReader.Read())
                        {
                        }


                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Something errors occurs in Database" + ex.Message);
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
               // MessageBox.Show("login successfully");
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

        private void button1_Click(object sender, RoutedEventArgs e)// presssing the upload image
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


        }

        private void Male1_Checked(object sender, RoutedEventArgs e)
        {
            Gender = "Male";
        }

        private void checkBox1_Checked(object sender, RoutedEventArgs e)
        {
            HostelService = "Yes";
        }

        private void Female1_Checked(object sender, RoutedEventArgs e)
        {
            Gender = "Female";
        }

        private void checkBox_Checked(object sender, RoutedEventArgs e)
        {
            BusService = "Yes";
        }

        private void addStudentNumber()
        {
           // MessageBox.Show(studentNumber.ToString());
            studentNumber = searchStudentNumber();
            studentNumber += 1;
           
            
            string constring = "datasource=localhost;port=3306;username=root;password=12345";
           
             string    Query = "update class_database.studentnumber set Name ='" + "zimba" + "',studentNumber= '" + studentNumber + "';";
            
           
           // MessageBox.Show(studentNumber.ToString());
            MySqlConnection conDatabase = new MySqlConnection(constring);
            MySqlCommand cmdDatabase = new MySqlCommand(Query, conDatabase);
            MySqlDataReader myReader;

            try
            {
                conDatabase.Open();
                myReader = cmdDatabase.ExecuteReader();
               // MessageBox.Show("Data has been Updated");
                while (myReader.Read())
                {
                }


            }
            catch (Exception ex)
            {
                MessageBox.Show("Error in Updating " + ex.Message);
            }
        }
        private int searchStudentNumber()
        {
            string Query;
            string constring = "datasource=localhost;port=3306;username=root;password=12345";
           
              Query = "select * from class_database.studentnumber where Name= '" + "zimba" + "' ;";
           
            
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
                    studentNumber = myReader.GetInt32("studentNumber");





                    // myReader.Read();

                }



                myReader.Close();
                conDatabase.Close();
                return (studentNumber);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return (0);
            }
        }
    }
}
