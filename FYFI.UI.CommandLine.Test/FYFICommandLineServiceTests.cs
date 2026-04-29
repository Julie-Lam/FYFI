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


            //Act
            fyfiCommandLineService.HandleNewOutlook();


            //Assert
            var expectedOutlook = new FiOutlook()
            {
                FiOutlookYears = new List<FiOutlookYear>() 
                { 
                    new FiOutlookYear() {YearDate = DateTime.Now.AddYears(1), Cash = 12000, SavingsYearly = 12000}, 
                    new FiOutlookYear() {YearDate = DateTime.Now.AddYears(2), Cash = 24000, SavingsYearly = 12000},            
                    new FiOutlookYear() {YearDate = DateTime.Now.AddYears(3), Cash = 36000, SavingsYearly = 12000}  
                }
            };

            mockUIService.Received().PrintFinancialOutlookDetails(expectedOutlook); 
        }
    }
}