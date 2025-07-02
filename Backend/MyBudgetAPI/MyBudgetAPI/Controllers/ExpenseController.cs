using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyBudget.BLL.Interface;
using MyBudgetAPI.Models;

namespace MyBudgetAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExpenseController : ControllerBase
    {
        // This holds a reference to the repository that handles expense data.
        private readonly IGenericRepository<Expense> _expenseRepository;

        // The repository is injected here when the controller is created.
        public ExpenseController(IGenericRepository<Expense> expenseRepository)
        {
            _expenseRepository = expenseRepository;
        }

        // GET: api/Expense
        // Gets a list of all expense records.
        [HttpGet]
        public async Task<IActionResult> GetExpenses()
        {
            var expenses = await _expenseRepository.GetAllAsync();
            return Ok(expenses);
        }

        // GET: api/Expense/{id}
        // Gets a single expense record by its unique ID.
        [HttpGet("{id}")]
        public async Task<IActionResult> GetExpense(string id)
        {
            var expense = await _expenseRepository.GetByIdAsync(id);
            if (expense == null)
            {
                return NotFound();
            }
            return Ok(expense);
        }

        // POST: api/Expense
        // Creates a new expense record from the data in the request body.
        [HttpPost]
        public async Task<IActionResult> CreateExpense([FromBody] Expense expense)
        {
            await _expenseRepository.AddAsync(expense);
            return CreatedAtAction(nameof(GetExpense), new { id = expense.id }, expense);
        }

        // PUT: api/Expense/{id}
        // Updates an existing expense record.
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateExpense(string id, [FromBody] Expense expense)
        {
            if (id != expense.id)
            {
                return BadRequest("ID in URL does not match ID in body.");
            }
            _expenseRepository.Update(expense);
            return NoContent();
        }

        // DELETE: api/Expense/{id}
        // Deletes an expense record by its ID.
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteExpense(string id)
        {
            var expenseToDelete = await _expenseRepository.GetByIdAsync(id);
            if (expenseToDelete == null)
            {
                return NotFound();
            }
            _expenseRepository.Delete(expenseToDelete);
            return NoContent();
        }
    }
}
