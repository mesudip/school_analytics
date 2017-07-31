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
    /// Interaction logic for Attendance.xaml
    /// </summary>
    public partial class Attendance : Window
    {
        private string sName, sRoll;
        public Attendance(string Name, string RollNo)
        {
            InitializeComponent();
            sName = Name;
            sRoll = RollNo;
            textBox.Text = Name;
            textBox39.Text = RollNo;
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
            
            string constring = "datasource=localhost;port=3306;username=root;password=12345";
            string Query = "insert into school_analytics_system.attendance_class2 (name, roll_no, jan, feb, mar, april, may, june, july, aug, sep, oct, nov , adec, sjan, sfeb, smar, sapril, smay, sjune, sjuly, saug, ssep, soct, snov, sdec ) values ('"+ sName + "','" + sRoll + "','" + this.textBox5.Text + "','" + this.textBox8.Text + "','" + this.textBox11.Text + "','" + this.textBox14.Text + "','" + this.textBox17.Text + "','" + this.textBox20.Text + "','" + this.textBox23.Text + "','" + this.textBox26.Text + "','" + this.textBox28.Text + "','" + this.textBox31.Text + "','" + this.textBox34.Text + "','" + this.textBox37.Text + "','" + this.textBox6.Text + "','" + this.textBox9.Text + "','" + this.textBox12.Text + "','" + this.textBox15.Text + "','" + this.textBox18.Text + "','" + this.textBox21.Text + "','" + this.textBox24.Text + "','" + this.textBox27.Text + "','" + this.textBox29.Text + "','" + this.textBox32.Text + "','" + this.textBox35.Text + "','" + this.textBox38.Text + "') ;";
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
       

        private void comboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }

}
