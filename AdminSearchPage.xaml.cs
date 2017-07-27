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
    /// Interaction logic for AdminSearchPage.xaml
    /// </summary>
    public partial class AdminSearchPage : Page
    {
        public AdminSearchPage()
        {
            InitializeComponent();
            FillCombo();
        }

        private void comboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void Searchbutton_Click(object sender, RoutedEventArgs e)
        {
            //string constring = "datasource=localhost;port=3306;username=root;password=12345";
            string constring = ConfigurationManager.ConnectionStrings["MySQL"].ToString();
            string Query = "select * from latestspas.staff where name= '" + comboBox.Text + "' ;";
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
                   // string sprof = myReader.GetString("profession");

                    Id.Text = user_id;
                    Name.Text = username;
                    Address.Text = address;
                    mobile.Text = smobile;
                    Email1_Copy1.Text = gender;
                    Email1_Copy.Text = dob;
                    Email1.Text = email;
                    FatherName.Text = fatherName;
                    MotherName.Text = motherName;
                    //password_Copy.Text = sprof;



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
                    comboBox.Items.Add(sName);




                }


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
