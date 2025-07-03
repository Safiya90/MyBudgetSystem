using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyBudgetAPI.Models;

namespace MyBudget.BLL.DTOs
{
    public class IncomeDto
    {
        //public string Id { get; set; }
        //public string Title { get; set; }
        //public decimal Amount { get; set; }
        //public string Source { get; set; }
        //public DateTime DateReceived { get; set; }
        //public string Note { get; set; }

        //public string UserId { get; set; }
        //public ApplicationUser User { get; set; }


        public int? Id { get; set; }
        public string Title { get; set; }
        public decimal Amount { get; set; }
        public string Source { get; set; }
        public DateTime DateReceived { get; set; }
        public string Note { get; set; }


    }
}
