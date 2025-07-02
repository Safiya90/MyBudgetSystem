using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MyBudget.BLL.Interface;
using MyBudgetAPI.Context;
using MyBudgetAPI.Models;

namespace MyBudget.BLL.Repository
{
     public class ExpenseRepository : GenericRepository<Expense>, IExpenseRepository
    {
        private readonly ApplicationDbContext _context;

        public ExpenseRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<decimal> GetTotalIncomeByMonthAsync(int month, int year)
        {
            return await _context.Incomes
                .Where(i => i.DateReceived.Month == month && i.DateReceived.Year == year)
                .SumAsync(i => i.Amount);

        }
    }
}
