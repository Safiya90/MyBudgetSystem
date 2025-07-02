using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyBudget.BLL.Interface;
using MyBudgetAPI.Models;

namespace MyBudgetAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TaxRecordController : ControllerBase
    {
        // This holds a reference to the repository that handles tax record data.
        private readonly IGenericRepository<TaxRecord> _taxRecordRepository;

        // The repository is injected here when the controller is created.
        public TaxRecordController(IGenericRepository<TaxRecord> taxRecordRepository)
        {
            _taxRecordRepository = taxRecordRepository;
        }

        // GET: api/TaxRecord
        // Gets a list of all tax records.
        [HttpGet]
        public async Task<IActionResult> GetTaxRecords()
        {
            var taxRecords = await _taxRecordRepository.GetAllAsync();
            return Ok(taxRecords);
        }

        // GET: api/TaxRecord/{id}
        // Gets a single tax record by its unique ID.
        [HttpGet("{id}")]
        public async Task<IActionResult> GetTaxRecord(string id)
        {
            var taxRecord = await _taxRecordRepository.GetByIdAsync(id);
            if (taxRecord == null)
            {
                return NotFound();
            }
            return Ok(taxRecord);
        }

        // POST: api/TaxRecord
        // Creates a new tax record from the data in the request body.
        [HttpPost]
        public async Task<IActionResult> CreateTaxRecord([FromBody] TaxRecord taxRecord)
        {
            await _taxRecordRepository.AddAsync(taxRecord);
            return CreatedAtAction(nameof(GetTaxRecord), new { id = taxRecord.id }, taxRecord);
        }

        // PUT: api/TaxRecord/{id}
        // Updates an existing tax record.
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateTaxRecord(string id, [FromBody] TaxRecord taxRecord)
        {
            if (id != taxRecord.id)
            {
                return BadRequest("ID in URL does not match ID in body.");
            }
            _taxRecordRepository.Update(taxRecord);
            return NoContent();
        }

        // DELETE: api/TaxRecord/{id}
        // Deletes a tax record by its ID.
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTaxRecord(string id)
        {
            var taxRecordToDelete = await _taxRecordRepository.GetByIdAsync(id);
            if (taxRecordToDelete == null)
            {
                return NotFound();
            }
            _taxRecordRepository.Delete(taxRecordToDelete);
            return NoContent();
        }
    }
}