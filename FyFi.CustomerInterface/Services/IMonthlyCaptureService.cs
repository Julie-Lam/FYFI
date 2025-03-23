using FyFi.CustomerInterface.Classes;

namespace FyFi.CustomerInterface.Services
{
    public interface IMonthlyCaptureService
    {
        MonthlyCaptureCls LoadMonthlyCaptureById(int monthlyCaptureId);
        void SaveUpdateMonthlyCapture(MonthlyCaptureCls monthlyCapture);
    }
}