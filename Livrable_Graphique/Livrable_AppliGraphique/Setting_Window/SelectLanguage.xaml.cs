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
using System.Windows.Shapes;
using System.Windows.Forms;
using System.IO;
using System.Diagnostics;

namespace Livrable_AppliGraphique
{
    /// <summary>
    /// Logique d'interaction pour SelectLanguage.xaml
    /// </summary>
    public partial class SelectLanguage : Window
    {
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
        public Controller Controller { get; set; }
        public SelectLanguage(Controller controller)
        {
            this.Controller = controller;
            InitializeComponent();
        }

        private void Button_Confirm(object sender, RoutedEventArgs e)
        {

            var currentExecutablePath = Process.GetCurrentProcess().MainModule.FileName;
            Process.Start(currentExecutablePath);
            System.Windows.Application.Current.Shutdown();
        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (cmb.SelectedIndex == 1)
                Properties.Settings.Default.languageCode = "en-US";
            else
                Properties.Settings.Default.languageCode = "fr-FR";

            Properties.Settings.Default.Save();
        }

    }
}
