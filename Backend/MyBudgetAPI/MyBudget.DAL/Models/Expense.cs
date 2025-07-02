using MyBudget.DAL.Models;

namespace MyBudgetAPI.Models
{
    public class Expense : BaseEntity
    {
        public string Title { get; set; }
        public decimal Amount { get; set; }
        public string Category { get; set; }
        public DateTime DateIncurred { get; set; }
        public string Note { get; set; }

        // Navigation property
        public string UserId { get; set; }
        public ApplicationUser User { get; set; }
    }
    
}
