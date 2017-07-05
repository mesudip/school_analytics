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
using System.Windows.Shapes;
using MySql.Data.MySqlClient;


namespace SEproject
{
    /// <summary>
    /// Interaction logic for Window2_AddMarkSheet.xaml
    /// </summary>
    public partial class Window2_AddMarkSheet : Window
    {
        bool checkLogin;
        public Window2_AddMarkSheet( string str_Roll, string str_Name)
        {
            InitializeComponent();
            textBox38.Text = str_Roll;
            textBox37.Text = str_Name;
         // GetInfoFromParent();
        }

       private void Minimizebutton_Click(object sender, RoutedEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }

        private void CloseButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
        private void DragTitlebar(object sender, MouseButtonEventArgs e)
        {
            {
                if (e.LeftButton == MouseButtonState.Pressed)
                {
                    this.DragMove();
                }
            }
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            int total;
            bool c = checklogin1();
            try
            {
                if (c)
                {
                    try
                    {
                        total = Int32.Parse(textBox16.Text) + Int32.Parse(textBox17.Text) + Int32.Parse(textBox18.Text) + Int32.Parse(textBox19.Text) + Int32.Parse(textBox20.Text) + Int32.Parse(textBox31.Text);

                    }
                    catch
                    {
                        total = 0;
                        MessageBox.Show("Something is missing");
                    }

                    if (_class.Text == "1")
                    {
                        string constring = "datasource=localhost;port=3306;username=root;password=12345";
                        string Query = "insert into class_database.class_1 (roll_no,name,nepali, english, science, computer, social ,math, total ) values ('" + this.textBox38.Text + "','" + this.textBox37.Text + "','" + this.textBox16.Text + "','" + this.textBox17.Text + "', '" + this.textBox18.Text + "', '" + this.textBox19.Text + "', '" + this.textBox20.Text + "', '" + this.textBox31.Text + "', '" + total + "' ) ;";
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
                    else if (_class.Text == "2")
                    {
                        string constring = "datasource=localhost;port=3306;username=root;password=12345";
                        string Query = "insert into class_database.class_2 (roll_no,name,nepali, english, science, computer, social ,math ) values ('" + this.textBox38.Text + "','" + this.textBox37.Text + "','" + this.textBox16.Text + "','" + this.textBox17.Text + "', '" + this.textBox18.Text + "', '" + this.textBox19.Text + "', '" + this.textBox20.Text + "', '" + this.textBox31.Text + "') ;";
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
                        MessageBox.Show("please select Class");
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
        private void GetInfoFromParent()
        {
            try
            {
                string newRollNo = NewClassSearch.Roll_No_Student;
                string newName = NewClassSearch.name;
                MessageBox.Show(newRollNo + "hva good time");
            }
            catch {
                MessageBox.Show("Error occours");
            }
        }

        private void comboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

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


                        if (spassword == password && sprof == "Admin")
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

                    MessageBox.Show(ex.Message);
                    return (false);
                }
            }
        }

    }
}
