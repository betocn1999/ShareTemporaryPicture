using ShareTemporaryPicture.Models.Requests;
using ShareTemporaryPicture.Models.Response;
using ShareTemporaryPicture.Repository.Interfaces;
using ShareTemporaryPicture.Services.Interfaces;
using System.IO;
using System.Threading.Tasks;
using Amazon.S3;
using Amazon.S3.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using ShareTemporaryPicture.Models.Exceptions;
using System;

namespace ShareTemporaryPicture.Services
{
    public class PicturePostService : S3BucketProcess, IPicturePostService
    {
        private readonly IPicturePostRepository _picturePostRepository;
        public PicturePostService(IPicturePostRepository _picturePostRepository, IConfiguration _configuration) : base(_configuration)
        {
            this._picturePostRepository = _picturePostRepository;
        }

        // TODO: When I upload a file or insert the data to the database if one of them fails starts a rollback. 
        public async Task<CreatePicturePostResponse> CreatePicturePostAsync(CreatePicturePostRequest request)
        {
            if (IsValidImageFile(request.File))
            {
                string fileName = await UploadFileAsync(request.File);
                return await _picturePostRepository.CreatePicturePostAsync(request.Content, fileName, Guid.NewGuid().ToString("N"), Guid.NewGuid().ToString("N"));
            }
            else
            {
                throw new PicturePostServiceException("The file doesn't have a valid extension.");
            }            
        }
    }
}