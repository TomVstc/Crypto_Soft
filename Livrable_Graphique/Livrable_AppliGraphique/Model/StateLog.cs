using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Xml;

namespace Livrable_AppliGraphique.Model
{
    class StateLog
    {
        #region ALL ATTRIBUTE
        private string name; //
        private string sourcePath; //
        private string targetPath; //
        private DateTime timestamp; //
        private string backupState; //
        private int totalFileToCopy; //
        private long totalFileSize; //
        private int nbFileLeftToDo; //
        private long fileSizeLeftToDo; //
        #endregion

        #region SET/GET
        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        public string SourcePath
        {
            get { return sourcePath; }
            set { sourcePath = value; }
        }
        public string TargetPath
        {
            get { return targetPath; }
            set { targetPath = value; }
        }

        public long TotalFileSize
        {
            get { return totalFileSize; }
            set { totalFileSize = value; }
        }
        public DateTime TimeStamp
        {
            get { return timestamp; }
            set { timestamp = value; }
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
        public int NbFileLeftToDo
        {
            get { return nbFileLeftToDo; }
            set { nbFileLeftToDo = value; }
        }
        public long FileSizeLeftToDo
        {
            get { return fileSizeLeftToDo; }
            set { fileSizeLeftToDo = value; }
        }

        #endregion

        public StateLog()
        {
            Name = "";
            SourcePath = "";
            TargetPath = "";
            TimeStamp = default;
            BackupState = "NON ACTIF";
            TotalFileToCopy = 0;
            TotalFileSize = 0;
            NbFileLeftToDo = 0;
            FileSizeLeftToDo = 0;
        }

        public StateLog(string aName, string aBack)
        {
            Name = aName;
            SourcePath = "";
            TargetPath = "";
            TimeStamp = default(DateTime);
            BackupState = aBack;
            TotalFileToCopy = 0;
            TotalFileSize = 0;
            NbFileLeftToDo = 0;
            FileSizeLeftToDo = 0;

            createStateLog(this);
        }

        public StateLog(string aName, string aSourcePath, string aTargetPath, DateTime aTimeStamp,
            string aBackupState, int aTotalFileToCopy, long aTotalFileSize, int aNbFileLeftTodo,
            int aFileSizeLeftToDo)
        {
            Name = aName;
            SourcePath = aSourcePath;
            TargetPath = aTargetPath;
            TimeStamp = aTimeStamp;
            BackupState = aBackupState;
            TotalFileToCopy = aTotalFileToCopy;
            TotalFileSize = aTotalFileSize;
            nbFileLeftToDo = aNbFileLeftTodo;
            FileSizeLeftToDo = aFileSizeLeftToDo;

            createStateLog(this);
        }

        public void createStateLog(StateLog statelog)
        {
            if (statelog.BackupState == "ACTIF")
            {
                string jsonSerializedObj = JsonConvert.SerializeObject(statelog, Newtonsoft.Json.Formatting.Indented);
                Directory.CreateDirectory(@"D:\Code\stateLog");
                File.AppendAllText(@"D:\Code\stateLog\stateLogAppliGraph.json", jsonSerializedObj);
            }
            else if (BackupState == "NON ACTIF")
            {
                string jsonSerializedObj = JsonConvert.SerializeObject(statelog, Newtonsoft.Json.Formatting.Indented);
                Directory.CreateDirectory(@"D:\Code\stateLog");
                File.AppendAllText(@"D:\Code\stateLog\stateLogAppliGraph.json", jsonSerializedObj);
            }
        }
    }
}
