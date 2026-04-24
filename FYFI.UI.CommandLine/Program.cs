using FYFI.Repository.InMemory.Migrations;
using FYFI.UI.CommandLine;

namespace FyFi.UI.CommandLine
{
    internal class Program
    {

        static CommandLineService _cmdLineService { get; set; } = new CommandLineService();
        static FYFIRepository _repository { get; set; } = new FYFIRepository(); 
        static void Main(string[] args)
        {
            var argOptions = (FYFI_ACTION[])Enum.GetValues(typeof(FYFI_ACTION)); 

            var argInput = _cmdLineService.GetArgInput($"Enter an arg to specify the action you'd like to perform: {String.Join(", ", argOptions)}", "Please enter a valid action from the provided list");

            switch (argInput)
            {
                case FYFI_ACTION.NewOutlook:
                    {
                        var durationYears = _cmdLineService.GetDurationYearsInput("How many years would you like to predict in the future?", "Please enter a whole number");
                        var savingsPerMonth = _cmdLineService.GetSavingsPerMonth("How much money are you saving per month? e.g. 2500.00", "Please enter a decimal number");


                        //Calculate the forcast
                        var financialOutlook = _cmdLineService.GenerateFinancialOutlook(durationYears, savingsPerMonth);


                        foreach (var year in financialOutlook.FiOutlookYears)
                        {
                            Console.WriteLine($"Year {year.YearDate} || Cash: {year.Cash.ToString("C")}");
                        }

                        var shouldSaveForecastInput = _cmdLineService.GetShouldSaveForecastInput("Would you like to save this financial outlook? true for yes, false for no", "Please enter a valid response. ");

                        if (shouldSaveForecastInput)
                        {
                            var fiOutlookName = _cmdLineService.GetFiOutlookNameInput("Please enter a memorable name for this financial outlook"); 

                            financialOutlook.FiOutlookName = fiOutlookName;

                            _repository.UpsertFinancialOutlook(financialOutlook); 
                        
                        };


                        break;
                    }

                case FYFI_ACTION.ListSavedOutlooks:
                    {
                        var fiOutlooks = _repository.GetAllFinancialOutlooks();

                        foreach (var outlook in fiOutlooks)
                        {
                            Console.WriteLine($"ID: {outlook.FiOutlookId} || {outlook.FiOutlookName}"); 
                        }

                        break; 
                    }

                case FYFI_ACTION.EditOutlook: 
                    {
                        //TODO: prompt which id they want to enter 
                        var fiOutlookIdInput = _cmdLineService.GetFiOutlookId("Please enter the id of the financial outlook you'd like to edit");

                        //Get the fioutlook based on id 
                        var savedFinancialOutlook = _repository.GetFinancialOutlookById(fiOutlookIdInput); 

                        var editOutlookOption = _cmdLineService.GetEditOutlookOptionInput($"What would you like to edit? Select the list: {String.Join(", ", (EDIT_OUTLOOK_OPTIONS[])Enum.GetValues(typeof(EDIT_OUTLOOK_OPTIONS)))}");

                        switch (editOutlookOption)
                        {
                            case EDIT_OUTLOOK_OPTIONS.OutlookName:
                                {
                                    var fiOutlookName = _cmdLineService.GetFiOutlookNameInput("Please enter a new name for this financial outlook");

                                    savedFinancialOutlook.FiOutlookName = fiOutlookName;

                                    _repository.UpsertFinancialOutlook(savedFinancialOutlook); 
                                    break;
                                }
                            case EDIT_OUTLOOK_OPTIONS.OutlookDurationYears:
                                { 
                                break;
                                }
                            case EDIT_OUTLOOK_OPTIONS.OutlookSavingsPerMonth:
                                { 
                                break;
                                }
                            default:
                                break;
                        }


                        break; 
                    }
                default:
                { 
                    break;
                }
            }



        }


    }

    public enum EDIT_OUTLOOK_OPTIONS
    {
        OutlookName = 1,
        OutlookDurationYears = 2, 
        OutlookSavingsPerMonth = 3

    }

}
