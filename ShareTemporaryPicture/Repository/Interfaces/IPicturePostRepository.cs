using ShareTemporaryPicture.Models.Requests;
using ShareTemporaryPicture.Models.Response;
using System.Threading.Tasks;

namespace ShareTemporaryPicture.Repository.Interfaces
{
    public interface IPicturePostRepository
    {
        Task<CreatePicturePostResponse> CreatePicturePostAsync(CreatePicturePostRequestContentExtension request, string fileName, string accessKey, string deleteKey);
    }
}