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
            _FYFIDbContext.FiOutlooks.Add(financialOutlook);
            _FYFIDbContext.SaveChanges(); 
        }
    }
}
