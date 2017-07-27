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
using System.Configuration;
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
      
        public AddNew()
        {
            InitializeComponent();
        }

        private void button_Click(object sender, RoutedEventArgs e) // pressing the apply button
        {
            checkLogin asw = new checkLogin();
            bool c = asw.checkLogin1();


            try
            {
                if (c==true)
                {
                    string enPassword = encrpted.Encrypt(this.Password.Text);
                    //string constring = "datasource=localhost;port=3306;username=root;password=12345";
                    string constring = ConfigurationManager.ConnectionStrings["MySQL"].ToString();
                    string Query = "insert into latestspas.student (idStudent, name, address, class, dob, roll_no, father_name,father_phone, father_mobile, father_email, mother_name, mother_phone, mother_mobile, mother_email, gender, bus, hostel) values ('" + this.studentId.Text + "','" + this.Name.Text + "', '" + this.Address.Text + "', '" + this.Class.Text + "', '" + this.DatePicker.Text + "', '" + this.RollNo.Text + "','" + this.FatherName.Text + "', '" + this.Phone.Text + "', '" + this.MobileNumber.Text + "', '" + this.Email.Text + "', '" + this.MotherName.Text + "', '" + this.Phone1.Text + "', '" + this.MobileNumber1.Text + "', '" + this.Email1.Text + "', '" + Gender + "' , '" + BusService + "', '" + HostelService + "') ; insert into latestspas.login (login_id, password,profession,Student_idStudent) values ('" + this.studentId.Text + "', '" + enPassword + "','" + "student" + "','" + this.studentId.Text + "');  ";
                    MySqlConnection conDatabase = new MySqlConnection(constring);
                    MySqlCommand cmdDatabase = new MySqlCommand(Query, conDatabase);
                    MySqlDataReader myReader;

                    try
                    {
                        conDatabase.Open();
                        myReader = cmdDatabase.ExecuteReader();
                        //addStudentNumber();
                        
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

       
    }
}
