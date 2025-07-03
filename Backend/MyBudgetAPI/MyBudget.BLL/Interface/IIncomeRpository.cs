using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyBudgetAPI.Models;

namespace MyBudget.BLL.Interface
{
   

 
    public interface IIncomeRpository : IGenericRepository<Income>
    {
 

        
        Task<IEnumerable<Income>> GetIncomesByUserIdAsync(string userId);

        Task<decimal> GetTotalIncomeByMonthAsync(int month, int year);
    }
}
