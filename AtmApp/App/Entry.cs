using AtmApp.ui;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AtmApp.App
{
    internal class Entry
    {
        static void Main(string[] args)
        {
            AppScreen.Welcome();
            AtmApp atmApp = new AtmApp();
            atmApp.InitializeData();
            atmApp.checkUserCardNumAndPassword();
            atmApp.welcome();

            Utility.PressEnterToContinue();

        }
    }
}
