using System;
using System.Runtime.Serialization;

namespace Tickbox.Core.Exceptions
{
    internal class DatabaseNotRegisteredException : Exception
    {
        public DatabaseNotRegisteredException(Type dbType)
            : base(string.Format("Database {0} has not been registered in app setup.", dbType.Name))
        {
        }

        public DatabaseNotRegisteredException(SerializationInfo sInfo, StreamingContext cxt)
            : base(sInfo, cxt)
        {
        }
    }

}
