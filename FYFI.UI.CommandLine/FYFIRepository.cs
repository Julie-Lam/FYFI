using FyFi.UI.CommandLine;
using FYFI.Repository.InMemory.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FYFI.UI.CommandLine
{
    public class FYFIRepository
    {
        private FYFIDbContext _FYFIDbContext { get; set; } = new FYFIDbContext(); 
        public void UpsertFinancialOutlook(FiOutlook financialOutlook) 
        {
            var fiOutlook = _FYFIDbContext.FiOutlooks.First(o => o.FiOutlookId == financialOutlook.FiOutlookId); 

            if (fiOutlook is null) 
            {
                _FYFIDbContext.FiOutlooks.Add(financialOutlook);
            }

            else
            {
                fiOutlook = financialOutlook; 
            }

            _FYFIDbContext.SaveChanges(); 
        }

        public List<FiOutlook> GetAllFinancialOutlooks()
        {
            var financialOutlooks = _FYFIDbContext.FiOutlooks.ToList();
            return financialOutlooks; 
        }

        public FiOutlook GetFinancialOutlookById(int id)
        {
            var financialOutlook = _FYFIDbContext.FiOutlooks.Find(id); 
            return financialOutlook;
        }

    }
}
