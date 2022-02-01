using ShareTemporaryPicture.Models.Requests;
using ShareTemporaryPicture.Models.Response;
using ShareTemporaryPicture.Repository.Interfaces;
using ShareTemporaryPicture.Services.Interfaces;
using System.IO;
using System.Threading.Tasks;
using Amazon.S3;
using Amazon.S3.Model;
using Microsoft.AspNetCore.Http;

namespace ShareTemporaryPicture.Services
{
    public class PicturePostService : IPicturePostService
    {
        private readonly IPicturePostRepository _picturePostRepository;
        public PicturePostService(IPicturePostRepository _picturePostRepository)
        {
            this._picturePostRepository = _picturePostRepository;
        }

        // TODO: If one of them fails make a rollback.
        // TODO: Extract the process of sending the image to another class.
        public async Task<CreatePicturePostResponse> CreatePicturePostAsync(CreatePicturePostRequest request)
        {
            AmazonS3Client s3Client = new AmazonS3Client("AKIAZ2P5S5Z46VIDCPPU", "A2UtjpetEosmranRORrUDg1FzwW8fN5GIbTONDGo");
            var model = new UploadPartRequest();
            model.BucketName = "share-temporary-picture-u4n8fy4ajcfvj8f6";
            model.Key = "images/dsadasdas.png";
            model.InputStream = request.File.OpenReadStream();
            await s3Client.UploadPartAsync(model);
            return await _picturePostRepository.CreatePicturePostAsync(request.Content);
        }
    }
}