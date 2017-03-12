using Auth.Bo.Utility;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Auth.Service.Services
{
    public class BaseService
    {
        protected Exception HandleException(Exception exception)
        {
            var x = exception;
            while (x.InnerException != null)
            {
                x = x.InnerException;
            }
            var sqlException = x as SqlException;
            if (sqlException == null)
            {
                throw x;
            }
            if (sqlException.Number == 2627 || sqlException.Number == 2601)
            {
                throw new DbPKViolationException();
            }
            throw exception;
        }
    }
}
