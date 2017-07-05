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
    /// Interaction logic for Student.xaml
    /// </summary>
    public partial class Student : Page
    {
        public Student()
        {
            InitializeComponent();
            showot();
        }

        private void showot()
        {
            StudentFrame.Content = new AddNew();
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            StudentFrame.Content = new AddNew();
            
        }

        private void button4_Click(object sender, RoutedEventArgs e)
        {
            
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            StudentFrame.Content = new Update();
            
        }

        private void button3_Click(object sender, RoutedEventArgs e)
        {
            StudentFrame.Content = new Search();
        }

        private void button2_Click(object sender, RoutedEventArgs e)
        {
            StudentFrame.Content = new Delete();
        }
    }
}
