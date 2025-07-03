using MyBudgetAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBudget.BLL.Interface
{
    public interface ITaxRecordRepository : IGenericRepository<TaxRecord>
    {
        // يجلب كل سجلات الضريبة لمستخدم معين
        Task<IEnumerable<TaxRecord>> GetTaxRecordsByUserIdAsync(string userId);
        // يجلب سجل ضريبة لسنة معينة لمستخدم معين
        Task<TaxRecord> GetTaxRecordByYearAsync(string userId, int year);
    }

}
