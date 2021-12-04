using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Livrable_AppliGraphique
{
    /// <summary>
    /// Logique d'interaction pour SaveWindow.xaml
    /// </summary>
    public partial class SaveWindow : Window
    {
        public Controller Controller { get; set; }
        public SaveWindow(Controller controller)
        {
            this.Controller = controller;
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Environment.Exit(0);
        }

        #region Left Menu

        private void Button_Setting_Click(object sender, RoutedEventArgs e)
        {
            SelectLanguage objSelectLanguage = new SelectLanguage(Controller);
            objSelectLanguage.Show();
            this.Close();
        }

        private void btn_save_Click(object sender, RoutedEventArgs e)
        {
            SaveWindow objSaveWindow = new SaveWindow(Controller);
            objSaveWindow.Show();
            this.Close();
        }

        private void btn_home_Click(object sender, RoutedEventArgs e)
        {
            MainWindow objMainWindow = new MainWindow(Controller);
            objMainWindow.Show();
            this.Close();
        }
        #endregion
    }
}
