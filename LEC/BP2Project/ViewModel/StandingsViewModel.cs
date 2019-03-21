using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BP2Project.ViewModel
{
    public class StandingsViewModel
    {
        public List<string> teams { get; set; }
        public string errorMSG { get; set; }

        public StandingsViewModel()
        {
            teams = new List<string>();
            errorMSG = string.Empty;
        }
    }
}