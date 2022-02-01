using Microsoft.AspNetCore.Http;
using ShareTemporaryPicture.Models.Requests;
using ShareTemporaryPicture.Models.Response;
using System.IO;
using System.Threading.Tasks;

namespace ShareTemporaryPicture.Services.Interfaces
{
    public interface IPicturePostService
    {
        Task<CreatePicturePostResponse> CreatePicturePostAsync(CreatePicturePostRequest request);
    }
}