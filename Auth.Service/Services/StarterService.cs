using Auth.Bo.Bo;
using Auth.Service.Infastucture;
using Auth.Service.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Auth.Service.Services
{
    public class StarterService : BaseService, IStarterService
    {
        IUnitOfWork uow;
        public StarterService(IUnitOfWork _uow)
        {
            this.uow = _uow;
        }

        public List<AuthorizationBo> Authorization()
        {
            try
            {
                return this.uow.AuthorizationRepository.Get()
                    .Select(x => AutoMapper.Mapper.Map<AuthorizationBo>(x)).ToList();
            }
            catch (Exception ex)
            {
                throw HandleException(ex);
            }
        }
    }
}
