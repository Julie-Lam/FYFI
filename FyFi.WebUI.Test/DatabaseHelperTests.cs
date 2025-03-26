using FyFi.Domain.Classes;
using FyFi.Infrastructure.DatabaseLayer;

namespace FyFi.WebUI.Test
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

            Assert.IsTrue(monthlyCapture.CaptureItems.Count >= 0);
        }

        [Test]
        public void Test_GetMonthlyCaptureItemById()
        {

            var monthlyCaptureItem = _DbHelper.GetMonthlyCaptureItemById(1);

            Assert.IsTrue(monthlyCaptureItem.MonthlyCaptureItemId == 1);
            Assert.IsTrue(monthlyCaptureItem.MonthlyCaptureId == 1);
            Assert.IsTrue(!string.IsNullOrWhiteSpace(monthlyCaptureItem.ItemName));
            Assert.IsTrue(monthlyCaptureItem.ItemAmount > 0);
        }

        [Test]
        public void Test_SaveMonthlyCapture()
        {
            var newMonthlyCapture = new MonthlyCaptureCls()
            {
                MonthlyCaptureDate = DateTime.Now,
            };

            var rows = _DbHelper.SaveMonthlyCapture(ref newMonthlyCapture);

            Assert.IsTrue(newMonthlyCapture.MonthlyCaptureId != 0);
            Assert.IsTrue(rows == 1);

        }

        [Test]
        public void Test_SaveMonthlyCapture_With_New_CaptureItem()
        {
            Random rnd = new Random();
            var newMonthlyCapture = new MonthlyCaptureCls()
            {
                MonthlyCaptureDate = DateTime.Now,
                CaptureItems = new List<MonthlyCaptureItem>()
                {
                    new MonthlyCaptureItem()
                    {
                        ItemName = "Test Item Name",
                        ItemAmount = rnd.Next(10000)
                    }

                }
            };

            var rows = _DbHelper.SaveMonthlyCapture(ref newMonthlyCapture);
            Assert.IsTrue(newMonthlyCapture.MonthlyCaptureId != 0);
            Assert.IsTrue(rows == 2);

        }

        [Test]
        public void Test_UpdateMonthlyCapture_With_New_CaptureItem()
        {
            Random rnd = new Random();

            var monthlyCapture = _DbHelper.GetMonthlyCaptureById(1);
            var captureItemCount = monthlyCapture.CaptureItems.Count();

            monthlyCapture.CaptureItems.Add(new MonthlyCaptureItem()
            {
                ItemName = "Test Item Name",
                ItemAmount = rnd.Next(10000)
            });

            var rows = _DbHelper.UpdateMonthlyCapture(monthlyCapture);
            Assert.IsTrue(monthlyCapture.MonthlyCaptureId != 0);
            Assert.IsTrue(monthlyCapture.CaptureItems.Count() == captureItemCount + 1);

        }

        [Test]
        public void Test_UpdateMonthlyCapture_With_Update_CaptureItem()
        {
            Random rnd = new Random();

            var monthlyCapture = _DbHelper.GetMonthlyCaptureById(1);
            var captureItemCount = monthlyCapture.CaptureItems.Count();

            monthlyCapture.CaptureItems.First().ItemName = $"Test Item Name - {rnd.Next()}";
            monthlyCapture.CaptureItems.First().ItemAmount = rnd.Next(10000);


            var rows = _DbHelper.UpdateMonthlyCapture(monthlyCapture);
            Assert.IsTrue(monthlyCapture.MonthlyCaptureId != 0);

            Assert.IsTrue(monthlyCapture.CaptureItems.Count() == captureItemCount);

        }

        [Test]
        public void Test_DeleteMonthlyCaptureItemById()
        {

            Test_GetMonthlyCaptureById();

            var monthlyCapture = _DbHelper.GetMonthlyCaptureById(1);
            var lastCaptureItemId = monthlyCapture.CaptureItems.Last().MonthlyCaptureItemId;
            var rows = _DbHelper.DeleteMonthlyCaptureItemById(lastCaptureItemId);

            Assert.IsTrue(rows == 1);

            var monthlyCaptureItem = _DbHelper.GetMonthlyCaptureItemById(lastCaptureItemId);
            Assert.IsTrue(monthlyCaptureItem == null);

        }


    }
}