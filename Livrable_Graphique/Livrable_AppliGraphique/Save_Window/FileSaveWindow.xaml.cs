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

namespace Livrable_AppliGraphique.Save_Window
{
    /// <summary>
    /// Logique d'interaction pour FileSaveWindow.xaml
    /// </summary>
    public partial class FileSaveWindow : Window
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
        //public string FileTarget
        //{
        //    get { return fileTarget; }
        //    set { fileTarget = value; }
        //}
        //public string Type
        //{
        //    get { return type; }
        //    set { type = value; }
        //}
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
        public FileSaveWindow()
        {
            name = "";
            fileSource = "";
            destination = "";
            extention = "";
        }
        public FileSaveWindow(Controller controller)
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

        private void Button_Choose_File_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();

            if (openFileDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                System.Windows.MessageBox.Show("Ok");
                Name_File_Source.Text = openFileDialog.FileName;
            }
        }

        private void Button_Choose_Directory_Destination_Click(object sender, RoutedEventArgs e)
        {
            var targetDialog = new System.Windows.Forms.FolderBrowserDialog();
            targetDialog.ShowNewFolderButton = false;

            if (targetDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                System.Windows.MessageBox.Show("Okk");
                Name_Directory_Destination.Text = targetDialog.SelectedPath;
            }
        }

        private void Button_Submit_File_Save_Click(object sender, RoutedEventArgs e)
        {
            FileSaveWindow fileSaveWindow = new FileSaveWindow();
            extention = Name_File_Source.Text.Split(".").Last();
            fileSaveWindow.dirOrFile = "File";
            fileSaveWindow.name = Text_Box_Name.Text +"." + extention;
            fileSaveWindow.fileSource = Name_File_Source.Text;
            fileSaveWindow.destination = Name_Directory_Destination.Text;
            Controller.updateSave(fileSaveWindow.dirOrFile, fileSaveWindow.name, fileSaveWindow.fileSource, fileSaveWindow.destination);
        }
    }
}
