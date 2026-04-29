using FYFI.Core.Enums;
using FYFI.Repository.InMemory.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FYFI.UI.CommandLine.Service
{
    public class ConsoleUserInterfaceService : IUserInterfaceService
    {

        public FYFI_ACTION GetArgInput(string initialPrompt, string appendedErrorPrompt = null)
        {

            FYFI_ACTION argAction = GetUserInputEnum<FYFI_ACTION>(initialPrompt, appendedErrorPrompt);

            return argAction;

        }

        public int GetDurationYearsInput(string initialPrompt, string appendedErrorPrompt = null)
        {
            var durationYearsInput = GetUserInput<int>(initialPrompt, appendedErrorPrompt);

            return durationYearsInput;
        }

        public decimal GetSavingsPerMonth(string initialPrompt, string appendedErrorPrompt = null)
        {
            var savingsPerMonth = GetUserInput<decimal>(initialPrompt, appendedErrorPrompt);

            return savingsPerMonth;
        }


        public bool GetShouldSaveForecastInput(string initialPrompt, string appendedErrorPrompt = null)
        {
            var shouldSaveForecastInput = GetUserInput<bool>(initialPrompt, appendedErrorPrompt = null);

            return shouldSaveForecastInput;
        }

        public string GetFiOutlookNameInput(string initialPrompt, string appendedErrorPrompt = null)
        {
            var financialOutlookName = GetUserInput<string>(initialPrompt, appendedErrorPrompt);

            return financialOutlookName;
        }

        public EDIT_OUTLOOK_OPTIONS GetEditOutlookOptionInput(string initialPrompt, string appendedErrorPrompt = null)
        {
            EDIT_OUTLOOK_OPTIONS argAction = GetUserInputEnum<EDIT_OUTLOOK_OPTIONS>(initialPrompt, appendedErrorPrompt);

            return argAction;
        }

        public int GetFiOutlookDurationYearsInput(string initialPrompt, string appendedErrorPrompt = null)
        {
            var durationYearsInput = GetUserInput<int>(initialPrompt, appendedErrorPrompt);

            return durationYearsInput;
        }

        public int GetFiOutlookId(string initialPrompt, string appendedErrorPrompt = null)
        {
            var fiOutlookId = GetUserInput<int>(initialPrompt, appendedErrorPrompt);

            return fiOutlookId;
        }

        internal TResult GetUserInput<TResult>(string initialPrompt, string errorPrompt = null) where TResult : IParsable<TResult>
        {
            errorPrompt = errorPrompt ?? string.Empty;

            TResult inputParsed;
            var isValidInput = false;
            do
            {
                Console.WriteLine(initialPrompt);
                var input = Console.ReadLine();


                isValidInput = TResult.TryParse(input, null, out inputParsed);
                if (isValidInput == false)
                {
                    Console.WriteLine($"{input} is not a valid input. {errorPrompt}");
                }
            } while (isValidInput == false);


            return inputParsed;
        }

        internal T GetUserInputEnum<T>(string initialPrompt, string errorPrompt = null) where T : struct, Enum
        {
            T inputParsed = default;
            var isValidInput = false;
            do
            {
                Console.WriteLine(initialPrompt);
                var input = Console.ReadLine();


                isValidInput = Enum.TryParse(input, true, out inputParsed) && Enum.IsDefined(typeof(T), inputParsed);
                if (isValidInput == false)
                {
                    Console.WriteLine($"{input} is not a valid input. {errorPrompt}");
                }
            } while (isValidInput == false);


            return inputParsed;
        }



        public void PrintFinancialOutlookDetails(FiOutlook financialOutlook)
        {
            foreach (var year in financialOutlook.FiOutlookYears)
            {
                Console.WriteLine($"Year {year.YearDate} || Cash: {year.Cash.ToString("C")}");

            }
        }

        public void PrintFinancialOutlooks(List<FiOutlook> fiOutlooks) 
        {
            foreach (var outlook in fiOutlooks)
            {
                Console.WriteLine($"ID: {outlook.FiOutlookId} || {outlook.FiOutlookName}");
            }
        }
    }
}
