using FyFi.Domain.Classes;

namespace FyFi.Domain.Interfaces
{
    public interface IMonthlyCaptureService
    {
        void DeleteMonthlyCaptureItem(int monthlyCaptureItemId);
        MonthlyCapture LoadMonthlyCaptureById(int monthlyCaptureId);
        void SaveUpdateMonthlyCapture(MonthlyCapture monthlyCapture);
    }
}