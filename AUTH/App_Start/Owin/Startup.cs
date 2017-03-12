using System;
using System.Threading.Tasks;
using Microsoft.Owin;
using Owin;
using Microsoft.Owin.Security.OAuth;
using System.Web.Http;
[assembly: OwinStartup(typeof(AUTH.App_Start.Owin.Startup))]

namespace AUTH.App_Start.Owin
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            // enable cros origine request
            app.UseCors(Microsoft.Owin.Cors.CorsOptions.AllowAll);

            var authProvider = new AuthorizationServiceProvide();
            var options = new OAuthAuthorizationServerOptions
            {
                AllowInsecureHttp = true,
                TokenEndpointPath = new PathString("/token"),
                AccessTokenExpireTimeSpan = TimeSpan.FromDays(1),
                Provider = authProvider
            };
            app.UseOAuthAuthorizationServer(options);
            app.UseOAuthBearerAuthentication(new OAuthBearerAuthenticationOptions());

            HttpConfiguration config = new HttpConfiguration();
            WebApiConfig.Register(config);
        }
    }
}
