using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Diagnostics;
using System.Threading;
using System.Text.Json;
using Newtonsoft.Json;

namespace Livrable
{
    class Model
    {
        #region ATTRIBUT
        // All attributes
        //private ViewSave save;
        //private ViewDailyLog viewDailyLog;
        public class DailyLog
        {
            public int FileSize;
            public string FileTransfertTime;
            public DateTime Time;
            public string Name;
            public string FileSource;
            public string FileTarget;
        }
        private string fileName;
        private string fileSource;
        private string fileTarget;
        private string type;
        private string destination;
        private string extension;
        private string fileTransfertTime;
        private int fileSize;
        #endregion

        //Creation of set and get
        //public ViewSave Save
        //{
        //    get { return save; }
        //    set { save = value;  }
        //}
        //public ViewDailyLog ViewDailyLog
        //{
        //    get { return viewDailyLog; }
        //    set { viewDailyLog = value; }
        //}
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
        public int FileSize
        {
            get { return fileSize; }
            set { fileSize = value; }
        }

        // Constructor
        public Model()
        {           
        }

        // Create Save
        public void createSave()
        {
            if(Type == "Full")
            {
                if(Destination == "File")
                {
                    string fileName = FileName + "." + Extension;
                    string fileSource = FileSource;
                    string fileTarget = FileTarget;
                    string path = fileTarget + @"\" + fileName;

                    Stopwatch sw = Stopwatch.StartNew();
                    System.IO.File.Copy(fileSource, path, true);
                    sw.Stop();
                    FileTransfertTime = sw.Elapsed.TotalMilliseconds.ToString();
                    Console.WriteLine("File Create\n");
                }
                if(Destination == "Directory")
                {
                    string fileName = FileName;
                    string fileSource = FileSource;
                    string fileTarget = FileTarget + @"\" + FileName;

                    string[] files = System.IO.Directory.GetFiles(fileSource);
                    string destFile = System.IO.Path.Combine(fileTarget, fileName);

                    Stopwatch sw = Stopwatch.StartNew();
                    // Copy the files and overwrite destination files if they already exist.
                    foreach (string s in files)
                    {
                        // Use static Path methods to extract only the file name from the path.
                        fileName = System.IO.Path.GetFileName(s);
                        destFile = System.IO.Path.Combine(fileTarget, fileName);
                        System.IO.File.Copy(s, destFile, true);
                    }
                    sw.Stop();
                    FileTransfertTime = sw.Elapsed.TotalMilliseconds.ToString();
                    Console.WriteLine("\nDirectory Create Create\n");
                }
            }
            if (Type == "Differential")
            {
                Console.WriteLine("\nDifferential no increment");
            }

        }
        
        // Create DailyLog
        public void createDailyLog(ViewDailyLog viewDailyLog)
        {
            DailyLog fichier = new DailyLog();
            fichier.Name = viewDailyLog.Name;
            fichier.Time = viewDailyLog.Time;
            fichier.FileSize = viewDailyLog.FileSize;
            fichier.FileSource = viewDailyLog.FileSource;
            fichier.FileTarget = viewDailyLog.FileTarget;
            fichier.FileTransfertTime = FileTransfertTime;

  
            string jsonSerializedObj = JsonConvert.SerializeObject(fichier, Formatting.Indented);
            File.AppendAllText(@"D:\Code\dailyLog\dailyLog2.son", jsonSerializedObj);
        }
    }
}
