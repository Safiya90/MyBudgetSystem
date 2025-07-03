using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyBudget.BLL.DTOs;
using MyBudget.BLL.Interface;
using MyBudgetAPI.Controllers;
using MyBudgetAPI.Models;
using MyBudgetAPI.Context;

namespace MyBudgetAPI.Controllers
{
    [Authorize] 
    [Route("api/[controller]")]
    [ApiController]
    public class IncomeController : ControllerBase
    {

        private readonly IIncomeRpository _incomeRepository;
        // --- 2. أضف متغيرًا للـ DbContext ---
        private readonly MyBudgetAPI.Context.ApplicationDbContext _context;

        // --- 3. قم بتعديل الـ Constructor ليقبل الـ DbContext ---
        public IncomeController(IIncomeRpository incomeRepository, MyBudgetAPI.Context.ApplicationDbContext context)
        {
            _incomeRepository = incomeRepository;
            _context = context; 
        }

        //this help to get the current user's ID
        private string GetCurrentUserId()
        {
            return User.FindFirstValue(ClaimTypes.NameIdentifier);
        }



        // GET: api/income/myincomes
        //Only fetches income records of logged in user!
      // GET: api/income/{id}
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(string id) // <-- غيرنا النوع إلى string
        {
            // بدلاً من استخدام المستودع، نبحث مباشرة ونتأكد من الملكية في خطوة واحدة
            var income = await _context.Incomes
                .FirstOrDefaultAsync(i => i.Id == id && i.UserId == GetCurrentUserId());

            if (income == null)
            {
                // هذه الرسالة الآن أكثر دقة: إما غير موجود أو ليس ملكك
                return NotFound("Income not found or you do not have permission.");
            }

            return Ok(income);
        }




        //// GET: api/income/myincomes
        ////Only fetches income records of logged in user!
        //[HttpGet] // 
        //public async Task<IActionResult> GetMyIncomes()
        //{
        //    var userId = GetCurrentUserId();
        //    if (string.IsNullOrEmpty(userId))
        //    {
        //        return Unauthorized();
        //    }

        //    var incomes = await _incomeRepository.GetIncomesByUserIdAsync(userId);

        //    if (incomes == null || !incomes.Any())
        //    {
        //        return NotFound("There are no income records currently for this user.");
        //    }

        //    return Ok(incomes);
        //}



        // GET: api/Income
        [HttpGet]
        public async Task<IActionResult> GetMyIncomes()
        {
            var userId = GetCurrentUserId();
            if (string.IsNullOrEmpty(userId))
            {
                return Unauthorized();
            }


            //    its like "SELECT * FROM Incomes WHERE UserId = @userId"
            var incomes = await _incomeRepository.GetIncomesByUserIdAsync(userId);

            return Ok(incomes);
        }



        // POST: api/income
        //new record and conect it to user account 
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] IncomeDto model)
        {
            var userId = GetCurrentUserId();
            if (string.IsNullOrEmpty(userId))
            {
                return Unauthorized();
            }

            var income = new Income
            {
                Title = model.Title,
                Amount = model.Amount,
                Source = model.Source,
                DateReceived = model.DateReceived,
                Note = model.Note,
                UserId = userId 
            };

            // from rebo 
            await _incomeRepository.AddAsync(income);

          
            return CreatedAtAction(nameof(GetById), new { id = income.Id }, income);
        }

        // PUT: api/income/{id}
        // user can update his own the record 
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(string id, [FromBody] IncomeDto model)
        {
            
            var incomeToUpdate = await _incomeRepository.GetByIdAsync(id);

           
            if (incomeToUpdate == null || incomeToUpdate.UserId != GetCurrentUserId())
            {
                return NotFound("Income not found or you do not have permission to update it.");
            }

            // update this : 
            incomeToUpdate.Title = model.Title;
            incomeToUpdate.Amount = model.Amount;
            incomeToUpdate.Source = model.Source;
            incomeToUpdate.DateReceived = model.DateReceived;
            incomeToUpdate.Note = model.Note;

            // from rebo 
            _incomeRepository.Update(incomeToUpdate);

            return NoContent(); 
        }

        // DELETE: api/income/{id}
        // delete record if its own record 
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            
            var incomeToDelete = await _incomeRepository.GetByIdAsync(id);

            
            if (incomeToDelete == null || incomeToDelete.UserId != GetCurrentUserId())
            {
                return NotFound("Income not found or you do not have permission to delete it.");
            }

            _incomeRepository.Delete(incomeToDelete);

            return NoContent(); 
        }
    }
}