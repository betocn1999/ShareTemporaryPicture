using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ShareTemporaryPicture.Models.Requests;
using ShareTemporaryPicture.Models.Response;
using ShareTemporaryPicture.Services.Interfaces;

namespace ShareTemporaryPicture.Controllers
{
    [Route("api/picturePost")]
    public class PicturePostController : ControllerBase
    {
        private readonly IPicturePostService _picturePostService;
        public PicturePostController(IPicturePostService _picturePostService)
        {
            this._picturePostService = _picturePostService;
        }

        [Route("createPicturePost")]
        [HttpPost]
        public async Task<IActionResult> CreatePicturePostAsync(IFormFile file, string content)
        {
            try
            {
                var createPicturePostRequest = new CreatePicturePostRequest
                {
                    Content = JsonSerializer.Deserialize<CreatePicturePostRequestContentExtension>(content),
                    File = file
                };

                return StatusCode(StatusCodes.Status201Created, new BaseResponse
                {
                    StatusCode = StatusCodes.Status201Created,
                    Content = await _picturePostService.CreatePicturePostAsync(createPicturePostRequest)
                });
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new BaseResponse { StatusCode = StatusCodes.Status500InternalServerError });
            }
        }
    }
}
