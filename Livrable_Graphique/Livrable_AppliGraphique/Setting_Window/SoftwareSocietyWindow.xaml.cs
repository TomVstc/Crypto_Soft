using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Linq;
using System.IO;
using System.Runtime;


namespace Livrable_AppliGraphique.Setting_Window
{
    /// <summary>
    /// Logique d'interaction pour SoftwareSocietyWindow.xaml
    /// </summary>
    public partial class SoftwareSocietyWindow : Window
    {
        public string nameSoftwareSociety { get; set; }

        public Controller Controller { get; set; }

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
        public SoftwareSocietyWindow(Controller controller)
        {
            this.Controller = controller;
            InitializeComponent();
        }

        private void Button_Choose_SoftwareSociety_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();

            if (openFileDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                string softwarePath = openFileDialog.FileName;

                Name_Software_Society.Text = softwarePath;

            }
        }

        private void Button_submit_Click(object sender, RoutedEventArgs e)
        {
            string nameSoftware = Name_Software_Society.Text;
            var nameSoftwareSociety = new DirectoryInfo(nameSoftware).Name;
            System.Windows.MessageBox.Show(nameSoftwareSociety);
            
        }
    }
}
