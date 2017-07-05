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
    public partial class Class2 : Form
    {
        int id , GrandTotal = 0, Mgender,studentNumber;
        int stotal = 0, snepali = 0, senglish = 0, smath = 0, ssocial = 0, scomputer = 0, sscience = 0, Passresult;

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        float fsnepali, fsenglish, fsmath, fscomputer, fssocial, fsscience;
       
        public Class2()
        {
            
            InitializeComponent();
            id = searchStudentNumber();
            class_2_analysis();
            marks_analysis();
            marks_Calculation();
            studentResult();
            overall_analysis();
        }

        private void Class2_Load(object sender, EventArgs e)
        {

        }
        private void studentResult()
        {

            this.chart8.Series["Student"].Points.AddXY("Boys(" + Mgender.ToString() + ")", Mgender);
            this.chart8.Series["Student"].Points.AddXY("Girls(" + (id - Mgender).ToString() + ")", (id - Mgender));

            this.chart9.Series["Result"].Points.AddXY("Pass(" + Passresult.ToString() + ")", Passresult);
            this.chart9.Series["Result"].Points.AddXY("Fail(" + (id - Passresult).ToString() + ")", (id - Passresult));
        }

        private void marks_Calculation()
        {
            int totalStudent = id;
            Passresult = 0;
            Mgender = 0;
            
            for (int i = 1; i <= id; i++)
            {
                string constring = "datasource=localhost;port=3306;username=root;password=12345";
                string Query = "select * from class_database.class_2 where id= '" + i + "' ;";
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


                        string gender = myReader.GetString("gender");
                        string result = myReader.GetString("result");
                        if (result == "PASS")
                        {
                            Passresult += 1;
                        }


                        if (gender == "Male")
                        {
                            Mgender += 1;
                        }





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

            label2.Text = "Number of Student = " + totalStudent.ToString();
            label3.Text = "Number of Boys    = " + Mgender.ToString();
            label4.Text = "Number of Girls   = " + (totalStudent - Mgender).ToString();
            label5.Text = "Number of Passed Student = " + Passresult.ToString();

        }

        private void overall_analysis()
        {
            float ssnepali, ssenglish, ssmath, sscomputer, sssocial, ssscience;

            GrandTotal = (snepali + senglish + smath + scomputer + ssocial + sscience);
            ssnepali = ((float)snepali / (float)GrandTotal) * 100;
            ssenglish = ((float)senglish / (float)GrandTotal) * 100;
            ssmath = ((float)smath / (float)GrandTotal) * 100;
            sscomputer = ((float)scomputer / (float)GrandTotal) * 100;
            sssocial = ((float)ssocial / (float)GrandTotal) * 100;
            ssscience = ((float)sscience / (float)GrandTotal) * 100;

            this.chart7.Series["Nepali"].Points.AddXY("Nepali (" + Truncate(ssnepali, 1).ToString() + "%)", (int)ssnepali);
            this.chart7.Series["Nepali"].Points.AddXY("English(" + Truncate(ssenglish, 1).ToString() + "%)", (int)ssenglish);
            this.chart7.Series["Nepali"].Points.AddXY("Math (" + Truncate(ssmath, 1).ToString() + "%)", (int)ssmath);
            this.chart7.Series["Nepali"].Points.AddXY("Computer (" + Truncate(sscomputer, 1).ToString() + "%)", (int)sscomputer);
            this.chart7.Series["Nepali"].Points.AddXY("Social (" + Truncate(sssocial, 1).ToString() + "%)", (int)sssocial);
            this.chart7.Series["Nepali"].Points.AddXY("Science (" + Truncate(ssscience, 1).ToString() + "%)", (int)ssscience);
        }

        private void marks_analysis()
        {
            int temp;

            temp = (id * 100);
            GrandTotal = (snepali + senglish + smath + scomputer + ssocial + sscience);
            fsnepali = ((float)snepali / (float)temp) * 100;
            fsenglish = ((float)senglish / (float)temp) * 100;
            fsmath = ((float)smath / (float)temp) * 100;
            fscomputer = ((float)scomputer / (float)temp) * 100;
            fssocial = ((float)ssocial / (float)temp) * 100;
            fsscience = ((float)sscience / (float)temp) * 100;


            fsnepali = Truncate(fsnepali, 1);
            fsenglish = Truncate(fsenglish, 1);
            fsmath = Truncate(fsmath, 1);
            fscomputer = Truncate(fscomputer, 1);
            fssocial = Truncate(fssocial, 1);
            fsscience = Truncate(fssocial, 1);

            this.chart1.Series["Nepali"].Points.AddXY("nep(" + fsnepali.ToString() + "%)", (int)fsnepali);
            this.chart1.Series["Nepali"].Points.AddXY("-", 100 - (int)fsnepali);

            this.chart2.Series["English"].Points.AddXY("eng(" + fsenglish + "%)", (int)fsenglish);
            this.chart2.Series["English"].Points.AddXY("-", 100 - (int)fsenglish);

            this.chart3.Series["Math"].Points.AddXY("math(" + fsmath + "%)", (int)fsmath);
            this.chart3.Series["Math"].Points.AddXY("-", 100 - (int)fsmath);

            this.chart4.Series["Computer"].Points.AddXY("comp(" + fscomputer + "%)", (int)fscomputer);
            this.chart4.Series["Computer"].Points.AddXY("-", 100 - (int)fscomputer);

            this.chart5.Series["Social"].Points.AddXY("soc(" + fssocial + "%)", (int)fssocial);
            this.chart5.Series["Social"].Points.AddXY("-", 100 - (int)fssocial);

            this.chart6.Series["Science"].Points.AddXY("sci(" + fsscience + "%)", (int)fsscience);
            this.chart6.Series["Science"].Points.AddXY("-", 100 - (int)fsscience);


            // MessageBox.Show(fsnepali.ToString()+ " "+ fsenglish.ToString() + " " + fsmath.ToString() + " " + fscomputer.ToString() + " " + fssocial.ToString() + " " + fssocial.ToString() +" "+ GrandTotal.ToString());

        }
        public static float Truncate(float value, int digits)
        {
            double mult = Math.Pow(10.0, digits);
            double result = Math.Truncate(mult * value) / mult;
            return (float)result;
        }

        public void class_2_analysis()
        {
            int sRtotal, sRnepali, sRenglish, sRmath, sRsocial, sRcomputer, sRscience;
            for (int i = 1; i < id; i++)
            {
                string constring = "datasource=localhost;port=3306;username=root;password=12345";
                string Query = "select * from class_database.class_2 where id= '" + i + "' ;";
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

                        sRnepali = myReader.GetInt32("nepali");
                        sRenglish = myReader.GetInt32("english");
                        sRmath = myReader.GetInt32("math");
                        sRsocial = myReader.GetInt32("social");
                        sRcomputer = myReader.GetInt32("computer");
                        sRscience = myReader.GetInt32("science");
                        sRtotal = myReader.GetInt32("total");

                        snepali += sRnepali;
                        senglish += sRenglish;
                        smath += sRmath;
                        ssocial += sRsocial;
                        scomputer += sRcomputer;
                        sscience += sRscience;
                        stotal += sRtotal;




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
            // MessageBox.Show(stotal.ToString()+" " + snepali.ToString() +" " + senglish.ToString());


        }
        private int searchStudentNumber()
        {
            string Query;
            string constring = "datasource=localhost;port=3306;username=root;password=12345";

            Query = "select * from class_database.studentnumber where Name= '" + "zimba" + "' ;";


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
                    studentNumber = myReader.GetInt32("studentNumber");





                    // myReader.Read();

                }



                myReader.Close();
                conDatabase.Close();
                return (studentNumber);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return (0);
            }
        }
    }
}
