using System;
using System.Runtime.Serialization;

namespace OfficeMap.Business
{
    [Serializable]
    public class OfficeMapException : Exception
    {
        public OfficeMapException()
        {
        }

        public OfficeMapException(string message) : base(message)
        {
        }

        public OfficeMapException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected OfficeMapException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}