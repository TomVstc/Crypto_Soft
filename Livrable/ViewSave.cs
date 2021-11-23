using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Linq;
using System.Diagnostics;
using System.Resources;
using System.Reflection;
using System.Threading;
using System.Globalization;

namespace Livrable
{
    class ViewSave
    {
        ResourceManager rm = new ResourceManager("Livrable.Langage.Strings",
        Assembly.GetExecutingAssembly());

        #region ALL ATTRIBUTE
        // All attributes of a save
        private string name;
        private string fileSource;
        private string fileTarget;
        private string type;
        private string destination;
        private string extention;

        private IController controller;
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
        public string FileTarget
        {
            get { return fileTarget; }
            set { fileTarget = value; }
        }
        public string Type
        {
            get { return type; }
            set { type = value;  }
        }
        public IController Controller
        {
            get { return Controller; }
            set { Controller = value; }
        }
        public string Destination
        {
            get { return destination; }
            set { destination = value; }
        }
        public string Extension
        {
            get { return extention; }
            set { extention = value; }
        }

        #endregion

        // Constructor call at the creation
        public ViewSave()
        {
            Destination = "";
            Extension = "";
            Name = "";
            FileSource = "";
            FileTarget = "";
            Type = "";
        }

        // Link ViewSave to controller
        public void setController(IController cont)
        {
            controller = cont;
        }

        // Create a Save
        public void startSave()
        {
            bool isSaveValid = false;

            if(Thread.CurrentThread.CurrentUICulture.Name == "en-US")
            {
                Console.WriteLine("\n" + (rm.GetString("informationSaveEN")) +"\n");
            }
            else if (Thread.CurrentThread.CurrentUICulture.Name == "fr-FR")
            {
                Console.WriteLine("\n" + (rm.GetString("informationSaveFR")) + "\n");
            }
            

            getDestination();

            if(destination == "File") // COPY OF A FILE
            {
                while (isSaveValid != true)
                {
                    getName();
                    getSourcePathFile();
                    getDestinationPathDirectory();
                    getType();
                    Extension = FileSource.Split(".").Last();

                    isSaveValid = true;
                }
                controller.updateSave();
            }
            else // COPY OF A DIRECTORY
            {
                while (isSaveValid != true)
                {
                    getName();
                    getSourcePathDirectory();
                    getDestinationPathDirectory();
                    getType();

                    isSaveValid = true;
                }
                controller.updateSave();
            }
        }

        #region FUNCTION TO RECUP AND CHECK
        // RECUP AND CHECK  THE SOURCE DIRECTORY
        public void getSourcePathDirectory()
        {
            bool isSourcePathValid = false;
            while (isSourcePathValid != true)
            {
                if (Thread.CurrentThread.CurrentUICulture.Name == "en-US")
                {
                    Console.WriteLine("\n" + (rm.GetString("directoryToCopyEN")) + "\n");
                }
                else if (Thread.CurrentThread.CurrentUICulture.Name == "fr-FR")
                {
                    Console.WriteLine("\n" + (rm.GetString("directoryToCopyFR")) + "\n");
                }
                fileSource = Console.ReadLine();
                isSourcePathValid = checkSourcePathDirectory(fileSource);
            }
        }
        public bool checkSourcePathDirectory(string SourceDirectory)
        {
            bool result = Directory.Exists(SourceDirectory);
            return result;
        }

        // RECUP AND CHECK THE DESTINATION
        public void getDestination()
        {
            bool isDestinationValid = false;
            while (isDestinationValid != true)
            {
                if (Thread.CurrentThread.CurrentUICulture.Name == "en-US")
                {
                    Console.WriteLine("\n" + (rm.GetString("copyDestinationEN")) + "\n");
                }
                else if (Thread.CurrentThread.CurrentUICulture.Name == "fr-FR")
                {
                    Console.WriteLine("\n" + (rm.GetString("copyDestinationFR")) + "\n");
                }
                destination = Console.ReadLine();
                isDestinationValid = checkDestination(destination);
            }
        }
        public bool checkDestination(string type)
        {
            if (type == "File" || type == "Directory")
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        // RECUP AND CHECK FOR A FILE
        public void getSourcePathFile()
        {
            bool isSourcePathValid = false;
            while (isSourcePathValid != true)
            {
                if (Thread.CurrentThread.CurrentUICulture.Name == "en-US")
                {
                    Console.WriteLine("\n" + (rm.GetString("getSourcePathFileEN")) + "\n");
                }
                else if (Thread.CurrentThread.CurrentUICulture.Name == "fr-FR")
                {
                    Console.WriteLine("\n" + (rm.GetString("getSourcePathFileFR")) + "\n");
                }
                FileSource = Console.ReadLine();
                isSourcePathValid = checkSourcePathFile(FileSource);
            }
        }
        public bool checkSourcePathFile(string FileSource)
        {
            bool result = File.Exists(FileSource);
            return result;
        }

        // RECUP AND CHECK FOR A DIRECTORY
        public void getDestinationPathDirectory()
        {
            bool isSourcePathValid = false;
            while (isSourcePathValid != true)
            {
                if (Thread.CurrentThread.CurrentUICulture.Name == "en-US")
                {
                    Console.WriteLine("\n" + (rm.GetString("getDestinationPathDirectoryEN")) + "\n");
                }
                else if (Thread.CurrentThread.CurrentUICulture.Name == "fr-FR")
                {
                    Console.WriteLine("\n" + (rm.GetString("getDestinationPathDirectoryFR")) + "\n");
                }
                FileTarget = Console.ReadLine();
                isSourcePathValid = checkDestinationPathDirectory(FileTarget);
            }
        }
        public bool checkDestinationPathDirectory(string FileTarget)
        {

            if (destination == "Directory")
            {
                string NameFile = FileTarget + @"\" + name;
                bool result = Directory.Exists(NameFile);
                if (result == false)
                {
                    FileTarget = NameFile;
                    System.IO.Directory.CreateDirectory(FileTarget);
                    result = true;
                }
                return result;
            }
            else
            {
                bool result = Directory.Exists(FileTarget);
                return result;
            }
            
            
        }

        // RECUP AND CHECK THE NAME
        public void getName()
        {
            bool isNameValid = false;
            while (isNameValid != true)
            {
                if (Thread.CurrentThread.CurrentUICulture.Name == "en-US")
                {
                    Console.WriteLine("\n" + (rm.GetString("getNameEN")) + "\n");
                }
                else if (Thread.CurrentThread.CurrentUICulture.Name == "fr-FR")
                {
                    Console.WriteLine("\n" + (rm.GetString("getNameFR")) + "\n");
                }
                Name = Console.ReadLine();
                isNameValid = checkName(Name);
            }
        }
        public bool checkName(string Name)
        {
            if(Name == "")
            {
                return false;
            }
            return true;
        }

        // RECUP AND CHECK THE TYPE
        public void getType()
        {
            bool isTypeValid = false;
            while (isTypeValid != true)
            {
                if (Thread.CurrentThread.CurrentUICulture.Name == "en-US")
                {
                    Console.WriteLine("\n" + (rm.GetString("getTypeEN")) + "\n");
                }
                else if (Thread.CurrentThread.CurrentUICulture.Name == "fr-FR")
                {
                    Console.WriteLine("\n" + (rm.GetString("getTypeFR")) + "\n");
                }
                type = Console.ReadLine();
                isTypeValid = checkType(type);
            }
        }
        public bool checkType(string type)
        {
            if (type == "Full" || type == "Differential")
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        #endregion
    }
}
