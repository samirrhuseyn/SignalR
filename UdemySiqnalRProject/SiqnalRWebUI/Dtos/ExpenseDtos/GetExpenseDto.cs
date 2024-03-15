using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SiqnalRWebUI.Dtos.ExpenseDtos
{
    public class GetExpenseDto
    {
        public int ExpenseID { get; set; }
        public decimal ExpenseAmount { get; set; }
        public string ExpenseDescription { get; set; }
        public DateTime ExpenseDate { get; set; }
    }
}
