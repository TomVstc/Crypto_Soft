using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace Livrable_AppliGraphique
{
    public sealed class Controller
    {
        private static Controller instance = null;
        // Semaphore -> Limit the number of Thread
        public static Semaphore MaxSizeSemaphore;
        private static readonly object padlock = new object();

        public Controller()
        {
            MaxSizeSemaphore = new Semaphore(1, 1);
        }

        public static Controller Instance
        {
            get
            {
                lock (padlock)
                {
                    if (instance == null)
                    {
                        instance = new Controller();
                    }
                    return instance;
                }
            }
        }
    }
}
