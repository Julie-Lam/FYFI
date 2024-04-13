using FyFi.Core;
using FyFi.Domain;

namespace FyFi.Infrastructure
{
    public class ExpenseRepository : IExpenseRepository
    {
        public async Task DeleteByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<Expense>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<Expense> GetByIdAsync(int id)
        {
            //TODO: get from EFCore implementation
            var expense = new Expense();

            return expense; 
        }

        public async Task<Expense> UpdateByIdAsync(int id)
        {
            throw new NotImplementedException();
        }
    }
}
