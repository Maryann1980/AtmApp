using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AtmApp.ui
{
    public static class Validator
    {
        public static T convert<T>(string prompt)
        {
            bool valid = false;
            string userInput;

            while(!valid)
            {
                userInput = Utility.GetUserInput(prompt);

                try
                {
                 var converter = TypeDescriptor.GetConverter(typeof(T));
                    if(converter != null)
                    {
                        return (T)converter.ConvertFromString(userInput);
                    }
                    else
                    {
                        return default;
                    }
                }
                catch
                {
                    Utility.PrintMessage("Invalid. Try again!", false);
                }
            }
            return default;
        }
    }
}
