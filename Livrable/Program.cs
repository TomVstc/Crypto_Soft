using System;
using System.Threading;
using System.Resources;
using System.Reflection;
using System.Globalization;

namespace Livrable
{

    class Program
    {
        static void Main(string[] args)
        {
            ResourceManager rm = new ResourceManager("Livrable.Langage.Strings",
            Assembly.GetExecutingAssembly());

            Console.WriteLine("Veuillez choisir la langue.");
            Console.WriteLine("1 : Français || 2 : English");
            string value = Console.ReadLine();
            if (value == "1")
            {
                Thread.CurrentThread.CurrentUICulture = CultureInfo.CreateSpecificCulture("fr-FR");
                Controller controller = new Controller();
            }
            else if (value == "2")
            {
                Thread.CurrentThread.CurrentUICulture = CultureInfo.CreateSpecificCulture("en-US");
                Controller controller = new Controller();
            }
            else
            {
                Console.WriteLine("Langage Error");
            }
        }

    }


}
