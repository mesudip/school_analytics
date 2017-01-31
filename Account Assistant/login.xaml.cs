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
    /// Interaction logic for login.xaml
    /// </summary>
    public partial class login : Page
    {
        public login()
        {
            InitializeComponent();
        }
        private void login_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string myConnection = "datasource=localhost;port=3306;username=root;password=12345";
                MySqlConnection myConn = new MySqlConnection(myConnection);
                MySqlDataAdapter myDataAdapter = new MySqlDataAdapter();
                MySqlCommand SelectCommand = new MySqlCommand("SELECT * FROM school_analytics_system.staff where username='" + this.textBox1.Text + "' and password='" + this.textBox2.Text + "';", myConn);
                MySqlDataReader myReader;
                myConn.Open();
                myReader = SelectCommand.ExecuteReader();
                int count = 0;
                while (myReader.Read())
                {
                    count = count + 1;
                }
                if (count == 1)
                {
                    MessageBox.Show("login successfully");
                }
                else if (count > 1)
                {
                    MessageBox.Show("Duplicate");
                }
                else
                {
                    MessageBox.Show("Wrong Password");
                }

                myConn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }
    }
}
