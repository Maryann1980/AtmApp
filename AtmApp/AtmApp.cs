using AtmApp.ui;
using AtmApp.Domain.Entities;
using System;
using System.Collections.Generic;
using AtmApp.Domain.Interfaces;

namespace AtmApp
{
    public class AtmApp : IUserLogin
    {
        private List<UserAccount> userAccountList;
        private UserAccount selectedAccount;

        public void InitializeData()
        {
            userAccountList = new List<UserAccount>
            {
                new UserAccount{Id =1, FullName = "Maryann Igwe",
                    AccountNumber = 123456, CardNumber = 123123, CardPin = 123,
                    AccountBalance = 50000.00m, IsLocked=false },

                new UserAccount{Id =2, FullName = "Jayden Igwe",
                    AccountNumber = 4567789, CardNumber = 456456, CardPin = 456,
                    AccountBalance = 6000.00m, IsLocked=false },

                new UserAccount{Id =3, FullName = "Reign Ugo",
                    AccountNumber = 123555, CardNumber = 987987, CardPin = 789,
                    AccountBalance = 5000.00m, IsLocked=false },
            };
        }

        public void checkUserCardNumAndPassword()
        {
            bool isCorrectLogin = false;
            while(isCorrectLogin == false)
            {
                UserAccount inputAccount = AppScreen.UserLoginForm();

                AppScreen.LoginProgress();
                foreach(UserAccount account in userAccountList)
                {
                    selectedAccount = account;
                    if (inputAccount.CardNumber.Equals(selectedAccount.CardNumber))
                    {
                        selectedAccount.TotalLogin++;

                        if(inputAccount.CardPin.Equals(selectedAccount.CardPin))
                        {
                            selectedAccount = account;

                            if(selectedAccount.IsLocked || selectedAccount.TotalLogin > 3)
                            {
                                AppScreen.PrintLockScreen();

                            }
                            else
                            {
                                selectedAccount.TotalLogin = 0;
                                isCorrectLogin = true;
                                break;
                            }
                        }
                    }
                    if (isCorrectLogin == false)
                    {
                        Utility.PrintMessage("\n Invalid card number or PIN!", false);
                        selectedAccount.IsLocked = selectedAccount.TotalLogin == 3;
                        if (selectedAccount.IsLocked)
                        {
                            AppScreen.PrintLockScreen();
                        }
                    }
                    Console.Clear();
                }
            }
           
          
        }

        //new method to welcome logged in user
       public void welcome()
        {
            Console.WriteLine($"Welcome back, {selectedAccount.FullName}");
        }
    }
}
