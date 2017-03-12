using Auth.Service.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Auth.Bo;
using Auth.Service.Infastucture;
using AutoMapper;
using Auth.Domain;

namespace Auth.Service.Services
{
    public class AuthonticationService : BaseService, IAuthonticationService
    {
        IUnitOfWork uow;
        public AuthonticationService(IUnitOfWork _uow)
        {
            this.uow = _uow;
        }
        public async Task<UserBo> Login(LoginBo entity)
        {
            try
            {
                var result = this.uow.Context.Authentications
                    .FirstOrDefault(p => p.Email == entity.Email.Trim().ToLower() && p.Password == entity.Password);

                if (result == null)
                {
                    throw new ArgumentException("invalied username or password");
                }
                return Mapper.Map<UserBo>(result);
            }
            catch (Exception ex)
            {
                throw HandleException(ex);
            }
        }

        public async Task<UserBo> Registration(RegisterBo entity)
        {
            try
            {
                string userId = Guid.NewGuid().ToString();
                var auth = new Authentication
                {
                    Active = false,
                    Email = entity.Email.Trim().ToLower(),
                    IsValiedEmail = false,
                    Password = entity.Password,
                    RegDate = DateTime.UtcNow,
                    Roles = Bo.Utility.Enums.Roles.User,
                    UserId = userId
                };
                this.uow.Context.Authentications.Add(auth);
                await this.uow.SaveAsync();
                return Mapper.Map<UserBo>(auth);
            }
            catch (Exception ex)
            {
                throw HandleException(ex);
            }
        }

    }
}
