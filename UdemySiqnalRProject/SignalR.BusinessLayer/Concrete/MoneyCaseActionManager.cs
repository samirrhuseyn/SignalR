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
    public class MoneyCaseActionManager : IMoneyCaseActionService
    {
        private readonly IMoneyCaseActionDal _moneyCaseActionDal;

        public MoneyCaseActionManager(IMoneyCaseActionDal moneyCaseActionDal)
        {
            _moneyCaseActionDal = moneyCaseActionDal;
        }

        public void TAdd(MoneyCaseAction entity)
        {
            _moneyCaseActionDal.Add(entity);
        }

        public void TDelete(MoneyCaseAction entity)
        {
            _moneyCaseActionDal.Delete(entity);
        }

        public MoneyCaseAction TGetByID(int id)
        {
            return _moneyCaseActionDal.GetByID(id);
        }

        public List<MoneyCaseAction> TGetListAll()
        {
            return _moneyCaseActionDal.GetListByThisMonth();
        }

        public void TUpdate(MoneyCaseAction entity)
        {
            _moneyCaseActionDal.Update(entity);
        }
    }
}
