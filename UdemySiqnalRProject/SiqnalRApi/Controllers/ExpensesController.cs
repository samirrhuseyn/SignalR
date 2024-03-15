using Microsoft.AspNetCore.Mvc;
using SignalR.BusinessLayer.Abstract;
using SignalR.DtoLayer.ExpenseDto;
using SignalR.EntityLayer.Entities;

namespace SiqnalRApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExpensesController : ControllerBase
    {
        private readonly IExpenseService _expenseService;

        public ExpensesController(IExpenseService expenseService)
        {
            _expenseService = expenseService;
        }

        [HttpGet]
        public IActionResult ExpenseList()
        {
            var value = _expenseService.TGetListAll();
            return Ok(value);
        }

        [HttpPost] 
        public IActionResult CreateExpense(CreateExpenseDto createExpenseDto)
        {
            _expenseService.TAdd(new Expense
            {
                ExpenseAmount = createExpenseDto.ExpenseAmount,
                ExpenseDate = Convert.ToDateTime(DateTime.Now.ToLongTimeString()),
                ExpenseDescription = createExpenseDto.ExpenseDescription,
            });
            return Ok("Addition successfuly");
        }
    }
}
