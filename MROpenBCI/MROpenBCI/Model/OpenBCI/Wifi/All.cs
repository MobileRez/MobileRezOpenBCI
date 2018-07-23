using System;
using System.Collections.Generic;
using System.Text;

namespace MROpenBCI.Model.OpenBCI.Wifi
{
    public class All
    {
        public bool board_connected { get; set; }
        public int heap { get; set; }
        public string ip { get; set; }
        public string mac { get; set; }
        public string name { get; set; }
        public int num_channels { get; set; }
        public string version { get; set; }
        public int latency { get; set; }
    }
}
