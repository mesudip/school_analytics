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
using System.Configuration;
using MySql.Data.MySqlClient;

namespace SEproject
{
    /// <summary>
    /// Interaction logic for HomePage.xaml
    /// </summary>
    public partial class HomePage : Page
    {
        public HomePage()
        {
            InitializeComponent();
            fillBlank();
        }

        private void fillBlank()
        {
            DateTime d1 = DateTime.Now;
            string constring = ConfigurationManager.ConnectionStrings["MySQL"].ToString();
            string Query = "select * from latestspas.remainder  ;";
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
                    
                    
                  
                    

                }


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Create_Click(object sender, RoutedEventArgs e)
        {
           
            checkLogin asw = new checkLogin();


            bool c = asw.checkLogin1();
            try
            {
                if (c)
                {
                    
                    // string constring = "datasource=localhost;port=3306;username=root;password=12345";
                    string constring = ConfigurationManager.ConnectionStrings["MySQL"].ToString();
                    string Query = "insert into latestspas.remainder (event_name, event_date, event_by, event_details, staff_idStaff ) values ('" + this.EventName.Text + "','" + this.dateInsert.Text + "','" + this.EventBy.Text + "','" + this.EventDetails.Text + "','"+ login.GID + "') ;";
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
