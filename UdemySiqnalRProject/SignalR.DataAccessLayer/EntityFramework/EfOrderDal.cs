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
    public class EfOrderDal : GenericRepository<Order>, IOrderDal
    {
        public EfOrderDal(SignalRContext context) : base(context)
        {
        }

        public int ActiveOrderCount()
        {
            using var context = new SignalRContext();
            return context.Orders.Where(x => x.Description == "Custumer at the table").Count();
        }

        public decimal LastOrderPrice()
        {
            using var context = new SignalRContext();
            return context.Orders.OrderByDescending(x => x.Date).Select(y => y.TotalPrice).Take(1).FirstOrDefault();
        }

        public decimal TodayTotalEarning()
        {
            using var context = new SignalRContext();
            return context.Orders.Where(x=>x.Description == "Invoice paid").Where(x => x.Date.Day == DateTime.Now.Day).Where(y=>y.Date.Month == DateTime.Now.Month).Where(x=>x.Date.Year == DateTime.Now.Year).Sum(x=>x.TotalPrice);
        }

        public int TotalOrderCount()
        {
            using var context = new SignalRContext();
            return context.Orders.Count();
        }
    }
}
