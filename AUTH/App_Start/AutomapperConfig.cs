using Auth.Bo;
using Auth.Bo.Bo;
using Auth.Domain;
using AUTH.Models;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using static AUTH.Utility.Session;

namespace AUTH.App_Start
{
    public class AutomapperConfig
    {
        public static void Register()
        {
            Mapper.CreateMap<Authorization, AuthorizationBo>();
            Mapper.CreateMap<Authentication, UserBo>();
            Mapper.CreateMap<RegistrationViewModel, RegisterBo>();
            Mapper.CreateMap<LoginViewModel, LoginBo>();
            Mapper.CreateMap<LoginBo, UserSession>();
            Mapper.CreateMap<UserBo, UserSession>();
        }
    }
}