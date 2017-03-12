using Auth.Bo.Bo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Auth.Service.Services.Interfaces
{
    public interface IStarterService
    {
        List<AuthorizationBo> Authorization();
    }
}
