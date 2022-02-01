using Microsoft.AspNetCore.Http;

namespace ShareTemporaryPicture.Models.Requests
{
    public class CreatePicturePostRequestContentExtension
    {
        public string Title { get; set; }
        public string Description { get; set; }
    }
}