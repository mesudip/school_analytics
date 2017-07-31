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
using System.Configuration;

namespace SEproject
{
    public partial class Form1 : Form
    {
        string name,id;
        int class_id;
        int[] subjects= new int[9];
        int passMark=32;
        string someValue,attentionSub;
        bool check;
        

        private void label1_Click(object sender, EventArgs e)
        {

        }

        public Form1(string sName,string sId, int classId, int nepali,int english, int math,int pop,int science,int social, int opt1,int opt2,int opt3)
        {
            InitializeComponent();
           // MessageBox.Show("Data has been Updated1 " + classId);
            name = sName;
            id = sId;
            class_id = classId;
            subjects[0] = nepali;
            subjects[1] = english;
            subjects[2] = math;
            subjects[3] = pop;
            subjects[4] = science;
            subjects[5] = social;
            subjects[6] = opt1;
            subjects[7] = opt2;
            subjects[8] = opt3;
            ShowAll();
            CalcuteDate();
        }

        private void chart1_Click(object sender, EventArgs e)
        {

        }

       

        private void chart2_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void ShowAll()

        {
            label1.Text = name + " / " + class_id ;

            this.chart1.Series["Marks"].Points.AddXY("nepali", subjects[0]);
            this.chart1.Series["Marks"].Points.AddXY("english", subjects[1]);
            this.chart1.Series["Marks"].Points.AddXY("math", subjects[2]);
            this.chart1.Series["Marks"].Points.AddXY("pop", subjects[3]);
            this.chart1.Series["Marks"].Points.AddXY("science", subjects[4]);
            this.chart1.Series["Marks"].Points.AddXY("social", subjects[5]);
            this.chart1.Series["Marks"].Points.AddXY("opt1", subjects[6]);
            this.chart1.Series["Marks"].Points.AddXY("opt2", subjects[7]);
            this.chart1.Series["Marks"].Points.AddXY("opt2", subjects[8]);



            for (int i = 0; i < subjects.Length; i++)
            {
                if(subjects[i]<50)
                {
                    if (subjects[i] < passMark && subjects[i] > 0)
                    {

                        check = false;
                        if (i == 0)
                        {
                            someValue += "Nepali";
                            check = true;
                        }


                        if (i == 1)
                        {
                            someValue += "English";
                            check = true;
                        }
                        if (i == 2)
                        {
                            someValue += "Math";
                            check = true;
                        }
                        if (i == 3)
                        {
                            someValue += "Pop & Env. ";
                            check = true;
                        }
                        if (i == 4)
                        {
                            someValue += "Science";
                            check = true;
                        }
                        if (i == 5)
                        {
                            someValue += "Social";
                            check = true;
                        }
                        if (i == 6)
                        {
                            someValue += "opt1";
                            check = true;
                        }
                        if (i == 7)
                        {
                            someValue += "opt2";
                            check = true;
                        }
                        if (i == 8)
                        {
                            someValue += "opt3";
                            check = true;
                        }
                        if (check)
                        {
                            someValue += ",";
                        }

                    }
                    else if(subjects[i] == 0)
                        {
                    }
                    else {
                        if (i == 0)
                        {
                            attentionSub += "Nepali";
                            check = true;
                        }


                        if (i == 1)
                        {
                            attentionSub += "English";
                            check = true;
                        }
                        if (i == 2)
                        {
                            attentionSub += "Math";
                            check = true;
                        }
                        if (i == 3)
                        {
                            attentionSub += "pop";
                            check = true;
                        }
                        if (i == 4)
                        {
                            attentionSub += "Science";
                            check = true;
                        }
                        if (i == 5)
                        {
                            attentionSub += "Social";
                            check = true;
                        }
                        if (i == 6)
                        {
                            attentionSub += "opt1";
                            check = true;
                        }
                        if (i == 7)
                        {
                            attentionSub += "opt2";
                            check = true;
                        }
                        if (i == 8)
                        {
                            attentionSub += "opt3";
                            check = true;
                        }
                        if (check)
                        {
                            attentionSub += ",";
                        }

                    }
                   
                }
                
            }
            label3.Text = someValue;
            label6.Text = attentionSub;
        }

        private void CalcuteDate()
        {
            // string constring = "datasource=localhost;port=3306;username=root;password=12345";
            string constring = ConfigurationManager.ConnectionStrings["MySQL"].ToString();
            string Query = "select * from latestspas.attendance where Student_idStudent= '" + id + "' and idClass='" + class_id + "' ;";
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
                    int sjan = myReader.GetInt16("sjan");
                    int sfeb = myReader.GetInt16("sfeb");
                    int smar = myReader.GetInt16("smar");
                    int sapril = myReader.GetInt16("sapr");
                    int smay = myReader.GetInt16("smay");
                    int sjune = myReader.GetInt16("sjun");
                    int sjuly = myReader.GetInt16("sjul");
                    int saug = myReader.GetInt16("saug");
                    int ssep = myReader.GetInt16("ssep");
                    int soct = myReader.GetInt16("soct");
                    int snov = myReader.GetInt16("snov");
                    int sdec = myReader.GetInt16("sdec");
                   // MessageBox.Show("Data has been Updated1 " + sdec);

                    this.chart2.Series["Attend"].Points.AddXY("Jan", sjan);
                    this.chart2.Series["Attend"].Points.AddXY("Feb", sfeb);
                    this.chart2.Series["Attend"].Points.AddXY("Mar", smar);
                    this.chart2.Series["Attend"].Points.AddXY("Apr", sapril);
                    this.chart2.Series["Attend"].Points.AddXY("May", smar);
                    this.chart2.Series["Attend"].Points.AddXY("Jun", sjune);
                    this.chart2.Series["Attend"].Points.AddXY("Jul", sjuly);
                    this.chart2.Series["Attend"].Points.AddXY("Aug", saug);
                    this.chart2.Series["Attend"].Points.AddXY("Sep", ssep);
                    this.chart2.Series["Attend"].Points.AddXY("Oct", soct);
                    this.chart2.Series["Attend"].Points.AddXY("Nov", snov);
                    this.chart2.Series["Attend"].Points.AddXY("Dec", sdec);
                   

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
