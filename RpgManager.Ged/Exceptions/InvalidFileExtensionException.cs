using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace RpgManager.Ged.Exceptions
{
    public class InvalidFileExtensionException : Exception
    {
        /// <inheritdoc />
        public InvalidFileExtensionException()
        {
        }

        /// <inheritdoc />
        protected InvalidFileExtensionException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }

        /// <inheritdoc />
        public InvalidFileExtensionException(string message) : base(message)
        {
        }

        /// <inheritdoc />
        public InvalidFileExtensionException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}