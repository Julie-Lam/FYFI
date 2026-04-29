using FyFi.UI.CommandLine;
using FYFI.Repository.InMemory.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FYFI.UI.CommandLine.Service
{
    public class FYFIRepositoryService : IFYFIRepositoryService
    {
        private FYFIDbContext _FYFIDbContext { get; set; } = new FYFIDbContext();
        public void UpsertFinancialOutlook(FiOutlook financialOutlook)
        {
            var fiOutlook = _FYFIDbContext.FiOutlooks.FirstOrDefault(o => o.FiOutlookId == financialOutlook.FiOutlookId);

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
            var financialOutlooks = _FYFIDbContext.FiOutlooks.Include(o => o.FiOutlookYears).ToList();
            return financialOutlooks;
        }

        public FiOutlook GetFinancialOutlookById(int id)
        {
            var financialOutlook = _FYFIDbContext.FiOutlooks.Include(o => o.FiOutlookYears).Where(o => o.FiOutlookId == id).FirstOrDefault();
            return financialOutlook;
        }

    }
}
