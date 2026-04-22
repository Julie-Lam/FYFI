using FYFI.UI.CommandLine;

namespace FyFi.UI.CommandLine
{
    internal class Program
    {

        static CommandLineService _cmdLineService { get; set; } = new CommandLineService();
        static FYFIRepository _repository { get; set; } = new FYFIRepository(); 
        static void Main(string[] args)
        {
            var argInput = _cmdLineService.GetArgInput("Enter an arg to specify the action you'd like to perform: New_Forecast", "Please enter a valid action from the provided list");

            switch (argInput)
            {
                case FYFI_ACTION.New_Forecast:
                {
                    var durationYears = _cmdLineService.GetDurationYearsInput("How many years would you like to predict in the future?", "Please enter a whole number");
                    var savingsPerMonth = _cmdLineService.GetSavingsPerMonth("How much money are you saving per month? e.g. 2500.00", "Please enter a decimal number");


                    //Calculate the forcast
                    var financialOutlook = _cmdLineService.GenerateFinancialOutlook(durationYears, savingsPerMonth);


                    foreach (var year in financialOutlook.FiOutlookYears)
                    {
                        Console.WriteLine($"Year {year.YearDate} || Cash: {year.Cash.ToString("C")}");
                    }

                    var shouldSaveForecastInput = _cmdLineService.GetSaveForecastInput("Would you like to save this financial outlook? true for yes, false for no", "Please enter a valid response. ");

                    if (shouldSaveForecastInput)
                    {
                        _repository.UpsertFinancialOutlook(financialOutlook); 
                        
                    };


                    break;
                }

                case FYFI_ACTION.List_Saved_Forecasts:
                {

                    //TODO: Get all the forecastYears from a db somewhere... 
                    break; 
                }
                default:
                { 
                    break;
                }
            }



        }


    }

}
