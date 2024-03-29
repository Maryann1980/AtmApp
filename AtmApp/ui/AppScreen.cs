﻿using AtmApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AtmApp.ui
{
    public static class AppScreen
    {
        internal static void Welcome()
        {
            //clears the console screen
            Console.Clear();

            //sets the title of the console window
            Console.Title = "My Atm App";

            //Sets the texts colour
            Console.ForegroundColor = ConsoleColor.White;


            //set the welcome message
            Console.WriteLine("\n\n............Welcome to Maryann ATM App.............\n\n");

            //prompts the user to insert ATM card
            Console.WriteLine("Please insert your ATM card");
            Console.WriteLine();
            Console.WriteLine("Note: Actual ATM machine will accept and validate a physical ATM card, read the card number and validate it.");

           Utility.PressEnterToContinue();

        }
        internal static UserAccount UserLoginForm()
        {
            UserAccount tempUserAccount = new UserAccount();

            tempUserAccount.CardNumber = Validator.convert<long>(" your card number.");
            tempUserAccount.CardPin = Convert.ToInt32(Utility.GetSecretInput(" Enter your card PIN"));
            return tempUserAccount;
        }

        internal static void LoginProgress()
        {
            Console.WriteLine("\nChecking card number and PIN...");
            Utility.PrintDotAnimation();
        }
        internal static void PrintLockScreen()
        {
            Console.Clear();
            Utility.PrintMessage("Your account is locked." +
                " Please go to the nearest branch to unlock your account, Thank you!", true);
            Utility.PressEnterToContinue();
            Environment.Exit(1);
        }
    }
}
