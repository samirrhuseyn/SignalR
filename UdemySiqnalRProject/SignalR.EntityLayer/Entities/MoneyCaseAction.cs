using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalR.EntityLayer.Entities
{
    public class MoneyCaseAction
    {
        [Key]
        public int ActionID { get; set; }
        public decimal ActionAmount { get; set; }
        public DateTime DateTime { get; set; }
        public string Description { get; set; }
        public bool ActionType { get; set; }
    }
}
