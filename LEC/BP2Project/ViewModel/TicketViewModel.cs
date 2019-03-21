using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BP2Project.ViewModel
{
    public class TicketViewModel
    {
        public List<string> matches { get; set; }
        public string errorMSG { get; set; }

        public TicketViewModel()
        {
            matches = new List<string>();
            errorMSG = string.Empty;
        }
    }
}