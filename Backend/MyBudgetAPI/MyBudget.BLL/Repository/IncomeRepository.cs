using Microsoft.EntityFrameworkCore;
using MyBudget.BLL.Interface;
using MyBudget.BLL.Repository;
using MyBudgetAPI.Context;
using MyBudgetAPI.Models;

namespace MyBudgetSystem.Data.Repositories
{
    public class IncomeRepository : GenericRepository<Income>, IIncomeRpository
    {
        private readonly ApplicationDbContext _context;

        public IncomeRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<decimal> GetTotalIncomeByMonthAsync(int month, int year)
        {
            return await _context.Incomes
                .Where(i=> i.DateReceived.Month == month && i.DateReceived.Year == year)
                .SumAsync(i => i.Amount);
           
        }
    }
}
