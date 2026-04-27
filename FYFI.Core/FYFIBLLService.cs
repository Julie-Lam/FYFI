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
            financialOutlook.FiOutlookYears = CalculateFinancialOutlookYears(durationInYears, savingsPerMonth); 

            return financialOutlook;
        }

        //public List<FiOutlookYear> CalculateFinancialOutlookYears(int durationInYears, decimal savingsPerMonth, FiOutlook financialOutlook)
        //{
        //    var fiOutlookYears = new List<FiOutlookYear>();

        //    for (int i = 0; i < durationInYears; i++)
        //    {
        //        var savingsPerYear = (decimal)savingsPerMonth * 12;

        //        var fiOutlookYear = CalculateFinancialOutlookYear(financialOutlook, savingsPerYear, i);

        //        fiOutlookYears.Add(fiOutlookYear);
        //    }

        //    return fiOutlookYears; 
        //}

        //public FiOutlookYear CalculateFinancialOutlookYear(FiOutlook financialOutlook, decimal savingsPerYear, int i)
        //{
        //    var financialOutlookYear = new FiOutlookYear();
        //    financialOutlookYear.YearDate = DateTime.Now.AddYears(i + 1);
        //    financialOutlookYear.SavingsYearly = savingsPerYear;
        //    //financialOutlookYear.Cash = savingsPerYear;

        //    if (i == 0)
        //    {
        //        financialOutlookYear.Cash = savingsPerYear;
        //        return financialOutlookYear;
        //    }


        //    financialOutlookYear.Cash = financialOutlook.FiOutlookYears[i - 1].Cash;
        //    financialOutlookYear.Cash += savingsPerYear;

        //    return financialOutlookYear;
        //}


        public List<FiOutlookYear> CalculateFinancialOutlookYears(int durationInYears, decimal savingsPerMonth)
        {
            var fiOutlookYears = new List<FiOutlookYear>();

            for (int i = 0; i < durationInYears; i++)
            {
                var yearNum = i + 1;
                var savingsPerYear = (decimal)savingsPerMonth * 12;


                FiOutlookYear fiOutlookYear;
                if (i == 0)
                {
                    fiOutlookYear = CalculateFinancialOutlookYear(savingsPerYear, yearNum);
                }
                else
                {
                    decimal prevOutlookYearCash = fiOutlookYears[i - 1].Cash;
                    fiOutlookYear = CalculateFinancialOutlookYear(savingsPerYear, yearNum, prevOutlookYearCash);
                }


                fiOutlookYears.Add(fiOutlookYear);
            }

            return fiOutlookYears;
        }
        public FiOutlookYear CalculateFinancialOutlookYear(decimal savingsPerYear, int yearNum, decimal? prevOutlookYearCash = null)
        {
            var financialOutlookYear = new FiOutlookYear();
            financialOutlookYear.YearDate = DateTime.Now.AddYears(yearNum);
            financialOutlookYear.SavingsYearly = savingsPerYear;
            //financialOutlookYear.Cash = savingsPerYear;

            var isFirstFiOutlookYear = prevOutlookYearCash is null;
            if (isFirstFiOutlookYear)
            {
                financialOutlookYear.Cash = savingsPerYear;
            }
            else 
            {
                financialOutlookYear.Cash = prevOutlookYearCash.HasValue ? prevOutlookYearCash.Value : 0;
                financialOutlookYear.Cash += savingsPerYear;

            }


            return financialOutlookYear;
        }


    }
}
