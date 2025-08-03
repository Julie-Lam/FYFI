using FyFi.Domain.Classes;
using FyFi.Domain.Interfaces;

namespace Fyfi.Application.Services
{
    public class MonthlyCaptureService : IMonthlyCaptureService
    {

        private IRepository _repository; 

        public MonthlyCaptureService(IRepository repository) 
        {
            _repository = repository; 
        }
        public MonthlyCapture LoadMonthlyCaptureById(int monthlyCaptureId)
        {
            return _repository.GetMonthlyCaptureById(monthlyCaptureId);
        }


        public void SaveUpdateMonthlyCapture(MonthlyCapture monthlyCapture)
        {
            if (monthlyCapture.MonthlyCaptureId == 0)
            {
                _repository.SaveMonthlyCapture(ref monthlyCapture);
            }
            else
            {
                _repository.UpdateMonthlyCapture(monthlyCapture);
            }
        }

        public void DeleteMonthlyCaptureItem(int monthlyCaptureItemId)
        {
            _repository.DeleteMonthlyCaptureItemById(monthlyCaptureItemId);
        }

    }
}
