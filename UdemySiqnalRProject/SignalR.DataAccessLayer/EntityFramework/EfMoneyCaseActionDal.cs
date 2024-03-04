using SignalR.DataAccessLayer.Abstarct;
using SignalR.DataAccessLayer.Concrete;
using SignalR.DataAccessLayer.Repositories;
using SignalR.EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalR.DataAccessLayer.EntityFramework
{
    public class EfMoneyCaseActionDal : GenericRepository<MoneyCaseAction>, IMoneyCaseActionDal
    {
        public EfMoneyCaseActionDal(SignalRContext context) : base(context)
        {
        }

        public List<MoneyCaseAction> GetListByThisMonth()
        {
            using var context = new SignalRContext();
            return context.MoneyCaseActions.OrderByDescending(x=>x.DateTime).Where(x=>x.DateTime.Month ==  DateTime.Now.Month).Where(x => x.DateTime.Year == DateTime.Now.Year).ToList();
        }
    }
}
