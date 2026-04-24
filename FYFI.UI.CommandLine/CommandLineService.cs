using FyFi.UI.CommandLine;
using FYFI.Repository.InMemory.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FYFI.UI.CommandLine
{
    public class CommandLineService
    {

        public FiOutlook GenerateFinancialOutlook(int durationInYears, decimal savingsPerMonth) 
        {
            var financialOutlook = new FiOutlook();
            financialOutlook.FiOutlookYears = new List<FiOutlookYear>(); 

            for (int i = 0; i < durationInYears; i++)
            {
                var savingsPerYear = (decimal)savingsPerMonth * 12;

                var fiOutlookYear = CalculateFinancialOutlookYear(financialOutlook, savingsPerYear, i); 

                //var financialOutlookYear = new FiOutlookYear();
                //financialOutlookYear.YearDate = DateTime.Now.AddYears(i + 1);
                //financialOutlookYear.SavingsYearly = savingsPerYear; 
                ////financialOutlookYear.Cash = savingsPerYear;

                //if (i == 0)
                //{ 
                //    financialOutlookYear.Cash = savingsPerYear;
                //    financialOutlook.FiOutlookYears.Add(financialOutlookYear);

                //}


                //financialOutlookYear.Cash += financialOutlook.FiOutlookYears[i - 1].Cash;

                financialOutlook.FiOutlookYears.Add(fiOutlookYear);
            }

            return financialOutlook; 
        }

        private FiOutlookYear CalculateFinancialOutlookYear(FiOutlook financialOutlook, decimal savingsPerYear, int i) 
        {
            var financialOutlookYear = new FiOutlookYear();
            financialOutlookYear.YearDate = DateTime.Now.AddYears(i + 1);
            financialOutlookYear.SavingsYearly = savingsPerYear;
            //financialOutlookYear.Cash = savingsPerYear;

            if (i == 0)
            {
                financialOutlookYear.Cash = savingsPerYear;
                return financialOutlookYear; 
            }


            financialOutlookYear.Cash = financialOutlook.FiOutlookYears[i - 1].Cash;
            financialOutlookYear.Cash += savingsPerYear;

            return financialOutlookYear; 
        }

        public FYFI_ACTION GetArgInput(string initialPrompt, string? appendedErrorPrompt = null) 
        {

            FYFI_ACTION argAction = GetUserInputEnum<FYFI_ACTION>(initialPrompt, appendedErrorPrompt);

            return argAction; 

        }

        public int GetDurationYearsInput(string initialPrompt, string? appendedErrorPrompt = null) 
        {
            var durationYearsInput = GetUserInput<int>(initialPrompt, appendedErrorPrompt); 

            return durationYearsInput;
        }

        public decimal GetSavingsPerMonth(string initialPrompt, string? appendedErrorPrompt = null)
        {
            var savingsPerMonth = GetUserInput<decimal>(initialPrompt, appendedErrorPrompt);

            return savingsPerMonth; 
        }


        public bool GetShouldSaveForecastInput(string initialPrompt, string? appendedErrorPrompt = null)
        {
            var shouldSaveForecastInput = GetUserInput<bool>(initialPrompt, appendedErrorPrompt = null);

            return shouldSaveForecastInput;
        }

        public string GetFiOutlookNameInput(string initialPrompt, string? appendedErrorPrompt = null)
        {
            var financialOutlookName = GetUserInput<string>(initialPrompt, appendedErrorPrompt);

            return financialOutlookName;
        }

        public EDIT_OUTLOOK_OPTIONS GetEditOutlookOptionInput(string initialPrompt, string? appendedErrorPrompt = null)
        {
            EDIT_OUTLOOK_OPTIONS argAction = GetUserInputEnum<EDIT_OUTLOOK_OPTIONS>(initialPrompt, appendedErrorPrompt);

            return argAction;
        }

        public int GetFiOutlookId(string initialPrompt, string? appendedErrorPrompt = null)
        {
            var fiOutlookId = GetUserInput<int>(initialPrompt, appendedErrorPrompt);

            return fiOutlookId;
        }

        internal T GetUserInput<T>(string initialPrompt, string? errorPrompt = null) where T : IParsable<T>
        {
            errorPrompt = errorPrompt ?? string.Empty;

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
            T inputParsed = default(T);
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
    }
}
