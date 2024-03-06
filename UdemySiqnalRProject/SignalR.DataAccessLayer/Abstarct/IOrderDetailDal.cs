﻿using SignalR.EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalR.DataAccessLayer.Abstarct
{
    public interface IOrderDetailDal : IGenericDal<OrderDetail>
    {
        List<OrderDetail> GetListByID(int id);
    }
}
