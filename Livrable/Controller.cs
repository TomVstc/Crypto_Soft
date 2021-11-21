using System;
using System.Collections.Generic;
using System.Text;

namespace Livrable
{
    class Controller
    {
        private Model model;
        private ViewSave viewSave;
        public Controller()
        {
            // Model and View instantiate in the controller
            model = new Model();
            viewSave = new ViewSave();

            // Call the function to start a save
            viewSave.startSave();
        }
    }
}
