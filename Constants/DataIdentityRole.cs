using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentPropertyManagement.Constants
{
  public class DataIdentityRole
  {
    //This is best stord in azure as Keys or in non same directory json Files. This data should not even be stored near the code
    public string AdminId = "001";
    public string RoleAdminName = "Admin";
    public string RoleAdminNameAllCaps = "ADMIN";

    public string ConcurencyStamd = new Guid().ToString();

    public string AdminPasseord = "Admin.001";
  }
}
