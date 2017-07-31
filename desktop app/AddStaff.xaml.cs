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
            checkLogin asw = new checkLogin();


            bool c = asw.checkLogin1();
            try
            {
                if (c)
                {
                    //string EncrptString = encrpted.Encrypt(this.password.Text);
                    // string constring = "datasource=localhost;port=3306;username=root;password=12345";
                    string constring = ConfigurationManager.ConnectionStrings["MySQL"].ToString();
                    string Query = "insert into latestspas.staff (idStaff,name, address, mobile_number, gender, dob, email, father_name, mother_name) values ('" + this.Id.Text + "','" + this.Name.Text + "','" + this.Address.Text + "', '" + this.mobile.Text + "', '" + Gender + "', '" + this.DatePicker.Text + "', '" + this.Email1.Text + "', '" + this.FatherName.Text + "', '" + this.MotherName.Text + "') ; insert into latestspas.login (login_id, password,profession,Staff_idStaff) values ('" + this.Id.Text + "', password('" + this.password.Text+ "'),'" + profession + "','" + this.Id.Text + "');";
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
        
        
    }
}
