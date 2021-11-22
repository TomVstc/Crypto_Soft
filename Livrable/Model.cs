using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

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
            if(Save.Type == "Full")
            {
                if(Save.Destination == "File")
                {
                    string fileName = save.Name + "." + save.Extension;
                    string fileSource = save.FileSource;
                    string fileTarget = save.FileTarget;
                    string path = fileTarget + @"\" + fileName;

                    System.IO.File.Copy(fileSource, path, true);

                    Console.WriteLine("File Create\n");
                }
                if(Save.Destination == "Directory")
                {
                    string fileName = save.Name;
                    string fileSource = save.FileSource;
                    string fileTarget = save.FileTarget + @"\" + save.Name;

                    string[] files = System.IO.Directory.GetFiles(fileSource);
                    string destFile = System.IO.Path.Combine(fileTarget, fileName);

                    // Copy the files and overwrite destination files if they already exist.
                    foreach (string s in files)
                    {
                        // Use static Path methods to extract only the file name from the path.
                        fileName = System.IO.Path.GetFileName(s);
                        destFile = System.IO.Path.Combine(fileTarget, fileName);
                        System.IO.File.Copy(s, destFile, true);
                    }

                    Console.WriteLine("\nDirectory Create Create\n");

                }
            }
            if (Save.Type == "Differential")
            {
                Console.WriteLine("\nDifferential no increment");
            }

        }


    }
}
