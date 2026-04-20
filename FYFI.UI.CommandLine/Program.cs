namespace FyFi.UI.CommandLine
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello!");

            var isValidArgInput = false; 
            do
            {
                Console.WriteLine("Enter an arg to specify the action you'd like to perform: 1 (New_Forecast)");
                var argInput = Console.ReadLine();

                isValidArgInput = Enum.TryParse(typeof(FYFI_ACTION), argInput, out var argAction);
                if (isValidArgInput == false)
                {
                    Console.WriteLine($"{argInput} is not a valid action. Please enter a valid number");
                }
            } while (isValidArgInput == false); 



            var yearCount = 0;
            var savingsPerMonth = 0m; 

            var isValidYearsInput = false; 
            do
            {
                Console.WriteLine("How many years would you like to predict in the future?");
                var yearsInput = Console.ReadLine();

                isValidYearsInput = int.TryParse(yearsInput, out yearCount);
                if (isValidYearsInput == false)
                {
                    Console.WriteLine($"{yearsInput} is not a number. Please enter a whole number");
                }
            } while (isValidYearsInput == false);


            var isValidSavingsPerMonthInput = false;
            do
            {
                Console.WriteLine("How much money are you saving per month? e.g. 2500.00");
                var savingsPerMonthInput = Console.ReadLine();

                isValidSavingsPerMonthInput = decimal.TryParse(savingsPerMonthInput, out savingsPerMonth);
                if (isValidSavingsPerMonthInput == false)
                {
                    Console.WriteLine($"{savingsPerMonthInput} is not a decimal. Please enter a decimal number");
                }

            } while (isValidSavingsPerMonthInput == false);



            var forecastYears = new List<ForecastYear>();
            for (int i = 0; i < yearCount; i++)
            {
                var savingsPerYear = (decimal)savingsPerMonth * 12;

                var forecastYear = new ForecastYear();
                forecastYear.Cash = savingsPerYear;

                if (i == 0)
                {
                    //do nothing; 
                }
                else
                {
                    forecastYear.Cash += forecastYears[i-1].Cash;
                }

                forecastYears.Add(forecastYear);
            }


            foreach (var (year, yearNum) in forecastYears.Select((value, index) => (value, index+1)))
            {
                //var yearNum = year.i + 1
                Console.WriteLine($"Year {yearNum} || Current Cash: {year.Cash}");
            }
        }


    }
    

    public class ForecastYear
    {
        public decimal Cash { get; set; }
    }

    public enum FYFI_ACTION 
    {
        New_Forecast = 1
    }

}
