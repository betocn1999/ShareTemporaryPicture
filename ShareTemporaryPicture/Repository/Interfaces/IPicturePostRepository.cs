using ShareTemporaryPicture.Models.Requests;
using ShareTemporaryPicture.Models.Response;
using System.Threading.Tasks;

namespace ShareTemporaryPicture.Repository.Interfaces
{
    public interface IPicturePostRepository
    {
        Task<CreatePicturePostResponse> CreatePicturePostAsync(CreatePicturePostRequestContentExtension request);
    }
}