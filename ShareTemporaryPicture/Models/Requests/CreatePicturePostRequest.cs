using Microsoft.AspNetCore.Http;

namespace ShareTemporaryPicture.Models.Requests
{
    public class CreatePicturePostRequest
    {
        public IFormFile File { get; set; }
        public CreatePicturePostRequestContentExtension Content { get; set; }
    }
}