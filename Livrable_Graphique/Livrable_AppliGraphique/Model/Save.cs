using Livrable_AppliGraphique.Save_Window;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading;

namespace Livrable_AppliGraphique.Model
{
    class Save
    {
        #region ALL ATTRIBUTE
        private string fileName;
        private string fileSource;
        private string fileTarget;
        private string type;
        private string destination;
        private string extension;
        private string fileTransfertTime;
        private long fileSize;
        private DateTime time;
        private string backupState;
        private int totalFileToCopy;
        #endregion

        #region SET/GET
        //Creation of set and get
        public string FileName
        {
            get { return fileName; }
            set { fileName = value; }
        }
        public string FileSource
        {
            get { return fileSource; }
            set { fileSource = value; }
        }
        public string FileTarget
        {
            get { return fileTarget; }
            set { fileTarget = value; }
        }
        public string Type
        {
            get { return type; }
            set { type = value; }
        }
        public string Destination
        {
            get { return destination; }
            set { destination = value; }
        }
        public string Extension
        {
            get { return extension; }
            set { extension = value; }
        }
        public string FileTransfertTime
        {
            get { return fileTransfertTime; }
            set { fileTransfertTime = value; }
        }
        public long FileSize
        {
            get { return fileSize; }
            set { fileSize = value; }
        }
        public DateTime Time
        {
            get { return time; }
            set { time = value; }
        }
        public string BackupState
        {
            get { return backupState; }
            set { backupState = value; }
        }
        public int TotalFileToCopy
        {
            get { return totalFileToCopy; }
            set { totalFileToCopy = value; }
        }


        #endregion

        public Save(string type,string Name, string FileSource, string Destination)
        {
            Type = type;
            FileName = Name;
            fileSource = FileSource;
            destination = Destination;
        }

        public void fileSave()
        {
            BackupState = "ACTIF";

            if (Type == "File")
            {
                string fileName = FileName;
                string fileSource = FileSource;
                string fileTarget = Destination;
                string path = fileTarget + @"\" + fileName;

                DateTime Start = DateTime.Now;
                Time = Start;

                System.IO.File.Copy(fileSource, path, true);
                DateTime Stop = DateTime.Now;
                FileTransfertTime = (Stop - Start).ToString();


                // Recup File Size
                FileInfo fileinfo = new FileInfo(Destination + @"\" + fileName);
                FileSize = fileinfo.Length;

                System.Windows.MessageBox.Show("Done");
                }
                if (Type == "Directory")
                {
                    string fileName = FileName;
                    string fileSource = FileSource;
                    string fileTarget = Destination + @"\" + FileName;

                    DirectoryInfo dir = new DirectoryInfo(fileSource);
                    DirectoryInfo[] dirs = dir.GetDirectories();
                    // If destination doesn't exist => create
                    Directory.CreateDirectory(fileTarget);

                    FileInfo[] files = dir.GetFiles();
                    //string[] files = System.IO.Directory.GetFiles(fileSource);
                    //string destFile = System.IO.Path.Combine(fileTarget, fileName);

                    DateTime Start = DateTime.Now;
                    Time = Start;

                    foreach (FileInfo file in files)
                    {
                        FileSize += file.Length;
                        file.CopyTo(fileTarget + @"\" + file.Name, false);
                        TotalFileToCopy++;
                    }


                    DateTime Stop = DateTime.Now;
                    FileTransfertTime = (Stop - Start).ToString();
                    System.Windows.MessageBox.Show("Done");
                }

                // Create StateLog when a Save = Actif
                //createStateLog();
                //createDailyLog();
                BackupState = "NON ACTIF";
                // Update StateLog
                //createStateLog();

            }

        }

        ////System.Windows.MessageBox.Show(this.fileSource + this.destination);
        //string path = destination + @"\" + Name;
        //System.IO.File.Copy(fileSource, path, true);
        //System.Windows.MessageBox.Show("Done");
    
}
