using SignalR.BusinessLayer.Abstract;
using SignalR.DataAccessLayer.Abstarct;
using SignalR.EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalR.BusinessLayer.Concrete
{
    public class ExpenseManager : IExpenseService
    {
        private readonly IExpenseDal _expenseDel;

        public ExpenseManager(IExpenseDal expenseDel)
        {
            _expenseDel = expenseDel;
        }

        public void TAdd(Expense entity)
        {
            _expenseDel.Add(entity);
        }

        public void TDelete(Expense entity)
        {
            _expenseDel.Delete(entity);
        }

        public Expense TGetByID(int id)
        {
            return _expenseDel.GetByID(id);
        }

        public List<Expense> TGetListAll()
        {
            return _expenseDel.GetListAll();
        }

        public void TUpdate(Expense entity)
        {
            _expenseDel.Update(entity);
        }
    }
}
