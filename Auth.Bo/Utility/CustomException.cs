using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Auth.Bo.Utility
{
    public class DbPKViolationException : Exception
    {
        public DbPKViolationException() : base() { }
        public DbPKViolationException(string message) : base(message) { }
    }
    public class DbFKViolationException : Exception
    {
        public DbFKViolationException() : base() { }
        public DbFKViolationException(string message) : base(message) { }
    }
    public class DbUniqKeyViolationException : Exception
    {
        public DbUniqKeyViolationException() : base() { }
        public DbUniqKeyViolationException(string message) : base(message) { }
    }
    public class DbRowNotFoundException : Exception
    {
        public DbRowNotFoundException() : base() { }
        public DbRowNotFoundException(string message) : base(message) { }
    }
}
