using System;
using System.Collections.Generic;
using System.Text;

namespace Livrable
{
    class Controller : IController
    {
        private Model model;
        private ViewSave viewSave;
        private int numberSave { get; set; }
        public Controller()
        {
            // Model and View instantiate in the controller
            model = new Model();
            viewSave = new ViewSave();
            numberSave = 0;
            viewSave.setController(this);

            // Call the function to start a save
            viewSave.startSave();
        }

        public void updateSave()
        {
            if(numberSave < 5)
            {
                model.Save = viewSave;
                createSave();
                numberSave++;
                viewSave.startSave();
            }
            else
            {
                Console.WriteLine("\nYou did 5 saves.");
            }

        }
        
        // When a state is in good state, the controller
        // call the model to create the save
        public void createSave()
        {
            model.createSave();
        }
    }
}
