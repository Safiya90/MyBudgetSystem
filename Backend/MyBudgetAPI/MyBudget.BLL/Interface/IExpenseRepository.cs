using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyBudgetAPI.Models;

namespace MyBudget.BLL.Interface
{
    // it inheriths all this methods : GetById, Add, Update, Delete 
    public interface IExpenseRepository : IGenericRepository<Expense>
    {
        //Task<decimal> GetTotalIncomeByMonthAsync(int month, int year);

        Task<IEnumerable<Expense>> GetExpensesByUserIdAsync(string userId);


    }
}
