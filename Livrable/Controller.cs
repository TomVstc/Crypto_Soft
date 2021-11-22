using System;
using System.Collections.Generic;
using System.Text;

namespace Livrable
{
    class Controller : IController
    {
        private Model model;
        private ViewSave viewSave;
        public Controller()
        {
            // Model and View instantiate in the controller
            model = new Model();
            viewSave = new ViewSave();

            viewSave.setController(this);

            // Call the function to start a save
            viewSave.startSave();
        }

        public void updateSave()
        {
            model.Save = viewSave;
            createSave();
        }
        
        // When a state is in good state, the controller
        // call the model to create the save
        public void createSave()
        {
            model.createSave();
        }
    }
}
