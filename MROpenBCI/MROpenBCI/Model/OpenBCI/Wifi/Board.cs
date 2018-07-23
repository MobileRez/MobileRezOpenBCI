using System;
using System.Collections.Generic;
using System.Text;

namespace MROpenBCI.Model.OpenBCI.Wifi
{
    public class Board
    {
        public bool board_connected { get; set; }
        public string board_type { get; set; }
        public int num_channels { get; set; }
        public List<int> gains { get; set; }
    }
}
