using FYFI.Repository.InMemory.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FYFI.Core
{
    public class FYFIBLLService
    {
        public FiOutlook GenerateFinancialOutlook(int durationInYears, decimal savingsPerMonth)
        {
            var financialOutlook = new FiOutlook();
            financialOutlook.FiOutlookYears = new List<FiOutlookYear>();

            for (int i = 0; i < durationInYears; i++)
            {
                var savingsPerYear = (decimal)savingsPerMonth * 12;

                var fiOutlookYear = CalculateFinancialOutlookYear(financialOutlook, savingsPerYear, i);

                financialOutlook.FiOutlookYears.Add(fiOutlookYear);
            }

            return financialOutlook;
        }

        public FiOutlookYear CalculateFinancialOutlookYear(FiOutlook financialOutlook, decimal savingsPerYear, int i)
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
    }
}
