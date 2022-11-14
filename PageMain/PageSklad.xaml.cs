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
        
        //редактирование
        private void BtnEdit_Click(object sender, RoutedEventArgs e)
        {
            AppFrame.MyFrame.Navigate(new PageSkladAdd((sender as Button).DataContext as Sklad));
        }
       
        //удаление
        private void bthDel_Click(object sender, RoutedEventArgs e)
        {
            var tovarForRemoving = DtGridTovar.SelectedItems.Cast<Sklad>().ToList();
            if (MessageBox.Show($"вы точно хотите удалить следующее {tovarForRemoving.Count()} элементов?", "Внимание",
                MessageBoxButton.YesNo, MessageBoxImage.Question)== MessageBoxResult.Yes)
            {
                try
                {
                    ISRPO13Cher402Entities.GetContext().Sklad.RemoveRange(tovarForRemoving);
                    ISRPO13Cher402Entities.GetContext().SaveChanges();
                    MessageBox.Show("Данные удалены");

                    DtGridTovar.ItemsSource = ISRPO13Cher402Entities.GetContext().Sklad.ToList();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString());
                }
            }
        }

        //добавление данных
        private void bthAdd_Click(object sender, RoutedEventArgs e)
        {
            AppFrame.MyFrame.Navigate(new PageSkladAdd(null));
        }

        private void Page_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            if (Visibility == Visibility.Visible)
            {
                ISRPO13Cher402Entities.GetContext().ChangeTracker.Entries().ToList().ForEach(p => p.Reload());
                DtGridTovar.ItemsSource = ISRPO13Cher402Entities.GetContext().Sklad.ToList();
            }
        }
    }
}
