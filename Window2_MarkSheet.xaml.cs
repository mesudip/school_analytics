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
using System.Data;
using System.Windows.Forms;
//using System.Windows.Forms.DataVisualization.Charting;




namespace SEproject
{
       
   
    /// <summary>
    /// Interaction logic for Window2_MarkSheet.xaml
    /// </summary>
    public partial class Window2_MarkSheet : Window
    {
        
        int PassMark = 32;
        int FullMark = 100;
        int Number_Subject;
        string sRollNo, sName, sNepali, sEnglish, sMath, sComputer, sScience, sSocial;
        int nepali, english, math, computer, science, social;
        // bool check;
        bool checkLogin;
        public Window2_MarkSheet(string roll, string nameis)
        {
            InitializeComponent();
            textBox26.Text = roll;
            textBox37.Text = nameis;
            textBox37_Copy.Text = roll;
            MarksheetShow();
            DateCalculate();
        }

        private void button3_Click(object sender, RoutedEventArgs e)
        {
            string Query;
            Number_Subject = 6;
            string constring = "datasource=localhost;port=3306;username=root;password=12345";
            if (comboBox.Text == "2")
            {
                Query = "select * from class_database.class_2 where roll_no= '" + textBox26.Text + "' ;";
            }
            else if (comboBox.Text == "1")
            {
                //check = true;
                Query = "select * from class_database.class_1 where roll_no= '" + textBox26.Text + "' ;";
            }
            else {
                System.Windows.Forms.MessageBox.Show("Select class");
                Query = "select * from class_database.class_2 where roll_no= '" + textBox26.Text + "' ;";
            }

            MySqlConnection conDatabase = new MySqlConnection(constring);
            MySqlCommand cmdDatabase = new MySqlCommand(Query, conDatabase);
            MySqlDataReader myReader;

            try
            {
                conDatabase.Open();
                myReader = cmdDatabase.ExecuteReader();
                //System.Windows.Forms.MessageBox.Show("Data has been Saved Successfully");
                while (myReader.Read())
                {

                    nepali = myReader.GetInt16("nepali");
                    english = myReader.GetInt16("english");
                    math = myReader.GetInt16("math");
                    computer = myReader.GetInt16("computer");
                    science = myReader.GetInt16("science");
                    social = myReader.GetInt16("social");

                    sRollNo = myReader.GetString("roll_no");
                    sName = myReader.GetString("name");
                    sNepali = nepali.ToString();
                    sEnglish = english.ToString();
                    sMath = math.ToString();
                    sComputer = computer.ToString();
                    sScience = science.ToString();
                    sSocial = social.ToString();


                    string TotalObtained = (nepali + english + math + computer + science + social).ToString();
                    string TotalPassMarks = (Number_Subject * PassMark).ToString();
                    string TotalFullMarks = (Number_Subject * FullMark).ToString();
                    textBox16.Text = sNepali;
                    textBox17.Text = sEnglish;
                    textBox18.Text = sScience;
                    textBox19.Text = sComputer;
                    textBox20.Text = sSocial;
                    textBox31.Text = sMath;
                    textBox35.Text = TotalObtained;
                    textBox34.Text = TotalPassMarks;
                    textBox33.Text = TotalFullMarks;
                    if (nepali < 32)
                    {
                        textBox36.Text = "FAIL";
                    }

                    else if (english < PassMark)
                    {
                        textBox36.Text = "FAIL";
                    }
                    else if (math < PassMark)
                    {
                        textBox36.Text = "FAIL";
                    }
                    else if (science < PassMark)
                    {
                        textBox36.Text = "FAIL";
                    }
                    else if (computer < PassMark)
                    {
                        textBox36.Text = "FAIL";
                    }
                    else if (social < PassMark)
                    {
                        textBox36.Text = "FAIL";
                    }
                    else
                    {
                        textBox36.Text = "PASS";
                    }
                }



            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show("Something errors occurs in Database" + ex.Message);
            }



        }

      

        private void DateCalculate()
        {
            string constring = "datasource=localhost;port=3306;username=root;password=12345";
           
            string Query = "select * from school_analytics_system.attendance_class2 where roll_no= '" + this.textBox26.Text + "' ;";
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
                    //System.Windows.Forms.MessageBox.Show("Data has been Updated");
                    //myReader.Read();
                    textBox41.Text = myReader.GetInt16("sjan").ToString();
                    textBox43.Text = myReader.GetInt16("sfeb").ToString();
                    textBox45.Text = myReader.GetInt16("smar").ToString();
                    textBox47.Text = myReader.GetInt16("sapril").ToString();
                    textBox49.Text = myReader.GetInt16("smay").ToString();
                    textBox51.Text = myReader.GetInt16("sjune").ToString();
                    textBox53.Text = myReader.GetInt16("sjuly").ToString();
                    textBox55.Text = myReader.GetInt16("saug").ToString();
                    textBox57.Text = myReader.GetInt16("ssep").ToString();
                    textBox59.Text = myReader.GetInt16("soct").ToString();
                    textBox61.Text = myReader.GetInt16("snov").ToString();
                    textBox63.Text = myReader.GetInt16("sdec").ToString();




                    // myReader.Read();

                }



