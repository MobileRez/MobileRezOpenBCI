using System;
using System.Collections.Generic;
using System.Text;
using MROpenBCI.Helpers;

namespace MROpenBCI.Model
{
    public class NavMenuItem
    {
        public string Title { get; set; }
        public string Icon { get; set; }
        public AppPage Key { get; set; }
        public string Group { get; set; }
    }
}
