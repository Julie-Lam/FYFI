using FyFi.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FyFi.Core
{
    public interface IExpenseRepository
    {
        Task DeleteByIdAsync(int id);
        Task<List<Expense>> GetAllAsync();
        Task<Expense> GetByIdAsync(int id);
        Task<Expense> UpdateByIdAsync(int id);
    }
}
