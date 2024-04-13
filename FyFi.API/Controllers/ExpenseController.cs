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
        [HttpGet]
        public ActionResult Index() //GET: Expense/
        {

            throw new NotImplementedException();



        }

        /// <summary>
        /// Return Expense with the given id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        public async Task<ActionResult<Expense>> Index(int id) //GET: Expense/{id}
        {
            var expense = await _expenseRepository.GetByIdAsync(id);
            return Ok(expense);
        }


        // POST: ExpenseController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            throw new NotImplementedException();
        }



        // PUT: ExpenseController/Update/5
        [HttpPut]
        [ValidateAntiForgeryToken]
        public ActionResult Update(int id, IFormCollection collection)
        {
            throw new NotImplementedException();
        }



        // POST: ExpenseController/Delete/5
        [HttpDelete]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            throw new NotImplementedException();
        }
    }
}
