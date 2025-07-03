using Microsoft.EntityFrameworkCore;
using MyBudget.BLL.Interface;
using MyBudget.BLL.Repository;
using MyBudgetAPI.Context;
using MyBudgetAPI.Models;
using System.Collections.Generic; 
using System.Linq; 
using System.Threading.Tasks; 

namespace MyBudgetSystem.Data.Repositories
{
    public class IncomeRepository : GenericRepository<Income>, IIncomeRpository
    {
        public IncomeRepository(ApplicationDbContext context) : base(context)
        {
        }


       // Find all sources of income for a specific user
        public async Task<IEnumerable<Income>> GetIncomesByUserIdAsync(string userId)
        {
            return await _context.Incomes
                .Where(i => i.UserId == userId)
                .OrderByDescending(i => i.DateReceived)
                .ToListAsync();
        }


        //Calculates the total income amount for a group of entries in a given month and year

        public async Task<decimal> GetTotalIncomeByMonthAsync(int month, int year)
        {
            return await _context.Incomes
                .Where(i => i.DateReceived.Month == month && i.DateReceived.Year == year)
                .SumAsync(i => i.Amount);
        }
     
    }
}
