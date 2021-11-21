using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace Livrable
{
    class ViewSave
    {
        // All attributes of a save
        private string name;
        private string fileSource;
        private string fileTarget;
        private string type;

        private IController controller;

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

        // Constructor call at the creation
        public ViewSave()
        {
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

            Console.WriteLine("\nEntrez les informations concernant la sauvegarde : ");

            while(isSaveValid != true)
            {
                Console.WriteLine("Veuillez entrer le nom de votre sauvegarde");
                Name = Console.ReadLine();
                Console.WriteLine("Veuillez entrer le fichier source (chemin)");
                FileSource = Console.ReadLine();
                Console.WriteLine("Veuillez entrer le chemin de destination");
                FileTarget = Console.ReadLine();
                Console.WriteLine("Veuillez entrer le type de sauvegarde : Complet / Differentiel");
                Type = Console.ReadLine();

                isSaveValid = checkIfSaveInputIsValid();
            }

            controller.updateSave();

        }

        // Function to valid if a save is in good type
        public bool checkIfSaveInputIsValid()
        {
            bool isValid = false;
            if(Name != "")
            {
                if (File.Exists(FileSource))
                {
                    if (Directory.Exists(FileTarget))
                    {
                        if (Type == "Complet" || Type == "Differentiel")
                        {
                            isValid = true;
                        }
                        else
                        {
                            Console.WriteLine("Type invalide");
                            startSave();
                        }
                    }
                    else
                    {
                        Console.WriteLine("Destination invalide");
                        startSave();
                    }

                }
                else
                {
                    Console.WriteLine("Source invalide");
                    startSave();
                }
            }
            else
            {
                Console.WriteLine("Nom invalide");
                startSave();
            }

            return isValid;
        }

    }
}
