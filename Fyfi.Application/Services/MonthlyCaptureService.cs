using FyFi.Domain.Classes;
using FyFi.Domain.Interfaces;

namespace Fyfi.Application.Services
{
    public class MonthlyCaptureService : IMonthlyCaptureService
    {

        private IDatabaseHelper _dbHelper; 

        public MonthlyCaptureService(IDatabaseHelper dbHelper) 
        {
            _dbHelper = dbHelper; 
        }
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

        public void DeleteMonthlyCaptureItem(int monthlyCaptureItemId)
        {
            _dbHelper.DeleteMonthlyCaptureItemById(monthlyCaptureItemId);
        }

    }
}
