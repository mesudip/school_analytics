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
    /// Interaction logic for StaffUpdate.xaml
    /// </summary>
    public partial class StaffUpdate : Page
    {
        string Gender, profession;
        
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
            // string constring = "datasource=localhost;port=3306;username=root;password=12345";
            
            
            string constring = ConfigurationManager.ConnectionStrings["MySQL"].ToString();
            string Query = "select * from  latestspas.staff where name= '" + comboBox2.Text + "' ;";
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
                    string username = myReader.GetString("name");
                    string user_id = myReader.GetString("idStaff");
                    string address = myReader.GetString("address");
                    string smobile = myReader.GetString("mobile_number").ToString();
                    string gender = myReader.GetString("gender");
                    string dob = myReader.GetString("dob");
                    string email = myReader.GetString("email");
                    string fatherName = myReader.GetString("father_name");
                    string motherName = myReader.GetString("mother_name");
                  


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
            checkLogin asw = new checkLogin();
            bool c = asw.checkLogin1();
            try
            {
                if (c)
                {
                    string EncrptString = encrpted.Encrypt(this.password.Text);
                    //string constring = "datasource=localhost;port=3306;username=root;password=12345";
                    string constring = ConfigurationManager.ConnectionStrings["MySQL"].ToString();
                    string Query = "update latestspas.staff set name= '" + this.Name.Text + "' , idStaff= '" + this.Id.Text + "', address= '" + this.Address.Text + "', mobile_number='" + this.mobile.Text + "', gender= '" + Gender + "', dob= '" + this.DatePicker.Text + "', email= '" + this.Email1.Text + "', father_name= '" + this.FatherName.Text + "', mother_name= '" + this.MotherName.Text + "' where  idStaff='" + this.Id.Text + "' ; update latestspas.login set Staff_idStaff= '" + this.Id.Text + "', login_id= '" + this.Id.Text + "', password='" + EncrptString + "', profession='" + profession + "'where  Staff_idStaff='" + this.Id.Text + "' ";
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
       
       
        void FillCombo()
        {
            //string constring = "datasource=localhost;port=3306;username=root;password=12345";
            string constring = ConfigurationManager.ConnectionStrings["MySQL"].ToString();
            string Query = "select * from latestspas.staff  ;";
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
