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

        public async Task<CreatePicturePostResponse> CreatePicturePostAsync(CreatePicturePostRequestContentExtension request)
        {
            string sql = "INSERT INTO picture_post (title, description, delete_key, created_date) VALUES (@title, @description, @delete_key, @created_date);" +
                "SELECT delete_key FROM picture_post WHERE delete_key = @delete_key";
            using var conn = GetPostgresConnection();
            await conn.OpenAsync();
            string resultDeleteKey = await conn.QueryFirstAsync<string>(sql, new { title = request.Title, description = request.Description, delete_key = Guid.NewGuid().ToString("N"), created_date = DateTime.UtcNow });
            await conn.CloseAsync();

            return new CreatePicturePostResponse
            {
                DeleteKey = resultDeleteKey,
            };
        }
    }
}