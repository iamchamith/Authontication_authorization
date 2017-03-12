using Auth.Bo;
using Auth.Bo.Utility;
using Auth.Service.Infastucture;
using Auth.Service.Services;
using Auth.Service.Services.Interfaces;
using AUTH.Models;
using AUTH.Utility;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using static AUTH.Utility.Session;

namespace AUTH.Api
{
    [RoutePrefix("api/v1/auth")]
    public class AuthController : ApiController
    {
        IAuthonticationService authService;
        public AuthController()
        {
            authService = new AuthonticationService(new UnitOfWork());
        }
        public AuthController(IUnitOfWork _uow)
        {
            authService = new AuthonticationService(_uow);
        }

        [HttpPost]
        [AllowAnonymous]
        [Route("login")]
        public async Task<IHttpActionResult> Login(LoginViewModel model)
        {
            try
            {
                var result = await this.authService.Login(Mapper.Map<LoginBo>(model));
                Session.User = Mapper.Map<UserSession>(result);
                return Ok();
            }
            catch (ArgumentException ex)
            {
                return Content<string>(HttpStatusCode.NotAcceptable, ex.Message);
            }
            catch (Exception ex)
            {
                return Content<string>(HttpStatusCode.InternalServerError, ex.Message);
            }
        }
        [HttpPost]
        [ValidateModel]
        [Route("register")]
        public async Task<IHttpActionResult> Register(RegistrationViewModel model)
        {
            try
            {
                var result = await this.authService.Registration(Mapper.Map<RegisterBo>(model));
                Session.User = Mapper.Map<UserSession>(result);
                return Ok();
            }
            catch (DbPKViolationException ex)
            {
                return Content<string>(HttpStatusCode.NotAcceptable, "Email aleady there");
            }
            catch (Exception ex)
            {
                return Content<string>(HttpStatusCode.InternalServerError, ex.Message);
            }
        }
        [HttpPost]
        [Route("logout")]
        [Authorized(RoleTags = "*")]
        public async Task<IHttpActionResult> Logout()
        {
            try
            {
                Session.Logout();
                return Ok();
            }
            catch (Exception ex)
            {
                return Content<string>(HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        [HttpGet]
        [ValidateModel]
        [Route("Sample")]
        public async Task<IHttpActionResult> Sample() { return Ok<string>("sucess"); }

        #region Praform

        [HttpGet]
        [Authorized(RoleTags = "admin")]
        [Route("AdminFunction")]
        public string AdminFunction()
        {
            return "ok";
        }

        [HttpGet]
        [Authorized(RoleTags = "user")]
        [Route("UserFunction")]
        public string UserFunction()
        {
            return "ok";
        }
        [HttpGet]
        [Authorized(RoleTags = "admin,user")]
        [Route("BothFunction")]
        public string BothFunction()
        {
            return "ok";
        }

        #endregion
    }
}
