using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Security.Claims;

namespace EMS.Model.Utility
{
    public class Helper
    {
        public static string SymmetricSecurityKey => ConfigurationManager.AppSettings["symmetricSecurityKey"] ?? "";

        public static int GetEmpIdFromClaims(ClaimsPrincipal claims)
        {
            int value = 0;
            var claim = claims?.FindFirst(x => x.Type == "UId");
            _ = int.TryParse(claim?.Value ?? string.Empty, out value);
            return value;
        }
    }
}
