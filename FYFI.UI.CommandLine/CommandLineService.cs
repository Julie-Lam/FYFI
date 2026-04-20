using FyFi.UI.CommandLine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FYFI.UI.CommandLine
{
    public class CommandLineService
    {

        public FYFI_ACTION GetArgInput() 
        {
            //FYFI_ACTION argAction; 

            //var isValidArgInput = false;
            //do
            //{
            //    Console.WriteLine("Enter an arg to specify the action you'd like to perform: 1 (New_Forecast)");
            //    var argInput = Console.ReadLine();

            //    isValidArgInput = Enum.TryParse(argInput, out argAction);
            //    if (isValidArgInput == false)
            //    {
            //        Console.WriteLine($"{argInput} is not a valid action. Please enter a valid number");
            //    }
            //} while (isValidArgInput == false);


            //return argAction; 


            FYFI_ACTION argAction = GetUserInputEnum<FYFI_ACTION>("Enter an arg to specify the action you'd like to perform: 1 (New_Forecast)", "Please enter a valid number");

            return argAction; 

        }

        internal T GetUserInput<T>(string initialPrompt, string errorPrompt = null) where T : IParsable<T>
        {
            T inputParsed; 
            var isValidInput = false;
            do
            {
                Console.WriteLine(initialPrompt);
                var input = Console.ReadLine();


                isValidInput = T.TryParse(input, null, out inputParsed);
                if (isValidInput == false)
                {
                    Console.WriteLine($"{input} is not a valid input. {errorPrompt}");
                }
            } while (isValidInput == false);


            return inputParsed;
        }

        internal T GetUserInputEnum<T>(string initialPrompt, string errorPrompt = null) where T : struct, Enum
        {
            T inputParsed;
            var isValidInput = false;
            do
            {
                Console.WriteLine(initialPrompt);
                var input = Console.ReadLine();


                isValidInput = Enum.TryParse(input, out inputParsed);
                if (isValidInput == false)
                {
                    Console.WriteLine($"{input} is not a valid input. {errorPrompt}");
                }
            } while (isValidInput == false);


            return inputParsed;
        }
    }
}
