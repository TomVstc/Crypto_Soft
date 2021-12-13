using Livrable_AppliGraphique.Save_Window;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Text;
using System.Threading;
using System.Linq;
using Livrable_AppliGraphique.Setting_Window;
using System.Windows;

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
        private string encryptInfo;
        private string softwareSocietyName;
        private bool softwareSocietySave;
        public bool flag;

        #endregion

        #region SET/GET
        //Creation of set and get
        public string SoftwareSocietyName
        {
            get { return softwareSocietyName; }
            set { softwareSocietyName = value; }
        }
        public bool SoftwareSocietySave
        {
            get { return softwareSocietySave; }
            set { softwareSocietySave = value; }
        }
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
        public string EncryptInfo
        {
            get { return encryptInfo; }
            set { encryptInfo = value; }
        }


        #endregion

        public Save(string type, string Name, string FileSource, string Destination)
        {
            Type = type;
            FileName = Name;
            fileSource = FileSource;
            destination = Destination;
        }

        public void runningSoftware()
        {
            while(flag == false)
            {
                EnterpriseSoftwareRunning(softwareSocietyName);
            }
        }



        public void fileSave()
        {
            //-----------------Test thread------------------------------//

            Thread runningSoftare = new Thread(runningSoftware);
            runningSoftare.Start();

            //if (ResultSoftwareSociety == true)
            //{
            //    MessageBox.Show("pas de logiciel metier");
            //}
            //----------------------------------------------------------//
            flag = false;
            BackupState = "ACTIF";
            string fileName = FileName;
            string fileSource = FileSource;
            string fileTarget = Destination;
            string path = fileTarget + @"\" + fileName;
            if (Type == "File")
            {
                DateTime Start = DateTime.Now;
                Time = Start;

                System.IO.File.Copy(fileSource, path, true);
                DateTime Stop = DateTime.Now;

                string recupExtention = fileSource.Split(".").Last();

                //cryptage du fichier
                if (recupExtention == Extension)
                {
                    DateTime startCrypt = DateTime.Now;
                    encrypt(fileSource, path);
                    DateTime stopCrypt = DateTime.Now;
                    encryptInfo = (stopCrypt - startCrypt).ToString();
                }
                else
                {
                    encryptInfo = "0";
                }
 

                FileTransfertTime = (Stop - Start).ToString();
                TotalFileToCopy = 1;

                // Recup File Size
                FileInfo fileinfo = new FileInfo(Destination + @"\" + fileName);
                FileSize = fileinfo.Length;

                System.Windows.MessageBox.Show(Livrable_AppliGraphique.Properties.Langs.Lang.done);
            }
            if (Type == "Directory")
            {
                DirectoryInfo dir = new DirectoryInfo(fileSource);
                DirectoryInfo[] dirs = dir.GetDirectories();
                // If destination doesn't exist => create
                Directory.CreateDirectory(path);

                FileInfo[] files = dir.GetFiles();

                DateTime Start = DateTime.Now;
                Time = Start;
                DateTime startCrypt = DateTime.Now;

                foreach (FileInfo file in files)
                {
                    FileSize += file.Length;
                    file.CopyTo(path + @"\" + file.Name, false);
                    TotalFileToCopy++;

                    string recupExtention = file.Name.Split(".").Last();
                    string test = fileTarget + @"\" + fileName + @"\" + file.Name;

                    if (recupExtention == Extension)
                    {
                        encrypt(fileSource + @"\" + file.Name, test);
                    }
                }
                DateTime stopCrypt = DateTime.Now;
                encryptInfo = (stopCrypt - startCrypt).ToString();

                DateTime Stop = DateTime.Now;
                FileTransfertTime = (Stop - Start).ToString();
                System.Windows.MessageBox.Show(Livrable_AppliGraphique.Properties.Langs.Lang.done);
            }

            // Create StateLog when a Save = Actif
            StateLog state = new StateLog(
                this.fileName,
                this.fileSource,
                this.destination,
                this.Time,
                this.BackupState,
                this.TotalFileToCopy,
                this.FileSize,
                this.TotalFileToCopy,
                (int)this.FileSize
                );
            ;

            // DailyLog update
            DailyLog daily = new DailyLog(
                this.fileName,
                this.fileSource,
                this.destination,
                this.FileSize,
                this.fileTransfertTime,
                this.Time,
                this.encryptInfo);

            BackupState = "NON ACTIF";
            // Update StateLog
            StateLog stateLog = new StateLog(
                this.fileName,
                this.BackupState);

            flag = true;
        }

        // ANALYSER CE QUIL Y A DANS PROCESS (si detect calculatrice ou logiciel prosoft alors crash)
        // Detect Software society
        public bool EnterpriseSoftwareRunning(string nameSoftware)
        {

                if (Process.GetProcessesByName(nameSoftware).Length > 0)
                {
                    string message = Livrable_AppliGraphique.Properties.Langs.Lang.openSoftware;
                    string caption = "EasySave";
                    var result = System.Windows.MessageBox.Show(message, caption,
                        System.Windows.MessageBoxButton.YesNo);
                    switch (result)
                    {
                        case System.Windows.MessageBoxResult.Yes:
                            Process[] proc = Process.GetProcessesByName(nameSoftware);
                            if (proc.Length == 0)
                            {
                                System.Windows.MessageBox.Show(Livrable_AppliGraphique.Properties.Langs.Lang.softwareClose);
                            }
                            else
                            {
                                proc[0].Kill();
                                System.Windows.MessageBox.Show(Livrable_AppliGraphique.Properties.Langs.Lang.softwareClose);
                            }
                            break;
                        case System.Windows.MessageBoxResult.No:
                            EnterpriseSoftwareRunning(nameSoftware);
                            break;
                    }
                    softwareSocietySave = true;
                    return true;
                
            }
            softwareSocietySave = false;
            return false;
        }

        public void encrypt(string pathFileToEncrypt, string pathTargetFile)
        {
            StreamReader sr = new StreamReader(pathFileToEncrypt); //fichier à crypter
            StreamWriter sw = new StreamWriter(pathTargetFile); //fichier où écrire
            Process crypt = new Process(); //logiciel cryptosoft

            //recup du chemin vers l'exécutable de cryptosoft adapté à chaque PC
            //string fullPath = Environment.CurrentDirectory;
            //string halfPath = fullPath.Substring(0, 133);
            //string path = "Cryptage.exe";

            crypt.StartInfo.FileName = @"D:\Code\Projet_Programmation_Systeme\Programmation_Systeme_G1\Cryptage\Cryptage.exe";
            crypt.StartInfo.UseShellExecute = false;
            crypt.StartInfo.RedirectStandardOutput = true;
            crypt.StartInfo.RedirectStandardInput = true;
            crypt.StartInfo.RedirectStandardError = true;

            string line;
            line = sr.ReadLine();

            while (line != null)
            {
                crypt.StartInfo.Arguments = line; //on demande au logiciel de cryptage de crypter le contenu du fichier
                crypt.Start(); //lancement de cryptosoft
                string cryptedLine = crypt.StandardOutput.ReadToEnd();
                crypt.WaitForExit();

                sw.WriteLine(cryptedLine); //on écrit dans le fichier le contenu crypté du précédent fichier 
                line = sr.ReadLine();
            }

            sr.Close();
            sw.Close();
        }
    }
}
