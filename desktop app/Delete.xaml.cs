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
using System.Configuration;

namespace SEproject
{
    /// <summary>
    /// Interaction logic for Delete.xaml
    /// </summary>
    public partial class Delete : Page
    {
       
        bool checkLogin;
        public Delete()
        {
            InitializeComponent();
            FillCombo();
        }
        void FillCombo()
        {
            //string constring = "datasource=localhost;port=3306;username=root;password=12345";
            string constring = ConfigurationManager.ConnectionStrings["MySQL"].ToString();
            string Query = "select * from latestspas.student  ;";
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
                    string sName = myReader.GetString("name");
                   
                    comboBox1.Items.Add(sName);
                   


                }


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {

            checkLogin asw = new checkLogin();
            bool c = asw.checkLogin1();
            try
            {
                if (c == true)
                {

                    // string constring = "datasource=localhost;port=3306;username=root;password=12345";
                    string constring = ConfigurationManager.ConnectionStrings["MySQL"].ToString();
                    string Query = "delete from latestspas.student where idStudent= '" + this.studentId.Text + "';";
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
                else {
                    MessageBox.Show("please login as Admin first");
                }
            }
            catch {
                MessageBox.Show("Some Invalid Occurs");
            }
        }
                private void comboBox1_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
           
           
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            //string constring = "datasource=localhost;port=3306;username=root;password=12345";
            string constring = ConfigurationManager.ConnectionStrings["MySQL"].ToString();
            string Query = "select * from latestspas.student where name= '" + comboBox1.Text + "' ;";
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
                    string sstudentId = myReader.GetString("idStudent");
                    string sRollNo = myReader.GetString("roll_no");
                    string sName = myReader.GetString("name");
                    string sAddress = myReader.GetString("address");
                    string sClass = myReader.GetString("class").ToString();
                    string sGender = myReader.GetString("gender");
                    string sDOB = myReader.GetString("dob");
                    string sFatherName = myReader.GetString("father_name");
                    string sFphone = myReader.GetString("father_phone");
                    string sFmobile = myReader.GetString("father_mobile");
                    string sFemail = myReader.GetString("father_email");
                    string sMotherName = myReader.GetString("mother_name");
                    string sMphone = myReader.GetString("mother_phone");
                    string sMmobile = myReader.GetString("mother_mobile");
                    string sMemail = myReader.GetString("mother_email");
                    string sBus = myReader.GetString("bus");
                    string sHostel = myReader.GetString("hostel");
                    studentId.Text = sstudentId;
                    RollNo.Text = sRollNo;
                    Name.Text = sName;
                    Address.Text = sAddress;
                    Class.Text = sClass;
                    Gender.Text = sGender;
                    DatePicker.Text = sDOB;
                    FatherName.Text = sFatherName;
                    Phone.Text = sFphone;
                    Email.Text = sFemail;
                    MobileNumber.Text = sFmobile;
                    MotherName.Text = sMotherName;
                    Phone1.Text = sMphone;
                    MobileNumber1.Text = sMmobile;
                    Email1.Text = sMemail;
                    Bus.Text = sBus;
                    Hostel.Text = sHostel;
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
        
    }
    }
   
