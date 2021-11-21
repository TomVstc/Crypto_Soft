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
            model = new Model();
            viewSave = new ViewSave();
        }
    }
}
