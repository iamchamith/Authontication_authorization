using System;
using System.Runtime.Serialization;

namespace Auth.Service.Infastucture
{
    [Serializable]
    internal class DbRowNotFoundException : Exception
    {
        public DbRowNotFoundException()
        {
        }

        public DbRowNotFoundException(string message) : base(message)
        {
        }

        public DbRowNotFoundException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected DbRowNotFoundException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}