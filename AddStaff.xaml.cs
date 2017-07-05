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
    /// Interaction logic for AddStaff.xaml
    /// </summary>
    public partial class AddStaff : Page
    {
        string Gender, profession;
        bool checkLogin;
       // int studentNumber;
        public AddStaff()
        {
            InitializeComponent();
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

            //MessageBox.Show(profession);


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
           // MessageBox.Show(Gender);
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
           
            bool c = checklogin1();
            try
            {
                if (c)
                {
                    string EncrptString = encrpted.Encrypt(this.password.Text);   
                    string constring = "datasource=localhost;port=3306;username=root;password=12345";
                    string Query = "insert into school_analytics_system.staff (username, password, user_id, address, mobile, gender, dob, email, fatherName, motherName, profession ) values ('" + this.Name.Text + "','" + EncrptString + "', '" + this.Id.Text + "', '" + this.Address.Text + "', '" + this.mobile.Text + "', '" + Gender + "', '" + this.DatePicker.Text + "', '" + this.Email1.Text + "', '" + this.FatherName.Text + "', '" + this.MotherName.Text + "', '" + profession + "') ;";
                    MySqlConnection conDatabase = new MySqlConnection(constring);
                    MySqlCommand cmdDatabase = new MySqlCommand(Query, conDatabase);
                    MySqlDataReader myReader;

                    try
                    {
                        conDatabase.Open();
                        myReader = cmdDatabase.ExecuteReader();
                        
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
            catch
            {
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
                       string DecrptString = encrpted.Decrypt(spassword);

                        if (DecrptString == password && sprof == "Admin")
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

                    System.Windows.Forms.MessageBox.Show(ex.Message);
                    return (false);
                }
            }
        }
        
    }
}
