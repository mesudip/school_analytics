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
    /// Interaction logic for Add_Marksheet_Page.xaml
    /// </summary>
    public partial class Add_Marksheet_Page : Page
    {
        
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
            //string constring = "datasource=localhost;port=3306;username=root;password=12345";
            string constring = ConfigurationManager.ConnectionStrings["MySQL"].ToString();
            string Query = "select * from latestspas.student where name= '" + comboBox.Text + "' ;";
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
                    string sRollNo = myReader.GetString("roll_no");
                    string sStudentId = myReader.GetString("idStudent");
                    // sGenger = myReader.GetString("Gender");

                    sId.Text = sStudentId;
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
        

        private void comboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
        

        private void comboBox_SelectionChanged_1(object sender, SelectionChangedEventArgs e)
        {

        }
        void FillCombo()
        {
            //tring constring = "datasource=localhost;port=3306;username=root;password=12345";
             string constring = ConfigurationManager.ConnectionStrings["MySQL"].ToString();
            string Query = "select * from latestspas.student  ;";
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
                   // string sRollNo = myReader.GetString("roll_no");
                    //string sStudentId = myReader.GetString("idStudent");
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
            
            checkLogin asw = new checkLogin();

            bool c = asw.checkLogin1();
            try
            {
                if (c)
                {


                    // pass = calculatePass();

                    //try
                    //{
                    //    total = Int32.Parse(textBox16.Text) + Int32.Parse(textBox17.Text) + Int32.Parse(textBox18.Text) + Int32.Parse(textBox19.Text) + Int32.Parse(textBox20.Text) + Int32.Parse(textBox31.Text);

                    //}
                    //catch
                    //{
                    //    total = 0;
                    //    MessageBox.Show("Something is missing");
                    //}


                    int total = Int32.Parse(textBox6.Text) + Int32.Parse(textBox7.Text) + Int32.Parse(textBox8.Text) + Int32.Parse(textBox9.Text) + Int32.Parse(textBox10.Text) + Int32.Parse(textBox28.Text) + Int32.Parse(textBox40.Text) + Int32.Parse(textBox41.Text) + Int32.Parse(textBox49.Text);
                    int nosub=total / 100;
                    //string constring = "datasource=localhost;port=3306;username=root;password=12345";
                    string constring = ConfigurationManager.ConnectionStrings["MySQL"].ToString();
                        string Query = "insert into latestspas.exam (Student_idStudent,idClass,nepali, english, science,math,socialStudies,popAndEnvironment ,opt1,opt2,opt3,noSubject ) values ('" + this.sId.Text + "','" + (_class.SelectedIndex+1) + "','" + this.textBox16.Text + "','" + this.textBox17.Text + "', '" + this.textBox18.Text + "', '" + this.textBox19.Text + "', '" + this.textBox20.Text + "', '" + this.textBox31.Text + "', '" + this.textBox44.Text + "','"+ this.textBox45.Text + "','"+this.textBox51.Text+"','"+nosub+"') ;";
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

        private void sId_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}
