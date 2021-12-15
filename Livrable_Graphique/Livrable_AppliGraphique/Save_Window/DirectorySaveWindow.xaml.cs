using System;
using System.Collections.Generic;
using System.Linq;
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
using Livrable_AppliGraphique.Save_Window;

namespace Livrable_AppliGraphique.Save_Window
{
    /// <summary>
    /// Logique d'interaction pour DirectorySaveWindow.xaml
    /// </summary>
    public partial class DirectorySaveWindow : Window
    {
        #region ALL ATTRIBUTE
        private string dirOrFile;
        private string name;
        private string fileSource;
        private string fileTarget;
        private string destination;
        private string extention;
        private IController Icontroller;
        #endregion

        #region SET/GET
        // Creation of set and get
        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        public string FileSource
        {
            get { return fileSource; }
            set { fileSource = value; }
        }
        public IController IController
        {
            get { return Icontroller; }
            set { Icontroller = value; }
        }
        public string Destination
        {
            get { return destination; }
            set { destination = value; }
        }
        public string Extention
        {
            get { return extention; }
            set { extention = value; }
        }

        #endregion
        public Controller Controller { get; set; }

        public DirectorySaveWindow()
        {
            dirOrFile = "";
            name = "";
            fileSource = "";
            destination = "";
        }
        public DirectorySaveWindow(Controller controller)
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

        private void Button_Choose_Directory_Source_Click(object sender, RoutedEventArgs e)
        {
            var targetDialog = new System.Windows.Forms.FolderBrowserDialog();
            targetDialog.ShowNewFolderButton = false;

            if (targetDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                Name_Directory_Source_Destination.Text = targetDialog.SelectedPath;
            }
        }

        private void Button_Choose_Directory_Destination_Click(object sender, RoutedEventArgs e)
        {
            var targetDialog = new System.Windows.Forms.FolderBrowserDialog();
            targetDialog.ShowNewFolderButton = false;

            if (targetDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                Name_Directory_Destination.Text = targetDialog.SelectedPath;
            }
        }

        private void Button_Submit_File_Save_Click(object sender, RoutedEventArgs e)
        {
            DirectorySaveWindow directorySaveWindow = new DirectorySaveWindow();
            directorySaveWindow.dirOrFile = "Directory";
            directorySaveWindow.name = Text_Box_Name.Text;
            directorySaveWindow.fileSource = Name_Directory_Source_Destination.Text;
            directorySaveWindow.destination = Name_Directory_Destination.Text;

            ServerManagerWindow manager = new ServerManagerWindow(Controller);
            manager.Show();
            Controller.serverManager = manager;
            Controller.updateSave(directorySaveWindow.dirOrFile, directorySaveWindow.name, directorySaveWindow.fileSource, directorySaveWindow.destination);
        }
    }
}
