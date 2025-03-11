namespace FyFi.CustomerInterface.Classes
{

    public class FinancialForcast
    {
        public decimal InitialSavings { get; set; }
        public decimal SavingsRateDollar { get; set; }

        public List<FinancialForcastYear> FinancialForcastYears { get; set; } = new List<FinancialForcastYear>();

    }
    public class FinancialForcastYear
    {
        public int Year { get; set; }
        public decimal SavingsAccrued { get; set; }
    }
}
