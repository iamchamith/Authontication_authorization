using Auth.Bo.Bo;
using Auth.Service.Infastucture;
using Auth.Service.Services;
using Auth.Service.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AUTH.Utility
{
    public class Starter
    { 
        public static List<AuthorizationBo> GetAuthorization()
        {
            try
            {
                IStarterService startService = new StarterService(new UnitOfWork());
                return startService.Authorization();
            }
            catch { throw; }
        }
    }
}