using Microsoft.EntityFrameworkCore;
using MyBudget.BLL.Interface;
using MyBudgetAPI.Context;
using MyBudgetAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBudget.BLL.Repository
{
    public class TaxRecordRepository : GenericRepository<TaxRecord>, ITaxRecordRepository
    {
        // الـ _context متاح من GenericRepository
        public TaxRecordRepository(ApplicationDbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<TaxRecord>> GetTaxRecordsByUserIdAsync(string userId)
        {
            return await _context.TaxRecords
                .Where(tr => tr.UserId == userId)
                .OrderByDescending(tr => tr.Year)
                .ToListAsync();
        }

        public async Task<TaxRecord> GetTaxRecordByYearAsync(string userId, int year)
        {
            return await _context.TaxRecords
                .FirstOrDefaultAsync(tr => tr.UserId == userId && tr.Year == year);
        }
    }
}