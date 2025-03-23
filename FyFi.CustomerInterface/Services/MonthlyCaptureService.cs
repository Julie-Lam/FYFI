using FyFi.CustomerInterface.Classes;
using FyFi.CustomerInterface.DatabaseLayer;

namespace FyFi.CustomerInterface.Services
{
    public class MonthlyCaptureService : IMonthlyCaptureService
    {

        private DatabaseHelper _dbHelper = new DatabaseHelper();

        public MonthlyCaptureCls LoadMonthlyCaptureById(int monthlyCaptureId) 
        {
            return _dbHelper.GetMonthlyCaptureById(monthlyCaptureId);
        }
        

        public void SaveUpdateMonthlyCapture(MonthlyCaptureCls monthlyCapture) 
        {
            if (monthlyCapture.MonthlyCaptureId == 0)
            {
                _dbHelper.SaveMonthlyCapture(ref monthlyCapture);
            }
            else 
            {
                _dbHelper.UpdateMonthlyCapture(monthlyCapture); 
            }
        }

    }
}
