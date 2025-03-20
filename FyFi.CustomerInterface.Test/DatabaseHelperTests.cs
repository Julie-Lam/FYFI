using FyFi.CustomerInterface.Classes;
using FyFi.CustomerInterface.DatabaseLayer;

namespace FyFi.CustomerInterface.Test
{
    public class DatabaseHelperTests
    {

        private readonly DatabaseHelper _DbHelper = new DatabaseHelper(); 
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Test_GetMonthlyCaptureById()
        {


            var monthlyCapture = _DbHelper.GetMonthlyCaptureById(1);

            Assert.IsTrue(monthlyCapture.MonthlyCaptureId == 1);
            Assert.IsTrue(monthlyCapture.MonthlyCaptureDate.HasValue); 
        }

        [Test]
        public void Test_GetMonthlyCaptureItemById()
        {

            var monthlyCaptureItem = _DbHelper.GetMonthlyCaptureItemById(1);

            Assert.IsTrue(monthlyCaptureItem.MonthlyCaptureItemId == 1);
            Assert.IsTrue(monthlyCaptureItem.MonthlyCaptureId == 1);
            Assert.IsTrue(monthlyCaptureItem.ItemName == "ING Savings"); 
            Assert.IsTrue(monthlyCaptureItem.ItemAmount == 5000);
        }

        [Test]
        public void Test_SaveMonthlyCapture() 
        {
            var newMonthlyCapture = new MonthlyCaptureCls()
            {
                MonthlyCaptureDate = DateTime.Now,
            };

            var rows = _DbHelper.SaveMonthlyCapture(newMonthlyCapture);

            Assert.IsTrue(rows >= 0); 
            
        }

    }
}