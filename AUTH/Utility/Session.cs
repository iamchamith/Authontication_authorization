using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.SessionState;
using static Auth.Bo.Utility.Enums;

namespace AUTH.Utility
{
    public class Session
    {
        public class UserSession
        {
            public string UserId { get; set; }
            public string Email { get; set; }
            public bool IsValiedEmail { get; set; }
            public Roles Roles { get; set; }
            public bool Active { get; set; }
            public DateTime RegDate { get; set; }
        }
        public static UserSession User
        {
            get
            {
                HttpSessionState session = HttpContext.Current.Session;
                if (session["user"] != null)
                {
                    return (UserSession)session["user"];
                }
                return null;
            }
            set
            {
                HttpSessionState session = HttpContext.Current.Session;
                session["user"] = value;
            }
        }

        public static void Logout() {
            try
            {
                HttpContext.Current.Session.Abandon();
            }
            catch { throw; }
        }

        public static void SessionDesposed()
        {
            try
            {
                HttpSessionState session = HttpContext.Current.Session;
                session.Abandon();
            }
            catch
            {
                throw;
            }
        }
    }
}