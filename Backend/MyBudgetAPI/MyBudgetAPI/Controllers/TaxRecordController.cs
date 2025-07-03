using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyBudget.BLL.Interface;
using MyBudgetAPI.Models;
using MyBudgetSystem.Data.Repositories;
using System.Security.Claims;

namespace MyBudgetAPI.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class TaxController : ControllerBase
    {
        private readonly IIncomeRpository _incomeRepo;
        private readonly IExpenseRepository _expenseRepo;

        public TaxController(IIncomeRpository incomeRepo, IExpenseRepository expenseRepo)
        {
            _incomeRepo = incomeRepo;
            _expenseRepo = expenseRepo;
        }

        private string GetCurrentUserId()
        {
            return User.FindFirstValue(ClaimTypes.NameIdentifier);
        }

        // GET: api/Tax/annual-summary
        [HttpGet("annual-summary")]
        public async Task<IActionResult> GetAnnualSummaryAndTax()
        {
            var userId = GetCurrentUserId();

            //get data 
            var allIncomes = await _incomeRepo.GetIncomesByUserIdAsync(userId);
            var allExpenses = await _expenseRepo.GetExpensesByUserIdAsync(userId);

            //for year 
            var oneYearAgo = DateTime.UtcNow.AddDays(-365);

            //Filter the data to include only the last year 
            var incomesInLastYear = allIncomes.Where(i => i.DateReceived >= oneYearAgo);
            var expensesInLastYear = allExpenses.Where(e => e.DateIncurred >= oneYearAgo);

            // Calculate totals based on filtered data 
            var totalIncomeLastYear = incomesInLastYear.Sum(i => i.Amount);
            var totalExpensesLastYear = expensesInLastYear.Sum(e => e.Amount);
            var netBalanceLastYear = totalIncomeLastYear - totalExpensesLastYear;

            // for the tax 
            const decimal TAX_THRESHOLD = 42000m; // Annual income limit
            const decimal TAX_RATE = 0.05m;      // 5% 
            decimal taxDue = 0;
            bool isTaxable = false;
            string taxMessage; 

            // check if 
            if (totalIncomeLastYear >= TAX_THRESHOLD)
            {
                isTaxable = true;
             
                decimal taxableAmount = totalIncomeLastYear - TAX_THRESHOLD;
                taxDue = taxableAmount * TAX_RATE;
                taxMessage = $"Your annual income of {totalIncomeLastYear:C} exceeds the threshold. A tax of {taxDue:C} is applicable.";
            }
            else
            {
                isTaxable = false;
                //for no tax 
                taxMessage = $"Your annual income of {totalIncomeLastYear:C} is below the {TAX_THRESHOLD:C} threshold. You are not required to pay tax.";
            }

            //disply 
            var result = new
            {
                Period = new
                {
                    StartDate = oneYearAgo.ToString("yyyy-MM-dd"),
                    EndDate = DateTime.UtcNow.ToString("yyyy-MM-dd")
                },
                AnnualSummary = new
                {
                    TotalIncome = totalIncomeLastYear,
                    TotalExpenses = totalExpensesLastYear,
                    NetBalance = netBalanceLastYear
                },
                TaxDetails = new
                {
                    IsTaxable = isTaxable,
                    Message = taxMessage, 
                    IncomeThreshold = TAX_THRESHOLD,
                    TaxRate = $"{TAX_RATE:P0}", // "5%"
                    TaxDue = taxDue
                }
            };

            return Ok(result);
        }
    }
}