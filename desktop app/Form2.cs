using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
namespace SEproject
{
    public partial class Form2 : Form
    {
        string roll_no, name;
        int[] subjects = new int[6];
        int[] subjects_class_1 = new int[6];
        int passMark = 32;
       
        int Number_Subject = 6;
       int TotalObtained_class1, TotalObtained_class2;
        string improved, improveRequire;


        public Form2(string sName, string sRollNo)
        {
            InitializeComponent();
            name = sName;
            roll_no = sRollNo;
            
            TotalObtained_class2 = (subjects[0] + subjects[1] + subjects[2] + subjects[3] + subjects[4] + subjects[5]);
            from_class_1();
            from_class_2();
            ShowAll();
            improvedSub();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void ShowAll()
        {
            label1.Text = name + " / " + roll_no;

            this.chart1.Series["Class 2"].Points.AddXY("Nepali", subjects[0]);
            this.chart1.Series["Class 1"].Points.AddXY("", subjects_class_1[0]);

            this.chart1.Series["Class 2"].Points.AddXY("English", subjects[1]);
            this.chart1.Series["Class 1"].Points.AddXY("", subjects_class_1[1]);

            this.chart1.Series["Class 2"].Points.AddXY("Math", subjects[2]);
            this.chart1.Series["Class 1"].Points.AddXY("", subjects_class_1[2]);

            this.chart1.Series["Class 2"].Points.AddXY("Computer", subjects[3]);
            this.chart1.Series["Class 1"].Points.AddXY("", subjects_class_1[3]);

            this.chart1.Series["Class 2"].Points.AddXY("Science", subjects[4]);
            this.chart1.Series["Class 1"].Points.AddXY("", subjects_class_1[4]);

            this.chart1.Series["Class 2"].Points.AddXY("Social", subjects[5]);
            this.chart1.Series["Class 1"].Points.AddXY("", subjects_class_1[5]);

            float temp = (TotalObtained_class1)/6;
            float temp2 = (TotalObtained_class2)/6;
            float bigtemp = temp2 - temp;




            if (bigtemp <= 0)
            {
                label7.Text = "decreased " + bigtemp.ToString() + "%";
            }
            else
            {
                label7.Text = "increased " + bigtemp.ToString() + "%";
            }
            label9.Text =temp.ToString() + "%";
            label11.Text = temp2.ToString() + "%";
            
           
        }
        private void from_class_1()
        {

         
            string constring = "datasource=localhost;port=3306;username=root;password=12345";
            string Query = "select * from class_database.class_1 where roll_no= '" + roll_no + "' ;";
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

                    subjects_class_1[0] = myReader.GetInt16("nepali");
                    subjects_class_1[1] = myReader.GetInt16("english");
                    subjects_class_1[2] = myReader.GetInt16("math");
                    subjects_class_1[3] = myReader.GetInt16("computer");
                    subjects_class_1[4] = myReader.GetInt16("science");
                    subjects_class_1[5] = myReader.GetInt16("social");

                  //  sRollNo = myReader.GetString("roll_no");
                   // sName = myReader.GetString("name");
                    

                   TotalObtained_class1 = (subjects_class_1[0] + subjects_class_1[1] + subjects_class_1[2] + subjects_class_1[3] + subjects_class_1[4] + subjects_class_1[5]);
                    
                  
                   
                }


            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show("Something errors occurs in Database" + ex.Message);
            }
        }
        private void from_class_2()
        {


            string constring = "datasource=localhost;port=3306;username=root;password=12345";
            string Query = "select * from class_database.class_2 where roll_no= '" + roll_no + "' ;";
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

                    subjects[0] = myReader.GetInt16("nepali");
                    subjects[1] = myReader.GetInt16("english");
                    subjects[2] = myReader.GetInt16("math");
                    subjects[3] = myReader.GetInt16("computer");
                    subjects[4] = myReader.GetInt16("science");
                    subjects[5] = myReader.GetInt16("social");

                    //  sRollNo = myReader.GetString("roll_no");
                    // sName = myReader.GetString("name");


                    TotalObtained_class2 = (subjects[0] + subjects[1] + subjects[2] + subjects[3] + subjects[4] + subjects[5]);



                }


            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show("Something errors occurs in Database" + ex.Message);
            }
        }
        private void improvedSub()
        {
            for(int i =0; i<6; i++)
            {
                if (subjects_class_1[i] >= subjects[i])
                {
                    if (i == 0) {
                        improveRequire += "Nepali,";
                    }
                    if (i == 1)
                    {
                        improveRequire += "English,";
                    }
                    if (i == 2)
                    {
                        improveRequire += "Math,";
                    }
                    if (i == 3)
                    {
                        improveRequire += "Computer,";
                    }
                    if (i == 4)
                    {
                        improveRequire += "Science,";
                    }
                    if (i == 5)
                    {
                        improveRequire += "Social,";
                    }
                   


                }
                else
                {
                    if (i == 0)
                    {
                        improved += "Nepali,";
                    }
                    if (i == 1)
                    {
                        improved += "English,";
                    }
                    if (i == 2)
                    {
                        improved += "Math,";
                    }
                    if (i == 3)
                    {
                        improved += "Computer,";
                    }
                    if (i == 4)
                    {
                        improved += "Science,";
                    }
                    if (i == 5)
                    {
                        improved += "Social,";
                    }
                }
              
            }
            label3.Text = improved;
            label5.Text = improveRequire;
        }
    }
}
