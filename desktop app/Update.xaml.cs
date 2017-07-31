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
using System.Configuration;

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
            // string constring = "datasource=localhost;port=3306;username=root;password=12345";
            string constring = ConfigurationManager.ConnectionStrings["MySQL"].ToString();
            string Query = "select * from latestspas.student;";
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

            checkLogin asw = new checkLogin();
            bool c = asw.checkLogin1();
            try
            {
                if (c == true)
                {
                    string enPassword = encrpted.Encrypt(this.Password.Text);
                    // string constring = "datasource=localhost;port=3306;username=root;password=12345";
                    string constring = ConfigurationManager.ConnectionStrings["MySQL"].ToString();
                     string Query = "update latestspas.student set idStudent= '" + this.studentId.Text + "', name='" + this.Name.Text + "', address= '" + this.Address.Text + "', class= '" + this.Class.Text + "', dob='" + this.DatePicker.Text + "', father_name= '" + this.FatherName.Text + "', father_phone= '" + this.Phone.Text + "', father_mobile= '" + this.MobileNumber.Text + "', father_email= '" + this.Email.Text + "', mother_name= '" + this.MotherName.Text + "', mother_phone= '" + this.Phone1.Text + "', mother_mobile= '" + this.MobileNumber1.Text + "', mother_email='" + this.Email1.Text + "', gender= '" + Gender + "' , bus= '" + BusService + "', hostel= '" + HostelService + "' where  idStudent='" + this.studentId.Text + "' ; update latestspas.login set Student_idStudent= '" + this.studentId.Text + "', login_id= '"+this.studentId.Text+"', password='"+enPassword+"', profession='"+"student"+ "'where  Student_idStudent='" + this.studentId.Text + "' ";
                    //string Query = "update latestspas.student (idStudent, name, address, class, dob, roll_no, father_name,father_phone, father_mobile, father_email, mother_name, mother_phone, mother_mobile, mother_email, gender, bus, hostel) values ('" + this.studentId.Text + "','" + this.Name.Text + "', '" + this.Address.Text + "', '" + this.Class.Text + "', '" + this.DatePicker.Text + "', '" + this.RollNo.Text + "','" + this.FatherName.Text + "', '" + this.Phone.Text + "', '" + this.MobileNumber.Text + "', '" + this.Email.Text + "', '" + this.MotherName.Text + "', '" + this.Phone1.Text + "', '" + this.MobileNumber1.Text + "', '" + this.Email1.Text + "', '" + Gender + "' , '" + BusService + "', '" + HostelService + "') ; insert into latestspas.login (login_id, password,profession,Student_idStudent) values ('" + this.studentId.Text + "', '" + enPassword + "','" + "student" + "','" + this.studentId.Text + "');  ";
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
            // string constring = "datasource=localhost;port=3306;username=root;password=12345";
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

       

      

     
  
