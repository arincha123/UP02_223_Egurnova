using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Toys
{
    public static class UserData
    {
        public static User curUser { get; set; } = Core.context.User.First(u => u.Id == 1);
        public static bool isLogged => curUser != null;
    }
}
