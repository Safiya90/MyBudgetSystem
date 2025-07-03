using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBudget.BLL.DTOs
{
    public class ExpenseDto
    {
        // لا نرسل Id عند الإنشاء، لذلك هو اختياري
        public int? Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Title { get; set; }

        [Required]
        [Range(0.01, double.MaxValue, ErrorMessage = "Amount must be greater than zero.")]
        public decimal Amount { get; set; }

        [StringLength(50)]
        public string? Category { get; set; } // this like fun , food , family etc 

        public DateTime DateIncurred { get; set; }

        [StringLength(500)]
        public string? Note { get; set; }
    }
}
