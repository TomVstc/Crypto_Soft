﻿using System;
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

namespace Livrable_AppliGraphique.Setting_Window
{
    /// <summary>
    /// Logique d'interaction pour PriorityFileWindow.xaml
    /// </summary>
    public partial class PriorityFileWindow : Window
    {
        public string nameFilePrority;
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
        public PriorityFileWindow(Controller controller)
        {
            this.Controller = controller;
            InitializeComponent();
        }

        private void Button_submit_Click(object sender, RoutedEventArgs e)
        {
            nameFilePrority = TextBox_priorityFile_Name.Text;
            System.Windows.MessageBox.Show(nameFilePrority);
            Controller.priorityFile = nameFilePrority;

        }
    }
}
