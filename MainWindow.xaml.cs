﻿using ISRPO_PR13_Cherednichenko402.ApplicationData;
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

namespace ISRPO_PR13_Cherednichenko402
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            AppConnect.model0db = new Sklad();
            AppFrame.MyFrame = MainFrame;
            MainFrame.Navigate(new PageMain.PageSklad());
        }
    }
}
