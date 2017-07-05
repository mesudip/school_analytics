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
    /// Interaction logic for ClassPerformance.xaml
    /// </summary>
    public partial class ClassPerformance : Page
    {
        public ClassPerformance()
        {
            InitializeComponent();
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            Class1 form = new Class1();
            form.ShowDialog();
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            Class2 form = new Class2();
            form.ShowDialog();
        }
    }
}
