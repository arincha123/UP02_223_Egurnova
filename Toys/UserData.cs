using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Toys
{
    public static class UserData
    {
        public static User curUser = Core.context.User.First(u => u.id == 1);
        public static bool isLogged => curUser != null;
    }
}
