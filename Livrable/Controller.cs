using System;
using System.Collections.Generic;
using System.Text;
using System.Resources;
using System.Reflection;
using System.Threading;
using System.Globalization;

namespace Livrable
{
    class Controller : IController
    {
        ResourceManager rm = new ResourceManager("Livrable.Langage.Strings",
        Assembly.GetExecutingAssembly());

        private Model model;
        private ViewSave viewSave;
        private ViewDailyLog viewDailyLog;
        private int numberSave { get; set; }
        public string Langage { get; set; }
        public Controller()
        {
            // Model and View instantiate in the controller
            model = new Model();
            viewSave = new ViewSave();
            viewDailyLog = new ViewDailyLog();
            numberSave = 0;
            viewSave.setController(this);
            viewDailyLog.setController(this);

            // Call the function to start a save
            viewSave.startSave();
        }

        public void updateSave()
        {
            if(numberSave < 5)
            {
                model.FileName = viewSave.Name;
                model.FileSource = viewSave.FileSource;
                model.FileTarget = viewSave.FileTarget;
                model.Type = viewSave.Type;
                model.Destination = viewSave.Destination;
                model.Extension = viewSave.Extension;
                model.FileTransfertTime = viewDailyLog.FileTransfertTime;
                model.FileSize = viewDailyLog.FileSize;
                viewDailyLog.Name = model.FileName;
                viewDailyLog.FileSource = model.FileSource;
                viewDailyLog.FileTarget = model.FileTarget;
                viewDailyLog.Destination = model.Destination;
                viewDailyLog.Extension = model.Extension;
                createSave();
                createDailyLog();
                numberSave++;
                viewSave.startSave();
            }
            else
            {
                Console.WriteLine("\nYou did 5 saves. You can't do more");
            }

        }
        
        // When a state is in good state, the controller
        // call the model to create the save
        public void createSave()
        {
            model.createSave();
        }
        public void createDailyLog()
        {
            viewDailyLog.getValuesSave(viewDailyLog);
            model.createDailyLog(viewDailyLog);
        }
    }
}
