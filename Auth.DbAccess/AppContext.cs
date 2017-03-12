using Auth.Domain.Utility;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Auth.Domain;

namespace Auth.DbAccess
{
    public class AppContext:DbContext,IAppContext
    {
        public AppContext() : base(@"Data Source=JET-DEV03\TOWNSUITE;Initial Catalog=Authontication;Integrated Security=True") { }

        public DbSet<Authentication> Authentications
        {
            get;set;
        }

        public DbSet<Authorization> Authorizations
        {
            get;set;
        }

        public DbSet<Error> Errors
        {
            get;set;
        }
    }
}
