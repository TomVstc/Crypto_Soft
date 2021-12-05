using Livrable_AppliGraphique.Save_Window;
using System;
using System.Collections.Generic;
using System.Text;

namespace Livrable_AppliGraphique.Model
{
    class Save
    {
        #region ALL ATTRIBUTE
        // All attributes of a save
        private string name;
        private string fileSource;
        //private string fileTarget;
        private string destination;
        //private string extention;
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
        //public IController IController
        //{
        //    get { return Icontroller; }
        //    set { Icontroller = value; }
        //}
        public string Destination
        {
            get { return destination; }
            set { destination = value; }
        }
        //public string Extension
        //{
        //    get { return extention; }
        //    set { extention = value; }
        //}

        #endregion

        public Save(string FileSource, string Destination)
        {
            name = "test";
            fileSource = FileSource;
            destination = Destination;
        }

        public void test()
        {
            //System.Windows.MessageBox.Show(this.fileSource + this.destination);
            string path = destination + @"\" + name;
            System.IO.File.Copy(fileSource, path, true);
            System.Windows.MessageBox.Show("Done");
        }
    }
}
