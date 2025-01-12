using FyFi.Core;
using FyFi.Infrastructure;
using NSubstitute;

namespace FyFi.Test
{
    public class Tests
    {

        private IExpenseRepository _ExpenseRepository { get; set; }
        [SetUp]
        public void Setup()
        {

        }

        //[Test]
        //public async Task Get_All_Expenses_Success()
        //{

        //    //Arrange
        //    _ExpenseRepository = new ExpenseRepository(); 
        //    //mock db repo


        //    //Act
        //    var expenses = await _ExpenseRepository.GetAllAsync(); 


        //    //Assert 
        //    Assert.True(expenses.Any());
        //}

        [Test]
        public async Task Get_Expense_By_Id_Success()
        {
            //Arrange 
            _ExpenseRepository = new ExpenseRepository();

            //Act
            var expense = await _ExpenseRepository.GetByIdAsync(Arg.Any<int>());

            //Assert
            Assert.True(expense != null); 
        }

        [Test]
        public void Create_An_Expense_Success()
        {
            //Arrange 

            //Act

            //Assert
            Assert.Fail(); 
        }

        [Test]
        public void Update_An_Expense_Success()
        {
            //Arrange 

            //Act

            //Assert
            Assert.Fail();
        }

        [Test]
        public void Delete_An_Expense_Success()
        {
            //Arrange 

            //Act

            //Assert
            Assert.Fail();
        }
    }
}