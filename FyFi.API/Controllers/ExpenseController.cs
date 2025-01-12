using FyFi.Core;
using FyFi.Domain;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FyFi.API.Controllers
{
    public class ExpenseController : Controller
    {
        readonly IExpenseRepository _expenseRepository;

        public ExpenseController(IExpenseRepository expenseRepository)
        {
            _expenseRepository = expenseRepository;
            
        }
        /// <summary>
        /// Return all Expenses
        /// </summary>
        /// <returns></returns>
        [HttpGet("Expense")]
        public ActionResult Index() //GET: Expense/
        {

            throw new InvalidOperationException();
        }

        /// <summary>
        /// Return Expense with the given id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("Expense/{id}")]
        public async Task<ActionResult<Expense>> Index(int id) //GET: Expense/{id}
        {
            var expense = await _expenseRepository.GetByIdAsync(id);
            return Ok(expense);
        }


        // POST: ExpenseController/Create
        [HttpPost("Expense")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(Expense expense)
        {
            var result = await _expenseRepository.CreateAsync(expense);
            return Ok(result); 
        }



        // PUT: ExpenseController/Update/5
        [HttpPut("Expense/{id}")]
        [ValidateAntiForgeryToken]
        public ActionResult Update(int id, IFormCollection collection)
        {
            throw new InvalidOperationException();
        }



        // POST: ExpenseController/Delete/5
        [HttpDelete("Expense/{id}")]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            throw new InvalidOperationException();
        }
    }
}
