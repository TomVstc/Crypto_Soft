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
using Livrable_AppliGraphique.Setting_Window;

namespace Livrable_AppliGraphique
{
    /// <summary>
    /// Logique d'interaction pour Settings.xaml
    /// </summary>
    public partial class Settings : Window
    {
        public Controller Controller { get; set; }
        public Settings(Controller controller)
        {
            this.Controller = controller;
            InitializeComponent();
        }

        #region Left Menu
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Environment.Exit(0);
        }
        private void Button_Setting_Click(object sender, RoutedEventArgs e)
        {
            Settings objSettings = new Settings(Controller);
            objSettings.Show();
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

        private void Button_Language_Click(object sender, RoutedEventArgs e)
        {
            SelectLanguage objSelectLanguage = new SelectLanguage(Controller);
            objSelectLanguage.Show();
            this.Close();
        }

        private void Button_Entreprise_software_Click(object sender, RoutedEventArgs e)
        {
            SoftwareSocietyWindow objSoftwareSocietyWindow = new SoftwareSocietyWindow(Controller);
            objSoftwareSocietyWindow.Show();
            this.Close();
        }

        private void Button_Extension_Click(object sender, RoutedEventArgs e)
        {
            ExtensionWindow objExtensionWindow = new ExtensionWindow(Controller);
            objExtensionWindow.Show();
            this.Close();
        }
    }
}
