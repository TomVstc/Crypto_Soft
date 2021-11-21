using System;
using System.Collections.Generic;
using System.Text;

namespace Livrable
{
    class ViewSave
    {
        // All attributes of a save
        private string name;
        private string fileSource;
        private string fileTarget;
        private enumType type;
        private string typeNumber;
        public enum enumType { Aucun, Complet, Différentiel}

        // Constructor call at the creation
        public ViewSave()
        {
            name = "";
            fileSource = "";
            fileTarget = "";
            type = enumType.Aucun;
            typeNumber = "";            
        }

        public void startSave()
        {
            Console.WriteLine("Veuillez entrer le nom de votre sauvegarde");
            name = Console.ReadLine();
            Console.WriteLine("Veuillez entrer le chemin source");
            fileSource = Console.ReadLine();
            Console.WriteLine("Veuillez entrer le chemin de destination");
            fileTarget = Console.ReadLine();
            Console.WriteLine("Veuillez entrer le type de sauvegarde : 1 = Complet / 2 = Différentiel");
            typeNumber = Console.ReadLine();
            if (typeNumber == "1")
            {
                type = enumType.Complet;
            }
            else if(typeNumber == "2")
            {
                type = enumType.Différentiel;
            }
        }

    }
}
