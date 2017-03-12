using Auth.Bo.Bo;
using Auth.Bo.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using static Auth.Bo.Utility.Enums;

namespace AUTH.Utility
{
    public class AuthorizedAttribute : AuthorizeAttribute
    {
        public string RoleTags { get; set; }
        protected override bool IsAuthorized(System.Web.Http.Controllers.HttpActionContext actionContext)
        {
            // check authontication
            if (Session.User == null)
            {
                return false;
            }
            else {

                if (RoleTags.Equals("*"))
                {
                    return true;
                }
                // check authorization
                var roles = (List<AuthorizationBo>)Cache.GetValue(CacheVariables.Roles.ToString());
                var arr = RoleTags.Split(',');
                var lst = new List<int>();
                foreach (var item in roles)
                {
                    if (arr.Contains(item.Tag.Trim().ToLower())) {
                        lst.Add((int)item.Roles);
                    }
                }
                if (lst.Contains((int)Session.User.Roles))
                {
                    return true;
                }
                return false;
            }
        }
    }
}