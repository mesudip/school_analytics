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
    /// Interaction logic for Add_Marksheet_Page.xaml
    /// </summary>
    public partial class Add_Marksheet_Page : Page
    {
        bool checkLogin;
        string sGenger;
        public Add_Marksheet_Page()
        {
            InitializeComponent();
            FillCombo();
            
        }
        private void showot()
        {
            //StudentFrame.Content = new Ad();
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            string constring = "datasource=localhost;port=3306;username=root;password=12345";
            string Query = "select * from school_analytics_system.student where Name= '" + comboBox.Text + "' ;";
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
                    string sRollNo = myReader.GetString("RollNo");

                     sGenger = myReader.GetString("Gender");


                    textBox38.Text = sRollNo;
                   

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
        private void GetInfoFromParent()
        {
            try
            {
                string newRollNo = NewClassSearch.Roll_No_Student;
                string newName = NewClassSearch.name;
                MessageBox.Show(newRollNo + "hva good time");
            }
            catch
            {
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

        private void comboBox_SelectionChanged_1(object sender, SelectionChangedEventArgs e)
        {

        }
        void FillCombo()
        {
            string constring = "datasource=localhost;port=3306;username=root;password=12345";
            string Query = "select * from school_analytics_system.student  ;";
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
                    string sName = myReader.GetString("Name");
                    string sRollNo = myReader.GetString("RollNo");
                    comboBox.Items.Add(sName);




                }


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button2_Click(object sender, RoutedEventArgs e)
        {
            int total;
            string pass;
            bool c = checklogin1();
            try
            {
                if (c)
                {


                    pass = calculatePass();

                    try
                    {
                        total = Int32.Parse(textBox16.Text) + Int32.Parse(textBox17.Text) + Int32.Parse(textBox18.Text) + Int32.Parse(textBox19.Text) + Int32.Parse(textBox20.Text) + Int32.Parse(textBox31.Text);

                    }
                    catch
                    {
                        total = 0;
                        MessageBox.Show("Something is missing");
                    }

                    if (_class.SelectedIndex == 0)
                    {
                        string constring = "datasource=localhost;port=3306;username=root;password=12345";
                        string Query = "insert into class_database.class_1 (roll_no,name,nepali, english, science, computer, social ,math, total,result,gender,numberStudent ) values ('" + this.textBox38.Text + "','" + this.comboBox.Text + "','" + this.textBox16.Text + "','" + this.textBox17.Text + "', '" + this.textBox18.Text + "', '" + this.textBox19.Text + "', '" + this.textBox20.Text + "', '" + this.textBox31.Text + "', '" + total + "','"+pass+"','"+sGenger+"','"+"1"+"' ) ;";
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
                    else if (_class.SelectedIndex == 1)
                    {

                        string constring = "datasource=localhost;port=3306;username=root;password=12345";
                        string Query = "insert into class_database.class_2 (roll_no,name,nepali, english, science, computer, social ,math,total,result, gender,numberStudent ) values ('" + this.textBox38.Text + "','" + this.comboBox.Text + "','" + this.textBox16.Text + "','" + this.textBox17.Text + "', '" + this.textBox18.Text + "', '" + this.textBox19.Text + "', '" + this.textBox20.Text + "', '" + this.textBox31.Text + "','"+total+"','"+pass+"', '"+sGenger+"','"+"2"+"') ;";
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
        private string calculatePass()
        {
            int  nepali, english, math, science, computer, social, PassMark = 32;
            nepali = Int32.Parse(textBox16.Text);
            english = Int32.Parse(textBox17.Text);
            math = Int32.Parse(textBox31.Text);
            science = Int32.Parse(textBox18.Text);
            computer = Int32.Parse(textBox19.Text);
            social = Int32.Parse(textBox20.Text);

            if (nepali < 32)
            {
                return ("FAIL");
            }

            else if (english < PassMark)
            {
                return ("FAIL");
            }
            else if (math < PassMark)
            {
                return ("FAIL");
            }
            else if (science < PassMark)
            {
                return ("FAIL");
            }
            else if (computer < PassMark)
            {
                return ("FAIL");
            }
            else if (social < PassMark)
            {
                return ("FAIL");
            }
            else
            {
                return ("PASS");
            }

        }
    }
}
