using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Singleton
{
    public class CurrentUser
    {
        private static CurrentUser _instance;

        public static CurrentUser Instance => _instance ?? (_instance = new CurrentUser());

        public string LoggedInUser { get; set; }

        private CurrentUser()
        {
        }
    }
}
