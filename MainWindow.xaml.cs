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


namespace SEproject
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        
        public MainWindow()
        {
            InitializeComponent();
           // login = Login.Content;
           /* if (login.GID == null)
            {
                Login.Content = "";
            }
            else {
                Login.Content = login.GID;
            }*/
            
        }
        private void CloseButton_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
            // this.Close();
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

        private void Minimizebutton_Click(object sender, RoutedEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }

        private void HomepageClick(object sender, RoutedEventArgs e)
        {
            Main.Content = new HomePage();
            loginCase();
        }

        private void page1click(object sender, RoutedEventArgs e)
        {
            Main.Content = new Student();
            loginCase();
            //StudentFrame.Content = new AddNew();
        }

        private void login_Click(object sender, RoutedEventArgs e)
        {
            Main.Content = new login();
            loginCase();
        }

        private void Adminclick(object sender, RoutedEventArgs e)
        {
            Main.Content = new Admin();
            loginCase();
        }

        private void classClick(object sender, RoutedEventArgs e)
        {
            Main.Content = new ClassPerformance();
            loginCase();
        }

        private void AddMarksheetClick(object sender, RoutedEventArgs e)
        {
            Main.Content = new Add_Marksheet_Page();
            loginCase();
        }

        private void ViewMarksheetclick(object sender, RoutedEventArgs e)
        {
            Main.Content = new ViewMarksheetPage();
            loginCase();
        }

        private void AddAttendenceclick(object sender, RoutedEventArgs e)
        {
            Main.Content = new Add_Attendance_Page();
            loginCase();
        }
        public void loginCase()
        {
            if (login.GID == null)
            {
                Login.Content = "None";
            }
            else
            {
                Login.Content = login.GID;
                LoginType.Content = login.Profession;
            }
        }
    }
}
