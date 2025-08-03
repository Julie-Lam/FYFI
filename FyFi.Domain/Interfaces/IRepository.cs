using FyFi.Domain.Classes;

namespace FyFi.Domain.Interfaces
{
    public interface IRepository
    {
        int DeleteMonthlyCaptureItemById(int monthlyCaptureItemId);
        MonthlyCapture GetMonthlyCaptureById(int monthlyCaptureId);
        MonthlyCaptureItem GetMonthlyCaptureItemById(int monthlyCaptureItemId);
        int SaveMonthlyCapture(ref MonthlyCapture monthlyCapture);
        int SaveMonthlyCaptureItem(MonthlyCaptureItem captureItem, int monthlyCaptureId);
        int UpdateMonthlyCapture(MonthlyCapture monthlyCapture);
        int UpdateMonthlyCaptureItem(MonthlyCaptureItem captureItem);
    }
}