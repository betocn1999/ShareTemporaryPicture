using Microsoft.Extensions.Configuration;
using ShareTemporaryPicture.Models.Requests;
using ShareTemporaryPicture.Repository.Interfaces;
using System.Threading.Tasks;
using Dapper;
using System;
using ShareTemporaryPicture.Models.Response;
using System.Collections.Generic;

namespace ShareTemporaryPicture.Repository
{
    public class PicturePostRepository : PostgresConnection, IPicturePostRepository
    {
        public PicturePostRepository(IConfiguration _configuration) : base(_configuration) { }

        public async Task<CreatePicturePostResponse> CreatePicturePostAsync(CreatePicturePostRequestContentExtension request, string fileName, string accessKey, string deleteKey)
        {
            string sql = "INSERT INTO picture_post (title, description, file_name, access_key, delete_key, created_date) VALUES (@title, @description, @file_name, @access_key, @delete_key, @created_date);";
            using var conn = GetPostgresConnection();
            await conn.OpenAsync();
            await conn.ExecuteAsync(sql, new { 
                title = request.Title, 
                description = request.Description,
                file_name = fileName,
                access_key = accessKey,
                delete_key = deleteKey, 
                created_date = DateTime.UtcNow 
            });
            await conn.CloseAsync();

            return new CreatePicturePostResponse
            {
                DeleteKey = deleteKey,
                AccessKey = accessKey
            };
        }
    }
}