using ISRPO_PR13_Cherednichenko402.ApplicationData;
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

namespace ISRPO_PR13_Cherednichenko402.PageMain
{
    /// <summary>
    /// Логика взаимодействия для PageSklad.xaml
    /// </summary>
    public partial class PageSklad : Page
    {
        public PageSklad()
        {
            InitializeComponent();
            DtGridTovar.ItemsSource = ISRPO13Cher402Entities.GetContext().Sklad.ToList();
        }

        private void BtnEdit_Click(object sender, RoutedEventArgs e)
        {

        }

        private void bthDel_Click(object sender, RoutedEventArgs e)
        {

        }

        private void bthAdd_Click(object sender, RoutedEventArgs e)
        {
            AppFrame.MyFrame.Navigate(new PageMain.PageSkladAdd());
        }
    }
}
