using FyFi.Domain.Classes;

namespace FyFi.Domain.Interfaces
{
    public interface IDatabaseHelper
    {
        int DeleteMonthlyCaptureItemById(int monthlyCaptureItemId);
        MonthlyCaptureCls GetMonthlyCaptureById(int monthlyCaptureId);
        MonthlyCaptureItem GetMonthlyCaptureItemById(int monthlyCaptureItemId);
        int SaveMonthlyCapture(ref MonthlyCaptureCls monthlyCapture);
        int SaveMonthlyCaptureItem(MonthlyCaptureItem captureItem, int monthlyCaptureId);
        int UpdateMonthlyCapture(MonthlyCaptureCls monthlyCapture);
        int UpdateMonthlyCaptureItem(MonthlyCaptureItem captureItem);
    }
}