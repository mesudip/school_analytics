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
    /// Interaction logic for login.xaml
    /// </summary>
    public partial class login : Page
    {
        public static string Gpassword, GID,Profession;
        

        public login()
        {
            InitializeComponent();
           
           
        }
        
        private void login_Click(object sender, RoutedEventArgs e)
        {
            
            string spassword = "" ;
            try
            {
                Gpassword = textBox1.Text;
                GID = textBox.Text;

                if (Gpassword == "" && GID =="")
                {
                    MessageBox.Show("Please Enter ID and Password");
                }
                else if (GID == "071bct550" && Gpassword == "zimba")
                {
                    //MainWindow.Login.Content = GID;

                    MessageBox.Show("login successfully");
                    MainWindow m = new MainWindow();
                    m.loginCase();



                }
                else {

                    //string myConnection = ConfigurationManager.ConnectionStrings["MySQL"].ToString();
                    //string myConnection = "datasource=localhost;port=3306;username=root;password=12345";
                    //MySqlConnection myConn = new MySqlConnection(myConnection);
                    MySqlConnection myConn=databaseBackend.databaseManager.connectDatabase();
                    MySqlDataAdapter myDataAdapter = new MySqlDataAdapter();
                    MySqlDataReader myReader;
                    MySqlCommand SelectCommand = new MySqlCommand("SELECT * FROM latestspas.login where login_id='" + this.textBox.Text + "';", myConn);

                    myConn.Open();
                    myReader = SelectCommand.ExecuteReader();
                    // int count = 0;
                    try
                    {
                        while (myReader.Read())
                        {
                            spassword = myReader.GetString("password");
                            Profession = myReader.GetString("profession");

                            // count = count + 1;



                        }
                        string sspassword = encrpted.Decrypt(spassword);
                        //MessageBox.Show(sspassword);
                        if (textBox1.Text == "")
                        {
                            MessageBox.Show("Wrong id or Password");
                            textBox.Text = "";
                            textBox1.Text = "";
                            Gpassword = textBox1.Text;
                            GID = textBox.Text;
                        }
                        else if (sspassword == this.textBox1.Text)
                        {


                            MessageBox.Show("login successfully");
                            MainWindow m = new MainWindow();
                            m.loginCase();
                        }



                        else
                        {
                            MessageBox.Show("Wrong id or Password");
                            textBox.Text = "";
                            textBox1.Text = "";
                            Gpassword = textBox1.Text;
                            GID = textBox.Text;
                        }
                    }
                    catch {
                        MessageBox.Show("Wrong id or Password");
                    }

                    myConn.Close();
                }
           

        }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }
    }
}
