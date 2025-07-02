using MyBudget.DAL.Models;

namespace MyBudgetAPI.Models
{
    public class Income : BaseEntity
    {
        public string Title { get; set; }
        public decimal Amount { get; set; }
        public string Source { get; set; }
        public DateTime DateReceived { get; set; }
        public string Note { get; set; }

        // Navigation property

        public string UserId { get; set; }
        public ApplicationUser User { get; set; }


    }
}
