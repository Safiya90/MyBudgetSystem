using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyBudget.BLL.Interface;
using MyBudgetAPI.Controllers;
using MyBudgetAPI.Models;

namespace MyBudgetAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IncomeController : ControllerBase
    {
        private readonly IGenericRepository<Income> _incomeRepository;

        // The repository is injected here when the controller is created.
        public IncomeController(IGenericRepository<Income> incomeRepository)
        {
            _incomeRepository = incomeRepository;
        }

        // GET: api/Income
        // Retrieves all income records.
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Income>>> GetIncomes()
        {
            var incomes = await _incomeRepository.GetAllAsync();
            return Ok(incomes);
        }

        // GET: api/Income/{id}
        // Gets a single income record by its unique ID.
        [HttpGet("{id}")]
        public async Task<IActionResult> GetIncome(string id)
        {
            // Find the income record with the matching ID.
            var income = await _incomeRepository.GetByIdAsync(id);
            // If no record is found, return a 404 Not Found error.
            if (income == null)
            {
                return NotFound();
            }
            // If found, return the record with a 200 OK status.
            return Ok(income);
        }

        // POST: api/Income
        // Creates a new income record from the data in the request body.
        [HttpPost]
        public async Task<IActionResult> CreateIncome([FromBody] Income income)
        {
            // Add the new income record to the database.
            await _incomeRepository.AddAsync(income);
            // Return a 201 Created status, along with the new record and a link to it.
            return CreatedAtAction(nameof(GetIncome), new { id = income.id }, income);
        }

        // PUT: api/Income/{id}
        // Updates an existing income record.
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateIncome(string id, [FromBody] Income income)
        {
            // Check if the ID in the URL matches the ID in the request body.
            if (id != income.id)
            {
                return BadRequest("ID in URL does not match ID in body.");
            }
            // Tell the repository to update the record.
            _incomeRepository.Update(income);
            // Return a 204 No Content status to show it was successful.
            return NoContent();
        }

        // DELETE: api/Income/{id}
        // Deletes an income record by its ID.
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteIncome(string id)
        {
            // Find the record to be deleted first.
            var incomeToDelete = await _incomeRepository.GetByIdAsync(id);
            // If it doesn't exist, return a 404 Not Found error.
            if (incomeToDelete == null)
            {
                return NotFound();
            }
            // Tell the repository to delete the record.
            _incomeRepository.Delete(incomeToDelete);
            // Return a 204 No Content status to show it was successful.
            return NoContent();
        }
    }
}