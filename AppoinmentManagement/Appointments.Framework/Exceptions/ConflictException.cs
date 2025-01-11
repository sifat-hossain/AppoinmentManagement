using System.Runtime.Serialization;

namespace Appointments.Framework.Exceptions
{
    public class ConflictException : Exception
    {
        #region Constructors
        public ConflictException()
        {
        }

        public ConflictException(string name, object key)
            : base($"Entity \"{name}\" with ({key}) already exists.")
        {

        }

        public ConflictException(string message) : base(message)
        {
        }

        public ConflictException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected ConflictException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
        #endregion
    }
}
