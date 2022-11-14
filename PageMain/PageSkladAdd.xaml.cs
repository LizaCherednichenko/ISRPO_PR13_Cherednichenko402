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
    /// Логика взаимодействия для PageSkladAdd.xaml
    /// </summary>
    public partial class PageSkladAdd : Page
    {
        private Sklad _currentSklad = new Sklad();


        public PageSkladAdd(Sklad selectedSklad)
        {
            InitializeComponent();

            if (selectedSklad != null)
                _currentSklad = selectedSklad;

            DataContext = _currentSklad;
            ComboStrana.ItemsSource = ISRPO13Cher402Entities.GetContext().Strana.ToList();
        }



        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            StringBuilder errors = new StringBuilder();

            if (string.IsNullOrWhiteSpace(_currentSklad.naimenov))
                errors.AppendLine("Укажите название товара");
            if (_currentSklad.kolichestvo <= 0)
                errors.AppendLine("Количество товара не может быть меньше или равно 0");
            if (_currentSklad.cena <= 0)
                errors.AppendLine("Цена не может быть меньше или рана 0");
            if (_currentSklad.Strana == null)
                errors.AppendLine("Выберите страну");

            if (errors.Length > 0)
            {
                MessageBox.Show(errors.ToString());
                return;
            }
            //добавление
            if (_currentSklad.id == 0)
                ISRPO13Cher402Entities.GetContext().Sklad.Add(_currentSklad);

            //обработаю вариант выпада/записи данных
            try
            {
                ISRPO13Cher402Entities.GetContext().SaveChanges();
                MessageBox.Show("Информация сохранена");
                AppFrame.MyFrame.GoBack();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        
    }
}
