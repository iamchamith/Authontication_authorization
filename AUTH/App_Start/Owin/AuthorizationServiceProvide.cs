using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.Owin.Security.OAuth;
using System.Threading;
using System.Threading.Tasks;
using Auth.Service.Services;
using Auth.Service.Infastucture;
using System.Security.Claims;
namespace AUTH.App_Start.Owin
{
    public class AuthorizationServiceProvide : OAuthAuthorizationServerProvider
    {
        public override async Task ValidateClientAuthentication(OAuthValidateClientAuthenticationContext context)
        {
            // i have validated the client
              context.Validated();
        }

        public override async Task GrantResourceOwnerCredentials(OAuthGrantResourceOwnerCredentialsContext context)
        {
            // validate use name and password from user.
            // if found , genarate authorize token.
            var identity = new ClaimsIdentity(context.Options.AuthenticationType);
            var service = new AuthonticationService(new UnitOfWork());
            try
            {
                var res = await service.Login(new Auth.Bo.LoginBo
                {
                    Email = context.UserName,
                    Password = context.Password
                });

                identity.AddClaims(new List<Claim>() {
                    new Claim(ClaimTypes.Role,res.Roles.ToString()),
                      new Claim(ClaimTypes.Email,res.Email.ToString()),
                      new Claim(ClaimTypes.NameIdentifier,res.UserId.ToString()),
                });
                context.Validated(identity);
            }
            catch (ArgumentException)
            {
                context.SetError("invalied_grant", "invalied user name or password");return;
            }
            catch (Exception)
            {
                throw;
            }

        }
    }
}