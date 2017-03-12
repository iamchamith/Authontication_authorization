using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Auth.Bo.Utility
{
    public class Enums
    {
        public enum Roles { Admin, User }
        public enum ErroType { Server, Client }
        public enum AppRunTime { Relase, Debug, Test }
        public enum CacheVariables
        {
           Roles
        }
    }
}
