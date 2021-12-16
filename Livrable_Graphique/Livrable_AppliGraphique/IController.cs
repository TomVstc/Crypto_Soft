using Livrable_AppliGraphique.Save_Window;
using System;
using System.Collections.Generic;
using System.Text;

namespace Livrable_AppliGraphique
{
    public interface IController
    {
        void updateSave(string dirOrFile, string name, string Source, string Directory);
    }
}
