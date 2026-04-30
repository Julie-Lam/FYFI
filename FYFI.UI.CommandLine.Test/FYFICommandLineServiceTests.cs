using FYFI.Core.Enums;
using FYFI.Repository.InMemory.Model;
using FYFI.UI.CommandLine.Service;
using NSubstitute;

namespace FYFI.UI.CommandLine.Test
{

    [TestFixture]
    public class FYFICommandLineServiceTests
    {
        [SetUp]
        public void Setup()
        {
        }



        [Test]
        public void Should_HandleNewOutlook_When()
        {

            var fyfiCommandLineService = new FYFICommandLineService();

            //Arrange
            var mockUIService = Substitute.For<IUserInterfaceService>();
            mockUIService.GetDurationYearsInput(default, default).ReturnsForAnyArgs(3);
            mockUIService.GetSavingsPerMonth(default, default).ReturnsForAnyArgs(1000);
            mockUIService.GetShouldSaveForecastInput(default, default).ReturnsForAnyArgs(false); 

            var mockRepoService = Substitute.For<IFYFIRepositoryService>();

            fyfiCommandLineService._consoleUserInterfaceService = mockUIService;
            fyfiCommandLineService._repository = mockRepoService;


            FiOutlook actualFiOutlook = null;


            // using When...Do to capture args
            mockUIService
              .When(mock => mock.PrintFinancialOutlookDetails(Arg.Any<FiOutlook>()))
              .Do(callInfo => actualFiOutlook = callInfo.Arg<FiOutlook>());

            //Act
            fyfiCommandLineService.HandleNewOutlook();


            //Assert

            Assert.That(actualFiOutlook.FiOutlookYears, Is.Not.Null);
            Assert.That(actualFiOutlook.FiOutlookYears.Count, Is.EqualTo(3));

            //1st outlook year
            Assert.That(actualFiOutlook.FiOutlookYears[0].YearDate.Year, Is.EqualTo(DateTime.Now.AddYears(1).Year));
            Assert.That(actualFiOutlook.FiOutlookYears[0].Cash, Is.EqualTo(12000));
            Assert.That(actualFiOutlook.FiOutlookYears[0].SavingsYearly, Is.EqualTo(12000));

            //2st outlook year
            Assert.That(actualFiOutlook.FiOutlookYears[1].YearDate.Year, Is.EqualTo(DateTime.Now.AddYears(2).Year));
            Assert.That(actualFiOutlook.FiOutlookYears[1].Cash, Is.EqualTo(24000));
            Assert.That(actualFiOutlook.FiOutlookYears[1].SavingsYearly, Is.EqualTo(12000));

            //1st outlook year
            Assert.That(actualFiOutlook.FiOutlookYears[2].YearDate.Year, Is.EqualTo(DateTime.Now.AddYears(3).Year));
            Assert.That(actualFiOutlook.FiOutlookYears[2].Cash, Is.EqualTo(36000));
            Assert.That(actualFiOutlook.FiOutlookYears[2].SavingsYearly, Is.EqualTo(12000));
        }
    }
}