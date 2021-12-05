using Livrable_AppliGraphique.Model;
using Livrable_AppliGraphique.Save_Window;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace Livrable_AppliGraphique
{
    public sealed class Controller : IController
    {
        private Save save;
        private static Controller instance = null;
        // Semaphore -> Limit the number of Thread

        public Controller()
        {
        }

        public void updateSave(string v1, string v2)
        {
            Save save = new Save(v1, v2);
            save.test();
        }
    }
}
