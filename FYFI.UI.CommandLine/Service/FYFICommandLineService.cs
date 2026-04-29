using FYFI.Core;
using FYFI.Core.Enums;
using FYFI.Repository.InMemory.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FYFI.UI.CommandLine.Service
{

    /// <summary>
    /// These functions support the FYFI.UI.CommandLine project
    /// </summary>
    public class FYFICommandLineService
    {
        public IUserInterfaceService _consoleUserInterfaceService { get; set; } = new ConsoleUserInterfaceService();
        public FYFIBLLService _fyfiBllService { get; set; } = new FYFIBLLService();
        public IFYFIRepositoryService _repository { get; set; } = new FYFIRepositoryService();


        public void Handle() 
        {
            while (true)
            {
                var argOptions = (FYFI_ACTION[])Enum.GetValues(typeof(FYFI_ACTION));

                var argInput = _consoleUserInterfaceService.GetArgInput($"Enter an arg to specify the action you'd like to perform: {String.Join(", ", argOptions)}", "Please enter a valid action from the provided list");

                switch (argInput)
                {
                    case FYFI_ACTION.NewOutlook:
                        {
                            this.HandleNewOutlook();

                            break;
                        }

                    case FYFI_ACTION.ListSavedOutlooks:
                        {
                            this.HandleListSavedOutlooks();
                            break;
                        }


                    case FYFI_ACTION.ViewOutlookDetails:
                        {
                            this.HandleViewOutlookDetails();
                            break;
                        }
                    case FYFI_ACTION.EditOutlook:
                        {
                            this.HandleEditOutlook();

                            break;
                        }
                    default:
                        {
                            break;
                        }
                }
            }
        }
        public void HandleNewOutlook()
        {
            var durationYears = _consoleUserInterfaceService.GetDurationYearsInput("How many years would you like to predict in the future?", "Please enter a whole number");
            var savingsPerMonth = _consoleUserInterfaceService.GetSavingsPerMonth("How much money are you saving per month? e.g. 2500.00", "Please enter a decimal number");


            //Calculate the forcast
            var financialOutlook = _fyfiBllService.GenerateFinancialOutlook(durationYears, savingsPerMonth);

            _consoleUserInterfaceService.PrintFinancialOutlookDetails(financialOutlook);

            var shouldSaveForecastInput = _consoleUserInterfaceService.GetShouldSaveForecastInput("Would you like to save this financial outlook? true for yes, false for no", "Please enter a valid response. ");

            if (shouldSaveForecastInput)
            {
                var fiOutlookName = _consoleUserInterfaceService.GetFiOutlookNameInput("Please enter a memorable name for this financial outlook");

                financialOutlook.FiOutlookName = fiOutlookName;

                _repository.UpsertFinancialOutlook(financialOutlook);

            };
        }

        public void HandleListSavedOutlooks()
        {
            var fiOutlooks = _repository.GetAllFinancialOutlooks();

            _consoleUserInterfaceService.PrintFinancialOutlooks(fiOutlooks);
        }

        public void HandleViewOutlookDetails()
        {
            var fiOutlookIdInput = _consoleUserInterfaceService.GetFiOutlookId("Please enter the id of the financial outlook you'd like view the details of");

            var savedFinancialOutlook = _repository.GetFinancialOutlookById(fiOutlookIdInput);

            _consoleUserInterfaceService.PrintFinancialOutlookDetails(savedFinancialOutlook);
        }

        public void HandleEditOutlook()
        {
            //Prompt which id they want to enter 
            var fiOutlookIdInput = _consoleUserInterfaceService.GetFiOutlookId("Please enter the id of the financial outlook you'd like to edit");

            //Get the fioutlook based on id 
            var savedFinancialOutlook = _repository.GetFinancialOutlookById(fiOutlookIdInput);

            var editOutlookOption = _consoleUserInterfaceService.GetEditOutlookOptionInput($"What would you like to edit? Select the list: {String.Join(", ", (EDIT_OUTLOOK_OPTIONS[])Enum.GetValues(typeof(EDIT_OUTLOOK_OPTIONS)))}");

            switch (editOutlookOption)
            {
                case EDIT_OUTLOOK_OPTIONS.OutlookName:
                    {
                        this.HandleEditOutlookName(savedFinancialOutlook); 
                        break;
                    }
                case EDIT_OUTLOOK_OPTIONS.OutlookDurationYears:
                    {
                        this.HandleEditOutlookDurationYears(savedFinancialOutlook); 
                        break;
                    }
                case EDIT_OUTLOOK_OPTIONS.OutlookSavingsPerMonth:
                    {
                        this.HandleEditOutlookSavingsPerMonth(savedFinancialOutlook); 

                        break;
                    }
                default:
                    break;
            }
        }

        public void HandleEditOutlookName(FiOutlook savedFinancialOutlook)
        {
            var fiOutlookName = _consoleUserInterfaceService.GetFiOutlookNameInput("Please enter a new name for this financial outlook");

            savedFinancialOutlook.FiOutlookName = fiOutlookName;

            _repository.UpsertFinancialOutlook(savedFinancialOutlook);
        }

        public void HandleEditOutlookDurationYears(FiOutlook savedFinancialOutlook)
        {
            var fiOutlookDurationYears = _consoleUserInterfaceService.GetFiOutlookDurationYearsInput("Please enter the new duration in years for this financial outlook");

            if (fiOutlookDurationYears == savedFinancialOutlook.FiOutlookYears.Count)
            {
                //do nothing; 
            }

            if (fiOutlookDurationYears > savedFinancialOutlook.FiOutlookYears.Count)
            {
                var additionalYears = Math.Abs(fiOutlookDurationYears - savedFinancialOutlook.FiOutlookYears.Count);

                var savingsPerYear = savedFinancialOutlook.FiOutlookYears.Last().SavingsYearly;


                for (int i = 0; i < additionalYears; i++)
                {
                    var yearNum = additionalYears + i;
                    var prevOutlookYearCash = savedFinancialOutlook.FiOutlookYears[(savedFinancialOutlook.FiOutlookYears.Count) - 1].Cash;
                    var additionalFiOutlookYear = _fyfiBllService.CalculateFinancialOutlookYear(savingsPerYear, yearNum, prevOutlookYearCash);

                    savedFinancialOutlook.FiOutlookYears.Add(additionalFiOutlookYear);
                }

                _repository.UpsertFinancialOutlook(savedFinancialOutlook);
            }

            if (fiOutlookDurationYears < savedFinancialOutlook.FiOutlookYears.Count)
            {
                var deductedYears = Math.Abs(fiOutlookDurationYears - savedFinancialOutlook.FiOutlookYears.Count);

                var maxIndex = savedFinancialOutlook.FiOutlookYears.IndexOf(savedFinancialOutlook.FiOutlookYears.Last());
                var startingIndex = maxIndex - deductedYears;
                savedFinancialOutlook.FiOutlookYears.RemoveRange(startingIndex, deductedYears);

                _repository.UpsertFinancialOutlook(savedFinancialOutlook);
            }
        }

        public void HandleEditOutlookSavingsPerMonth(FiOutlook savedFinancialOutlook)
        {
            var savingsPerMonth = _consoleUserInterfaceService.GetSavingsPerMonth("Enter the new savings per month for this financial outlook, e.g. 2500, 2500.50", "Please enter a decimal number");

            //todo: recalculate the entire outlook.years
            var durationInYears = savedFinancialOutlook.FiOutlookYears.Count();

            savedFinancialOutlook.FiOutlookYears = _fyfiBllService.CalculateFinancialOutlookYears(durationInYears, savingsPerMonth);
        }

    }
}
