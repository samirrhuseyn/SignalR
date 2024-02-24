using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalR.DtoLayer.SlideDto
{
    public class CreateSlideDto
    {
        public int DataValue { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
    }
}
