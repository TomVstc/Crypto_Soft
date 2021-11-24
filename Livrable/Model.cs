using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;
using System.Text.Json;
using Newtonsoft.Json;
using System.Resources;
using System.Reflection;
using System.Globalization;

namespace Livrable
{

    class Model
    {
        ResourceManager rm = new ResourceManager("Livrable.Langage.Strings",
        Assembly.GetExecutingAssembly());

        #region ATTRIBUT
        // All attributes
        public class DailyLog
        {
            public long FileSize;
            public string FileTransfertTime;
            public DateTime Time;
            public string Name;
            public string FileSource;
            public string FileTarget;
        }
        public class StateLog
        {
            public string name;
            public string sourcePath;
            public string targetPath;
            public DateTime timestamp;
            public string backupState;
            public int totalFileToCopy;
            public long totalFileSize;
            public int nbFileLeftToDo;
            public long fileSizeLeftToDo;
        }

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

        public bool controlSave { get; set; }

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

        // Constructor
        public Model()
        {
        }

        // Create Save
        public async void createSave()
        {
            BackupState = "ACTIF";

            if(Type == "Full")
            {
                if(Destination == "File")
                {
                    controlSave = false;
                    string fileName = FileName + "." + Extension;
                    string fileSource = FileSource;
                    string fileTarget = FileTarget;
                    string path = fileTarget + @"\" + fileName;

                    DateTime Start = DateTime.Now;
                    Time = Start;
                    TotalFileToCopy = 1;

                    System.IO.File.Copy(fileSource, path, true);
                    DateTime Stop = DateTime.Now;
                    FileTransfertTime = (Stop - Start).ToString();

                    controlSave = System.IO.File.Exists(path);

                    // Recup File Size
                    FileInfo fileinfo = new FileInfo(FileTarget + @"\" + fileName);
                    FileSize = fileinfo.Length;

                    if (Thread.CurrentThread.CurrentUICulture.Name == "en-US")
                    {
                        Console.WriteLine("\n" + (rm.GetString("fileCreateEN")) + "\n");
                    }
                    else if (Thread.CurrentThread.CurrentUICulture.Name == "fr-FR")
                    {
                        Console.WriteLine("\n" + (rm.GetString("fileCreateFR")) + "\n");
                    }
                }
                if(Destination == "Directory")
                {
                    string fileName = FileName;
                    string fileSource = FileSource;
                    string fileTarget = FileTarget + @"\" + FileName;

                    DirectoryInfo dir = new DirectoryInfo(fileSource);
                    DirectoryInfo[] dirs = dir.GetDirectories();
                    // If destination doesn't exist => create
                    Directory.CreateDirectory(fileTarget);

                    FileInfo[] files = dir.GetFiles();
                    //string[] files = System.IO.Directory.GetFiles(fileSource);
                    //string destFile = System.IO.Path.Combine(fileTarget, fileName);

                    DateTime Start = DateTime.Now;
                    Time = Start;

                    foreach(FileInfo file in files)
                    {
                        FileSize += file.Length;
                        file.CopyTo(fileTarget + @"\" + file.Name, false);
                        TotalFileToCopy++;
                    }

   
                    DateTime Stop = DateTime.Now;
                    FileTransfertTime = (Stop - Start).ToString();

                    if (Thread.CurrentThread.CurrentUICulture.Name == "en-US")
                    {
                        Console.WriteLine("\n" + (rm.GetString("directoryCreateEN")) + "\n");
                    }
                    else if (Thread.CurrentThread.CurrentUICulture.Name == "fr-FR")
                    {
                        Console.WriteLine("\n" + (rm.GetString("directoryCreateFR")) + "\n");
                    }
                }

                // Create StateLog when a Save = Actif
                createStateLog();
                createDailyLog();
                BackupState = "NON ACTIF";
                // Update StateLog
                createStateLog();

            }
            if (Type == "Differential")
            {
                Console.WriteLine("\nDifferential no increment");
            }

        }
        
        // Create DailyLog
        public void createDailyLog()
        {
            DailyLog fichier = new DailyLog();
            fichier.Name = FileName;
            fichier.Time = Time;
            fichier.FileSize = FileSize;
            fichier.FileSource = FileSource;
            fichier.FileTarget = FileTarget;
            fichier.FileTransfertTime = FileTransfertTime;

            string jsonSerializedObj = JsonConvert.SerializeObject(fichier, Formatting.Indented);
           
            Directory.CreateDirectory(@"D:\Code\dailyLog");
            File.AppendAllText(@"D:\Code\dailyLog\dailyLog2.json", jsonSerializedObj);
            
        }

        public void createStateLog()
        {
            StateLog stateLog = new StateLog();
            if (BackupState == "ACTIF")
            {
                stateLog.name = FileName;
                stateLog.sourcePath = FileSource;
                stateLog.targetPath = FileTarget;
                stateLog.timestamp = Time;
                stateLog.backupState = BackupState;
                stateLog.totalFileToCopy = TotalFileToCopy;
                stateLog.totalFileSize = FileSize;
                stateLog.nbFileLeftToDo = TotalFileToCopy;
                stateLog.fileSizeLeftToDo = FileSize;

                string jsonSerializedObj = JsonConvert.SerializeObject(stateLog, Formatting.Indented);
                Directory.CreateDirectory(@"D:\Code\stateLog");
                File.AppendAllText(@"D:\Code\stateLog\stateLog1.json", jsonSerializedObj);
            }
            else if(BackupState =="NON ACTIF")
            {
                stateLog.name = FileName;
                stateLog.sourcePath = "";
                stateLog.targetPath = "";
                stateLog.timestamp = default(DateTime);
                stateLog.backupState = BackupState;
                stateLog.totalFileToCopy = 0;
                stateLog.totalFileSize = 0;
                stateLog.nbFileLeftToDo = 0;
                stateLog.fileSizeLeftToDo = 0;

                string jsonSerializedObj = JsonConvert.SerializeObject(stateLog, Formatting.Indented);
                Directory.CreateDirectory(@"D:\Code\stateLog");
                File.AppendAllText(@"D:\Code\stateLog\stateLog1.json", jsonSerializedObj);
            }
        }
    }
}
