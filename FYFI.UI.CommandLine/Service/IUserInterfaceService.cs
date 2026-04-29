using FYFI.Core.Enums;
using FYFI.Repository.InMemory.Model;

namespace FYFI.UI.CommandLine.Service
{
    public interface IUserInterfaceService
    {
        FYFI_ACTION GetArgInput(string initialPrompt, string appendedErrorPrompt = null);
        int GetDurationYearsInput(string initialPrompt, string appendedErrorPrompt = null);
        EDIT_OUTLOOK_OPTIONS GetEditOutlookOptionInput(string initialPrompt, string appendedErrorPrompt = null);
        int GetFiOutlookDurationYearsInput(string initialPrompt, string appendedErrorPrompt = null);
        int GetFiOutlookId(string initialPrompt, string appendedErrorPrompt = null);
        string GetFiOutlookNameInput(string initialPrompt, string appendedErrorPrompt = null);
        decimal GetSavingsPerMonth(string initialPrompt, string appendedErrorPrompt = null);
        bool GetShouldSaveForecastInput(string initialPrompt, string appendedErrorPrompt = null);
        void PrintFinancialOutlookDetails(FiOutlook financialOutlook);
        void PrintFinancialOutlooks(List<FiOutlook> fiOutlooks);
    }
}