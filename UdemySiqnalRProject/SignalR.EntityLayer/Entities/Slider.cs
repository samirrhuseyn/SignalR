﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalR.EntityLayer.Entities
{
    public class Slider
    {
        public int SliderID { get; set; }
        public int DataValue { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
    }
}
