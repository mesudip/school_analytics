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
    /// Interaction logic for AddNew.xaml
    /// </summary>
    public partial class AddNew : Page
    {
        public AddNew()
        {
            InitializeComponent();
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            string constring = "datasource=localhost;port=3306;username=root;password=12345";
            string Query = "insert into school_analytics_system.student ( Name, Address, Class, DOB, FatherName, Fphone, Fmobile, Femail, MotherName, Mphone, Mmobile, Memail, Gender) values ('"+this.Name.Text+"', '"+this.Address.Text+ "', '" +this.Class.Text+ "', '" +this.DateOfBirth.Text+"', '" +this.FatherName.Text+ "', '" +this.Phone.Text+ "', '" +this.MobileNumber.Text+ "', '" +this.Email.Text+ "', '" +this.MotherName.Text+ "', '" +this.Phone1.Text+ "', '" +this.MobileNumber1.Text+ "', '" +this.Email.Text+ "', '" +this.Gender.Text+ "') ;";
            MySqlConnection conDatabase = new MySqlConnection(constring);
            MySqlCommand cmdDatabase = new MySqlCommand(Query, conDatabase);
            MySqlDataReader myReader;

            try {
                conDatabase.Open();
                myReader = cmdDatabase.ExecuteReader();
                MessageBox.Show("Saved");
                while (myReader.Read())
                {
                }


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        }
    }
}
