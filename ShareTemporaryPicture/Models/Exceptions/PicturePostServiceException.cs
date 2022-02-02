using System;

namespace ShareTemporaryPicture.Models.Exceptions
{
    public class PicturePostServiceException : Exception
    {
        public PicturePostServiceException() { }

        public PicturePostServiceException(string message) : base(message) { }

        public PicturePostServiceException(string message, Exception inner) : base(message, inner) { }
    }
}
