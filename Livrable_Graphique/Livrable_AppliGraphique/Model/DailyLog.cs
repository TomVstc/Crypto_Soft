using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Xml;

namespace Livrable_AppliGraphique.Model
{
    class DailyLog
    {
        #region ALL ATTRIBUTE
        private string name;
        private string fileSource;
        private string fileTarget;
        private long fileSize;
        private string fileTransfertTime;
        private DateTime time;
        private string encryptTime;
        #endregion

        #region SET/GET
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
        public string FileTarget
        {
            get { return fileTarget; }
            set { fileTarget = value; }
        }

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
        public string EncryptTime
        {
            get { return encryptTime; }
            set { encryptTime = value; }
        }
        #endregion

        public DailyLog()
        {
            Name = "";
            FileSource = "";
            FileTarget = "";
            FileSize = 0;
            FileTransfertTime = "";
            Time = default;
            EncryptTime = "";
        }

        public DailyLog(string aName, string fileSource, string fileTarget, long fileSize, string fileTransfertTime, DateTime aTime, string aEncryptTime)
        {
            Name = aName;
            FileSource = fileSource;
            FileTarget = fileTarget;
            FileSize = fileSize;
            FileTransfertTime = fileTransfertTime;
            Time = aTime;
            encryptTime = aEncryptTime;

            createDailyLog(this);
        }

        public void createDailyLog(DailyLog dailyLog)
        {
            string jsonSerializedObj = JsonConvert.SerializeObject(dailyLog, Newtonsoft.Json.Formatting.Indented);

            Directory.CreateDirectory(@"D:\Code\dailyLog");
            File.AppendAllText(@"D:\Code\dailyLog\dailyLogAppligraph.json", jsonSerializedObj);

        }
    }
}
