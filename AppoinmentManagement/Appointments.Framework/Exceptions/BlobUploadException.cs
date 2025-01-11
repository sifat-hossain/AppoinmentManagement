namespace Appointments.Framework.Exceptions
{
    public class BlobUploadException : Exception
    {
        public BlobUploadException(string fileName)
            : base($"File: {fileName} was uploaded with 0 bytes")
        {
        }

        public BlobUploadException()
        {
        }

        public BlobUploadException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}