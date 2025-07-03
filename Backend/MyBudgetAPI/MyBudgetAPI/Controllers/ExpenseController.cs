using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyBudget.BLL.DTOs;
using MyBudget.BLL.Interface;
using MyBudgetAPI.Models;
using System.Security.Claims;

namespace MyBudgetAPI.Controllers
{
    [Authorize] 
    [Route("api/[controller]")]
    [ApiController]
    public class ExpensesController : ControllerBase
    {
        private readonly IExpenseRepository _expenseRepo;

        public ExpensesController(IExpenseRepository expenseRepo)
        {
            _expenseRepo = expenseRepo;
        }

        // this help us to get user saftly 
        private string GetCurrentUserId()
        {
            return User.FindFirstValue(ClaimTypes.NameIdentifier);
        }

        // GET: api/Expenses
        [HttpGet]
        public async Task<IActionResult> GetMyExpenses()
        {
            var userId = GetCurrentUserId();
            var expenses = await _expenseRepo.GetExpensesByUserIdAsync(userId);
            return Ok(expenses);
        }

        // GET: api/Expenses/{id}
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(string id) 
        {
            var expense = await _expenseRepo.GetByIdAsync(id);

            if (expense == null || expense.UserId != GetCurrentUserId())
            {
                return NotFound("Expense not found or you do not have permission.");
            }
            return Ok(expense);
        }

        // POST: api/Expenses

        //add new 
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] ExpenseDto model)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var userId = GetCurrentUserId();
            var expense = new Expense
            {
                Title = model.Title,
                Amount = model.Amount,
                Category = model.Category,
                DateIncurred = model.DateIncurred,
                Note = model.Note,
                UserId = userId 
            };

            await _expenseRepo.AddAsync(expense);
            return CreatedAtAction(nameof(GetById), new { id = expense.Id }, expense);
        }

        // PUT: api/Expenses/{id}
        //update if its created by user
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(string id, [FromBody] ExpenseDto model)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var expenseToUpdate = await _expenseRepo.GetByIdAsync(id);

            if (expenseToUpdate == null || expenseToUpdate.UserId != GetCurrentUserId())
            {
                return NotFound("Expense not found or you do not have permission to update it.");
            }

            expenseToUpdate.Title = model.Title;
            expenseToUpdate.Amount = model.Amount;
            expenseToUpdate.Category = model.Category;
            expenseToUpdate.DateIncurred = model.DateIncurred;
            expenseToUpdate.Note = model.Note;

            _expenseRepo.Update(expenseToUpdate);

            return NoContent();
        }

        // DELETE: api/Expenses/{id}
        // delete if its created by user
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            var expenseToDelete = await _expenseRepo.GetByIdAsync(id);

            if (expenseToDelete == null || expenseToDelete.UserId != GetCurrentUserId())
            {
                return NotFound("Expense not found or you do not have permission to delete it.");
            }

            _expenseRepo.Delete(expenseToDelete);

            return NoContent();
        }
    }

}