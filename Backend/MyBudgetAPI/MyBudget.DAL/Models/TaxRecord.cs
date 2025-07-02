using Microsoft.VisualBasic;
using MyBudget.DAL.Models;

namespace MyBudgetAPI.Models
{
    public class TaxRecord :BaseEntity
    {
        public int Year { get; set; }
        public int Month { get; set; }
        public decimal TotalIncome { get; set; }
        public decimal TotalExpense { get; set; }
        public decimal TaxAmount { get; set; }

        // Navigation property
        public string UserId { get; set; }
        public ApplicationUser User { get; set; }
    }
}
