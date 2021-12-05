using Livrable_AppliGraphique.Save_Window;
using System;
using System.Collections.Generic;
using System.Text;

namespace Livrable_AppliGraphique
{
    public interface IController
    {
        void updateSave(string Source, string Directory);
    }
}
