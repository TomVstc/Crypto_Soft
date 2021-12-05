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

namespace Livrable_AppliGraphique
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public Controller Controller { get; set; }

        public MainWindow()
        {
            Controller controller = new Controller();
            this.Controller = controller;
            InitializeComponent();
        }

        public MainWindow(Controller controller)
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

    }
}
