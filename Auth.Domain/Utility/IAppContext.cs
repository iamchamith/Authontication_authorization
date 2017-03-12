using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Auth.Domain.Utility
{
    public interface IAppContext
    {
        DbSet<Authentication> Authentications { get; set; }
        DbSet<Authorization> Authorizations { get; set; }
        DbSet<Error> Errors { get; set; }
    }
}
