using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace EMS.Model.Utility
{
    public class Helper
    {
        public static string SymmetricSecurityKey => ConfigurationManager.AppSettings["symmetricSecurityKey"] ?? "";
    }
}
