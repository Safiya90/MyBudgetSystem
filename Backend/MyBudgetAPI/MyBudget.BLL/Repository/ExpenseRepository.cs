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
        public ExpenseRepository(ApplicationDbContext context) : base(context)
        {
        }

        // to get user Expense 
        public async Task<IEnumerable<Expense>> GetExpensesByUserIdAsync(string userId)
        {
            return await _context.Expenses
                .Where(e => e.UserId == userId)
                .OrderByDescending(e => e.DateIncurred)
                .ToListAsync();
        }
    }
}
