using Livrable_AppliGraphique.Model;
using Livrable_AppliGraphique.Save_Window;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Windows;

namespace Livrable_AppliGraphique
{
    public sealed class Controller : IController
    {
        private static Save save;
        private static Controller instance = null;
        public string softwareSocietyName;
        public string Extention;
        public bool stateSave;
        public bool flag;

        public Controller()
        {
        }

        public void checkStateSave()
        {
            while (true)
            {
                if (stateSave == true)
                {
                    save.stopSave = true;
                }
                else
                {
                    save.stopSave = false;
                }
            }
        }

        // Function call to update
        public void updateSave(string dirOrFile, string name, string source, string destination)
        {
            flag = false;
            save = new Save(dirOrFile, name, source, destination);
            save.SoftwareSocietyName = softwareSocietyName;
            save.Extension = Extention;
            save.EnterpriseSoftwareRunning(softwareSocietyName);

            Thread updateStateSave = new Thread(checkStateSave);
            updateStateSave.Start();

            save.saveThread(); // backup thread

            flag = true;
        }
    }
}

