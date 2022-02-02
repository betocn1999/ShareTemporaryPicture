using Amazon.S3;
using Amazon.S3.Model;
using Microsoft.Extensions.Configuration;
using ShareTemporaryPicture.Models.Enums;
using ShareTemporaryPicture.Models.Requests;
using System;
using System.IO;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.AspNetCore.Http;

namespace ShareTemporaryPicture.Services
{ 
    public class S3BucketProcess
    {
        private readonly IConfiguration _configuration;
        private readonly AmazonS3Client _amazonS3Client;

        public S3BucketProcess(IConfiguration _configuration) 
        { 
            this._configuration = _configuration;
            _amazonS3Client = new AmazonS3Client(
                _configuration.GetValue<string>(AmazonS3ClientParameters.AwsAccessKeyId.GetName()), 
                _configuration.GetValue<string>(AmazonS3ClientParameters.AwsSecretAccessKey.GetName())
            );
        }

        public bool IsValidImageFile(IFormFile file) => new string[] { ".png", ".jpg", ".jpeg" }.Contains(Path.GetExtension(file.FileName));

        public async Task<string> UploadFileAsync(IFormFile file, string fileName = null, string path = null)
        {
            fileName = (fileName ?? Guid.NewGuid().ToString("N")) + Path.GetExtension(file.FileName); 
            path ??= _configuration.GetValue<string>(S3BucketShareTemporaryPictureParameters.Path.GetName());

            await _amazonS3Client.UploadPartAsync(new UploadPartRequest
            {
                BucketName = _configuration.GetValue<string>(S3BucketShareTemporaryPictureParameters.BucketName.GetName()),
                Key = path + fileName,
                InputStream = file.OpenReadStream(),
            });

            return fileName;
        } 
    }
}