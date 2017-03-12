using Auth.Bo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Auth.Service.Services.Interfaces
{
    public interface IAuthonticationService
    {
        Task<UserBo> Registration(RegisterBo entity);
        Task<UserBo> Login(LoginBo entity);
    }
}