                myReader.Close();
                conDatabase.Close();
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }

        }

        private void comboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)

        {
            
        }

        private void button2_Click(object sender, RoutedEventArgs e)
        {
            Form2 forms = new Form2(sName, sRollNo);
            forms.ShowDialog();
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

        private void CloseButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Minimizebutton_Click(object sender, RoutedEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }

        private void ViewData_Click(object sender, RoutedEventArgs e)
        {
            
        }

      

        private void listView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            int total;
            string Query;
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
                        System.Windows.Forms.MessageBox.Show("Something is missing");
                    }

                    string constring = "datasource=localhost;port=3306;username=root;password=12345";
                    string comboxx = comboBox.Text;
                    // System.Windows.Forms.MessageBox.Show(comboxx);
                    if (comboxx == "1")
                    {
                        Query = "update class_database.class_1 set nepali= '" + this.textBox16.Text + "', english='" + this.textBox17.Text + "', science= '" + this.textBox18.Text + "', social= '" + this.textBox20.Text + "', computer='" + this.textBox19.Text + "', math= '" + this.textBox31.Text + "', total='" + total + "' where  roll_no='" + this.textBox26.Text + "' ;";
                    }
                    else
                    {
                        Query = "update class_database.class_2 set nepali= '" + this.textBox16.Text + "', english='" + this.textBox17.Text + "', science= '" + this.textBox18.Text + "', social= '" + this.textBox20.Text + "', computer='" + this.textBox19.Text + "', math= '" + this.textBox31.Text + "', , total='" + total + "' where  roll_no='" + this.textBox26.Text + "' ;";
                    }

                    MySqlConnection conDatabase = new MySqlConnection(constring);
                    MySqlCommand cmdDatabase = new MySqlCommand(Query, conDatabase);
                    MySqlDataReader myReader;

                    try
                    {
                        conDatabase.Open();
                        myReader = cmdDatabase.ExecuteReader();
                        System.Windows.Forms.MessageBox.Show("Data has been Updated");
                        while (myReader.Read())
                        {
                        }


                    }
                    catch (Exception ex)
                    {
                        System.Windows.Forms.MessageBox.Show("Error in Updating " + ex.Message);
                    }

                }
                else
                {
                    System.Windows.Forms.MessageBox.Show("please login as Admin first");
                }

            }
            catch {
                System.Windows.Forms.MessageBox.Show("Some Invalid Occurs");
            }
        }
        public void MarksheetShow()
        {
            Number_Subject = 6;
            string Query;
            string constring = "datasource=localhost;port=3306;username=root;password=12345";
            Query = "select * from class_database.class_2 where roll_no= '" + textBox26.Text + "' ;";

           // check = true;

            MySqlConnection conDatabase = new MySqlConnection(constring);
            MySqlCommand cmdDatabase = new MySqlCommand(Query, conDatabase);
            MySqlDataReader myReader;

            try
            {
                conDatabase.Open();
                myReader = cmdDatabase.ExecuteReader();
                //System.Windows.Forms.MessageBox.Show("Data has been Saved Successfully");
                while (myReader.Read())
                {
                   
                    nepali = myReader.GetInt16("nepali");
                    english = myReader.GetInt16("english");
                    math = myReader.GetInt16("math");
                    computer = myReader.GetInt16("computer");
                    science = myReader.GetInt16("science");
                    social = myReader.GetInt16("social");

                     sRollNo = myReader.GetString("roll_no");
                     sName = myReader.GetString("name");
                     sNepali =nepali.ToString();
                     sEnglish = english.ToString();
                     sMath = math.ToString();
                     sComputer = computer.ToString();
                     sScience = science.ToString();
                     sSocial = social.ToString();

                    string TotalObtained = (nepali + english + math + computer + science + social).ToString();
                    string TotalPassMarks = (Number_Subject * PassMark).ToString();
                    string TotalFullMarks = (Number_Subject * FullMark).ToString();
                    textBox16.Text = sNepali;
                    textBox17.Text = sEnglish;
                    textBox18.Text = sScience;
                    textBox19.Text = sComputer;
                    textBox20.Text = sSocial;
                    textBox31.Text = sMath;
                    textBox35.Text = TotalObtained;
                    textBox34.Text = TotalPassMarks;
                    textBox33.Text = TotalFullMarks;
                    if (nepali < 32)
                    {
                        textBox36.Text = "FAIL";
                    }
                    
                    else if (english < PassMark)
                    {
                        textBox36.Text = "FAIL";
                    }
                    else if (math < PassMark)
                    {
                        textBox36.Text = "FAIL";
                    }
                    else if (science < PassMark)
                    {
                        textBox36.Text = "FAIL";
                    }
                    else if (computer < PassMark)
                    {
                        textBox36.Text = "FAIL";
                    }
                    else if (social < PassMark)
                    {
                        textBox36.Text = "FAIL";
                    }
                    else 
                    {
                        textBox36.Text = "PASS";
                    }
                }


            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show("Something errors occurs in Database" + ex.Message);
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

                    System.Windows.Forms.MessageBox.Show(ex.Message);
                    return (false);
                }
            }
        }



        private void button1_Click(object sender, RoutedEventArgs e)
        {
            
            Form1 forms = new Form1(sName,sRollNo, nepali, english, math, computer, science, social);
            forms.ShowDialog();
        }

    }
}
