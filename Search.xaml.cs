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
    /// Interaction logic for Search.xaml
    /// </summary>
    public partial class Search : Page
    {
      

        //public static string Roll_No, NameStudent;
        public Search()
        {
            InitializeComponent();
            FillCombo();
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
                    comboBox1.Items.Add(sName);
                  
                    


                }


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void comboBox1_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
           
        }


        private void button1_Click(object sender, RoutedEventArgs e)
        {
            string constring = "datasource=localhost;port=3306;username=root;password=12345";
            string Query = "select * from school_analytics_system.student where Name= '" + comboBox1.Text + "' ;";
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
                    string sName = myReader.GetString("Name");
                    string sAddress = myReader.GetString("Address");
                    string sClass = myReader.GetString("Class").ToString();
                    string sGender = myReader.GetString("Gender");
                    string sDOB = myReader.GetString("DOB");
                    string sFatherName = myReader.GetString("FatherName");
                    string sFphone = myReader.GetString("Fphone");
                    string sFmobile = myReader.GetString("Fmobile");
                    string sFemail = myReader.GetString("Femail");
                    string sMotherName = myReader.GetString("MotherName");
                    string sMphone = myReader.GetString("Mphone");
                    string sMmobile = myReader.GetString("Mmobile");
                    string sMemail = myReader.GetString("Memail");
                    string sBus = myReader.GetString("Bus");
                    string sHostel = myReader.GetString("Hostel");

                   

                    RollNo.Text = sRollNo;
                    Name.Text = sName;
                    Address.Text = sAddress;
                    Class.Text = sClass;
                    Gender.Text = sGender;
                    DatePicker.Text = sDOB;
                    FatherName.Text = sFatherName;
                    Phone.Text = sFphone;
                    Email.Text = sFemail;
                    MobileNumber.Text = sFmobile;
                    MotherName.Text = sMotherName;
                    Phone1.Text = sMphone;
                    MobileNumber1.Text = sMmobile;
                    Email1.Text = sMemail;
                    Bus.Text = sBus;
                    Hostel.Text = sHostel;
                    
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

        private void button_Click(object sender, RoutedEventArgs e)
        {
            Window2_MarkSheet Second = new Window2_MarkSheet(RollNo.Text, Name.Text);
            Second.ShowDialog();
        }

        private void AddMarksheet_Click(object sender, RoutedEventArgs e)
        {
          //  NewClassSearch.Roll_No_Student = RollNo.Text;
           // NewClassSearch.name = Name.Text;
           // MessageBox.Show(NewClassSearch.name);
            Window2_AddMarkSheet Second1 = new Window2_AddMarkSheet(RollNo.Text, Name.Text);
            Second1.ShowDialog();
        }

        private void button2_Click(object sender, RoutedEventArgs e)
        {
            Attendance Second1 = new Attendance(Name.Text,RollNo.Text);
            Second1.ShowDialog();
        }
    }
}
