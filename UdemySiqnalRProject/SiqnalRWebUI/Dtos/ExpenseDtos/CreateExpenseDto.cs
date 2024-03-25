using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SiqnalRWebUI.Dtos.ExpenseDtos
{
    public class CreateExpenseDto
    {
        [Required, DataType(DataType.Text), Display(Name = "Expense Amount")]
        public decimal ExpenseAmount { get; set; }

        [Required, DataType(DataType.Text), Display(Name = "Expense Description")]
        public string ExpenseDescription { get; set; }

        [Required, DataType(DataType.Date), Display(Name = "Expense Date")]
        public DateTime ExpenseDate { get; set; }
    }
}
