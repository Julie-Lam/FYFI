using FYFI.Repository.InMemory.Model;

namespace FYFI.UI.CommandLine.Service
{
    public interface IFYFIRepositoryService
    {
        List<FiOutlook> GetAllFinancialOutlooks();
        FiOutlook GetFinancialOutlookById(int id);
        void UpsertFinancialOutlook(FiOutlook financialOutlook);
    }
}