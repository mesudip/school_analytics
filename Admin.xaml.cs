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
    /// Interaction logic for Admin.xaml
    /// </summary>
    public partial class Admin : Page
    {
        public Admin()
        {
            InitializeComponent();
            showot();
        }
        private void showot()
        {
            StudentFrame.Content = new AddStaff();
        }
        private void button_Click(object sender, RoutedEventArgs e)
        {
            StudentFrame.Content = new AddStaff();
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            StudentFrame.Content = new StaffUpdate();
        }

        private void button3_Click(object sender, RoutedEventArgs e)
        {
            StudentFrame.Content = new AdminSearchPage();
        }

        private void button2_Click(object sender, RoutedEventArgs e)
        {
            StudentFrame.Content = new AdminDeletePage();
        }
    }
}
