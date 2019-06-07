using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;

namespace GlobalException.Exceptions
{
    public class PointException : Exception
    {
        public PointException()
        {
        }

        public PointException(string message) : base(message)
        {
        }

        public PointException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected PointException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
