using Microsoft.AspNetCore.Identity;

namespace MyBudgetAPI.Models
{
    public class ApplicationUser :IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        // Navigation properties
        public IEnumerable<Income> Incomes { get; set; } = new List<Income>();
        public IEnumerable<Expense> Expenses { get; set; } = new List<Expense>();
        public IEnumerable<TaxRecord> TaxRecords { get; set; } = new List<TaxRecord>();
    }
}
