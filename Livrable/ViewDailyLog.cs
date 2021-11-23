using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Linq;
using Newtonsoft.Json;
using System.Resources;
using System.Reflection;
using System.Threading;
using System.Globalization;

namespace Livrable
{
    class ViewDailyLog : ViewSave
    {
        ResourceManager rm = new ResourceManager("Livrable.Langage.Strings",
        Assembly.GetExecutingAssembly());

        #region ALL ATTRIBUTE
        // All attribute of a Daily Log
        private long fileSize;
        private string fileTransfertTime;
        private DateTime time;
        #endregion

        #region SET/GET
        public long FileSize
        {
            get { return fileSize; }
            set { fileSize = value; }
        }
        public string FileTransfertTime
        {
            get { return fileTransfertTime; }
            set { fileTransfertTime = value; }
        }
        public DateTime Time
        {
            get { return time; }
            set { time = value; }
        }
        #endregion

        public ViewDailyLog()
        {
            Name = "";
            FileSource = "";
            FileTarget = "";
            FileSize = 0;
            FileTransfertTime = "";
            Time = default;
        }

        public void getValuesSave( ViewSave viewSave )
        {
            Extension = viewSave.Extension;
            Name = viewSave.Name;
            FileSource = viewSave.FileSource;
            FileTarget = viewSave.FileTarget;
            Destination = viewSave.Destination;
            //FileTransfertTime = viewSave.FileTransfertTime;
            if(Destination == "File")
            {
                getFileSize();
                getTime();
                Name = Name + "." + Extension;
            }
            else
            {
                getDirectorySize();
                getDirectoryTime();
            }
        }
        public void getFileSize()
        {
            FileInfo fileinfo = new FileInfo(FileTarget + @"\" + Name + "." + Extension);
            FileSize = fileinfo.Length;
        }
        public void getDirectorySize()
        {
            DirectoryInfo directoryInfo = new DirectoryInfo(FileTarget + @"\" + Name);
            long totalSize = directoryInfo.EnumerateFiles().Sum(file => file.Length);
            FileSize = (int)totalSize;
        }
        public void getTime()
        {
             Time = File.GetCreationTime(FileTarget + @"\" + Name + "." + Extension);
            
        }
        public void getDirectoryTime()
        {
            Time = Directory.GetCreationTime(FileTarget + @"\" + Name);
        }
    }
}