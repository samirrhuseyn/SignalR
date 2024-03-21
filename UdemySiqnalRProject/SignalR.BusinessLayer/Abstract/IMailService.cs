using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalR.BusinessLayer.Abstract
{
    public interface IMailService
    {
        public void SendMail(string addMail, string body, string subject);
    }
}
