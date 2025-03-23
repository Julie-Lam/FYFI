using FyFi.Domain.Classes;

namespace FyFi.Domain.Interfaces
{
    public interface IMonthlyCaptureService
    {
        void DeleteMonthlyCaptureItem(int monthlyCaptureItemId);
        MonthlyCaptureCls LoadMonthlyCaptureById(int monthlyCaptureId);
        void SaveUpdateMonthlyCapture(MonthlyCaptureCls monthlyCapture);
    }
}