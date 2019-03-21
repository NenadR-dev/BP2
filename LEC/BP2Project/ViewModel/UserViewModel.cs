using BP2Project.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BP2Project.ViewModel
{
    public class UserViewModel
    {
        public User user { get; set; }
        public string errorMSG { get; set; }

        public UserViewModel()
        {
            user = new User();
            errorMSG = string.Empty;
        }
    }
}