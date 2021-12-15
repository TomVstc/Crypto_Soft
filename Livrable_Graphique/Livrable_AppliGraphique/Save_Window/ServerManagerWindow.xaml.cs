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

using Livrable_AppliGraphique.Model;

namespace Livrable_AppliGraphique.Save_Window
{
    /// <summary>
    /// Logique d'interaction pour ServerManagerWindow.xaml
    /// </summary>
    public partial class ServerManagerWindow : Window
    {
        public Controller Controller { get; set; }
        // public Save save { get; set; }
        public ServerManagerWindow(Controller controller)
        {
            this.Controller = controller;
            InitializeComponent();
        }

        private void Break_Button_Click(object sender, RoutedEventArgs e)
        {
            Controller.stateSave = true;
            stateSave.Content = Livrable_AppliGraphique.Properties.Langs.Lang.stopSave;
        }

        private void Restart_Button_Click(object sender, RoutedEventArgs e)
        {
            Controller.stateSave = false;
            stateSave.Content = Livrable_AppliGraphique.Properties.Langs.Lang.loadingSave;
        }

        private void Exit_Button_Click(object sender, RoutedEventArgs e)
        {
            Controller.stopSave = true;
            stateSave.Content = Livrable_AppliGraphique.Properties.Langs.Lang.saveExit;
        }
    }
}
