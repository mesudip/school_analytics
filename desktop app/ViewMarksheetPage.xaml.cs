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
    /// Interaction logic for ViewMarksheetPage.xaml
    /// </summary>
    public partial class ViewMarksheetPage : Page
    {
        
        int PassMark = 32;
        int FullMark = 100;
       
        string sRollNo, sName, sNepali, sEnglish, sMath, spop, sScience, sSocial,sopt1,sopt2,sopt3;
        int nepali, english, math, pop, science, social,opt1,opt2,opt3;

        private void textBox72_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void textBox34_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        public ViewMarksheetPage()
        {
            InitializeComponent();
            FillCombo();
            
        }

        private void comboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void button3_Click(object sender, RoutedEventArgs e)
        {
            GotoHell();


        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {

            Form1 forms = new Form1(sName, sId.Text, (comboBox.SelectedIndex + 1), nepali, english, math, pop, science, social, opt1, opt2, opt3);
            forms.ShowDialog();
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            //int total;
            string Query;
            checkLogin asw = new checkLogin();
            bool c = asw.checkLogin1();
            try
            {
                if (c)
                {
                    //try
                    //{
                       
                    //    total = Int32.Parse(textBox16.Text) + Int32.Parse(textBox17.Text) + Int32.Parse(textBox18.Text) + Int32.Parse(textBox19.Text) + Int32.Parse(textBox20.Text) + Int32.Parse(textBox31.Text)+Int32.Parse(textBox78.Text) + Int32.Parse(textBox79.Text) + Int32.Parse(textBox80.Text);

                    //}
                    //catch
                    //{
                    //    total = 0;
                    //    System.Windows.Forms.MessageBox.Show("Something is missing");
                    //}

                    // string constring = "datasource=localhost;port=3306;username=root;password=12345";
                    string constring = ConfigurationManager.ConnectionStrings["MySQL"].ToString();
                    // System.Windows.Forms.MessageBox.Show(comboxx);
                  
                    Query = "update latestspas.exam set nepali= '" + this.textBox16.Text + "', english='" + this.textBox17.Text + "', science= '" + this.textBox18.Text + "', socialStudies= '" + this.textBox20.Text + "', popAndEnvironment='" + this.textBox31.Text + "', math= '" + this.textBox19.Text + "'where  Student_idStudent='" + this.sId.Text + "' and idClass='" + (comboBox.SelectedIndex + 1) + "' ;";
                   

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
            catch
            {
                System.Windows.Forms.MessageBox.Show("Some Invalid Occurs");
            }
        }

        private void button2_Click(object sender, RoutedEventArgs e)
        {
            Form2 forms = new Form2(sName, sRollNo);
            forms.ShowDialog();
        }

        private void textBox37_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
        void FillCombo()
        {
            // string constring = "datasource=localhost;port=3306;username=root;password=12345";
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
                    sName = myReader.GetString("name");
                    sRollNo = myReader.GetString("roll_no");
                    //string sRollNo = myReader.GetString("idClass");
                    textBox37.Items.Add(sName);




                }


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button4_Click(object sender, RoutedEventArgs e)
        {
            GotoHell();

        }

        private void GotoHell()
        {
            // string constring = "datasource=localhost;port=3306;username=root;password=12345";
            string constring = ConfigurationManager.ConnectionStrings["MySQL"].ToString();
            string Query = "select * from latestspas.student where name= '" + textBox37.Text + "' ;";
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
                   
                    string sStudent = myReader.GetString("idStudent");

                    string sRollNo = myReader.GetString("roll_no");
                    textBox37_Copy.Text = sRollNo;

                    sId.Text = sStudent;
                  


                    // myReader.Read();

                }



                myReader.Close();
                conDatabase.Close();
                textBox26.Text = textBox37_Copy.Text;
                MarksheetShow();
                DateCalculate();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void MarksheetShow()
        {
            //Number_Subject = 6;
            string Query;
            //string constring = "datasource=localhost;port=3306;username=root;password=12345";
            string constring = ConfigurationManager.ConnectionStrings["MySQL"].ToString();
            Query = "select * from latestspas.exam where Student_idStudent= '" + sId.Text + "' and idClass='" + (comboBox.SelectedIndex + 1) + "' ;";

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
                    science = myReader.GetInt16("science");
                    social = myReader.GetInt16("socialStudies");
                    pop = myReader.GetInt16("popAndEnvironment");
                    opt1 = myReader.GetInt16("opt1");
                    opt2 = myReader.GetInt16("opt2");
                    opt3 = myReader.GetInt16("opt3");
                   


                    sNepali = nepali.ToString();
                    sEnglish = english.ToString();
                    sMath = math.ToString();
                    spop = pop.ToString();
                    sScience = science.ToString();
                    sSocial = social.ToString();
                    sopt1 = opt1.ToString();
                    sopt2 = opt2.ToString();
                    sopt3 = opt3.ToString();

                    string TotalObtained = (nepali + english + math + pop + science + social +opt1 +opt2 +opt3).ToString();
                    int subject = myReader.GetInt16("noSubject");

                    string TotalPassMarks = (subject * PassMark).ToString();
                    string TotalFullMarks = (subject * FullMark).ToString();
                    textBox16.Text = sNepali;
                    textBox17.Text = sEnglish;
                    textBox18.Text = sScience;
                    textBox19.Text = sMath;
                    textBox20.Text = sSocial;
                    textBox31.Text = spop;
                    textBox78.Text = sopt1;
                    textBox79.Text = sopt2;
                    textBox80.Text = sopt3;
                    textBox81.Text = TotalObtained;
                    textBox34.Text = TotalPassMarks;
                    textBox33.Text = TotalFullMarks;

                    if (subject == 7)
                    {
                        textBox72.Text = "100";
                        textBox75.Text = "32";

                    }
                    if (subject == 8)
                    {
                        textBox72.Text = "100";
                        textBox75.Text = "32";
                        textBox73.Text = "100";
                        textBox76.Text = "32";
                    }
                    if (subject == 9)
                    {
                        textBox72.Text = "100";
                        textBox75.Text = "32";
                        textBox73.Text = "100";
                        textBox76.Text = "32";
                        textBox74.Text = "100";
                        textBox77.Text = "32";
                    }


                    if (nepali < PassMark)
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
                    else if (pop < PassMark)
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
            //string constring = "datasource=localhost;port=3306;username=root;password=12345";
            string constring = ConfigurationManager.ConnectionStrings["MySQL"].ToString();
            string Query = "select * from latestspas.attendance where Student_idStudent= '" + sId.Text + "' and idClass='" + (comboBox.SelectedIndex + 1) + "' ;";

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
                    textBox41.Text = myReader.GetInt16("jan").ToString()+"/"+ myReader.GetInt16("sjan").ToString() ;
                    textBox43.Text = myReader.GetInt16("feb").ToString() + "/" + myReader.GetInt16("sfeb").ToString();
                    textBox45.Text = myReader.GetInt16("mar").ToString() + "/" + myReader.GetInt16("smar").ToString();
                    textBox47.Text = myReader.GetInt16("apr").ToString() + "/" + myReader.GetInt16("sapr").ToString();
                    textBox49.Text = myReader.GetInt16("may").ToString() + "/" + myReader.GetInt16("smay").ToString();
                    textBox51.Text = myReader.GetInt16("jun").ToString() + "/" + myReader.GetInt16("sjun").ToString();
                    textBox53.Text = myReader.GetInt16("jul").ToString() + "/" + myReader.GetInt16("sjul").ToString();
                    textBox55.Text = myReader.GetInt16("aug").ToString() + "/" + myReader.GetInt16("saug").ToString();
                    textBox57.Text = myReader.GetInt16("sep").ToString() + "/" + myReader.GetInt16("ssep").ToString();
                    textBox59.Text = myReader.GetInt16("oct").ToString() + "/" + myReader.GetInt16("soct").ToString();
                    textBox61.Text = myReader.GetInt16("nov").ToString() + "/" + myReader.GetInt16("snov").ToString();
                    textBox63.Text = myReader.GetInt16("adec").ToString() + "/" + myReader.GetInt16("sdec").ToString();




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
        
        
    }
}
