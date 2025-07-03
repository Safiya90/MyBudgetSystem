using MyBudgetAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBudget.BLL.DTOs
{
    public class RecordTaxDto
    {
        public string? Id { get; set; }
        public int Year { get; set; }
        public int Month { get; set; } // أضفنا Month هنا ليتوافق مع TaxRecord
        public decimal TotalIncome { get; set; }
        public decimal TotalExpense { get; set; }
        public decimal NetIncome { get; set; } // <-- قيمة محسوبة للعرض
        public decimal TaxAmount { get; set; }
        public DateTime CalculationDate { get; set; } // <-- قيمة محسوبة للعرض
        public string UserId { get; set; }

    }
}
