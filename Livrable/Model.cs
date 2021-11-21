using System;
using System.Collections.Generic;
using System.Text;

namespace Livrable
{
    class Model
    {
        // All attributes
        private ViewSave save;

        // Creation of set and get
        public ViewSave Save
        {
            get { return save; }
            set { save = value;  }
        }

        // Constructor
        public Model()
        {
        }

        public void createSave()
        {
            if(Save.Type == "Complet")
            {
                string fileName = save.Name;
                string fileSource = save.FileSource;
                string fileTarget = save.FileTarget;

                System.IO.File.Copy(fileSource, fileTarget + @"\" + fileName, true);

            }
            if (Save.Type == "Differentiel")
            {
                Console.WriteLine("Coucou c'est differentiel");
            }

        }


    }
}
