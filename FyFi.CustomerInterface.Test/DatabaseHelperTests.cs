using FyFi.CustomerInterface.DatabaseLayer;

namespace FyFi.CustomerInterface.Test
{
    public class DatabaseHelperTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Test_GetMonthlyCaptureById()
        {

            var dbHelper = new DatabaseHelper(); 
            var monthlyCapture = dbHelper.GetMonthlyCaptureById(1);

            Assert.IsTrue(monthlyCapture.MonthlyCaptureId == 1);
            Assert.IsTrue(monthlyCapture.MonthlyCaptureDate.HasValue); 
        }

        [Test]
        public void Test_GetMonthlyCaptureItemById()
        {

            var dbHelper = new DatabaseHelper();
            var monthlyCaptureItem = dbHelper.GetMonthlyCaptureItemById(1);

            Assert.IsTrue(monthlyCaptureItem.MonthlyCaptureItemId == 1);
            Assert.IsTrue(monthlyCaptureItem.MonthlyCaptureId == 1);
            Assert.IsTrue(monthlyCaptureItem.ItemName == "ING Savings"); 
            Assert.IsTrue(monthlyCaptureItem.ItemAmount == 5000);
        }

    }
}