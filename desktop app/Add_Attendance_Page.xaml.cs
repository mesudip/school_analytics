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
    /// Interaction logic for Add_Attendance_Page.xaml
    /// </summary>
    public partial class Add_Attendance_Page : Page
    {
        public Add_Attendance_Page()
        {
            InitializeComponent();
            FillCombo();
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            //string constring = "datasource=localhost;port=3306;username=root;password=12345";
            string constring = ConfigurationManager.ConnectionStrings["MySQL"].ToString();
            string Query = "select * from latestspas.student where name= '" + comboBox1.Text + "' ;";
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
                    string sstudentId = myReader.GetString("idStudent");




                    sId.Text = sstudentId;


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

        private void comboBox1_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
        void FillCombo()
        {
            //string constring = "datasource=localhost;port=3306;username=root;password=12345";
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
                   // string sRollNo = myReader.GetString("RollNo");
                    comboBox1.Items.Add(sName);




                }


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            // string constring = "datasource=localhost;port=3306;username=root;password=12345";
            string constring = ConfigurationManager.ConnectionStrings["MySQL"].ToString();
            string Query = "insert into latestspas.attendance (Student_idStudent, idClass, jan, feb, mar, apr, may, jun, jul, aug, sep, oct, nov, adec, sjan, sfeb, smar, sapr, smay, sjun, sjul, saug, ssep, soct, snov, sdec ) values ('" + this.sId.Text + "','" + (comboBox.SelectedIndex + 1) + "','" + this.textBox5.Text + "','" + this.textBox8.Text + "','" + this.textBox11.Text + "','" + this.textBox14.Text + "','" + this.textBox17.Text + "','" + this.textBox20.Text + "','" + this.textBox23.Text + "','" + this.textBox26.Text + "','" + this.textBox28.Text + "','" + this.textBox31.Text + "','" + this.textBox34.Text + "','" + this.textBox37.Text + "','" + this.textBox6.Text + "','" + this.textBox9.Text + "','" + this.textBox12.Text + "','" + this.textBox15.Text + "','" + this.textBox18.Text + "','" + this.textBox21.Text + "','" + this.textBox24.Text + "','" + this.textBox27.Text + "','" + this.textBox29.Text + "','" + this.textBox32.Text + "','" + this.textBox35.Text + "','" + this.textBox38.Text + "') ;";
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
    }
}
