using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using AutoMapper;
using CloudinaryDotNet;
using CloudinaryDotNet.Actions;
using Me.Api.Helpers.Cloudinary;
using Me.Business.Abstract;
using Me.Dto.DataTransferObjects;
using Me.Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace Me.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PhotosController : ControllerBase
    {
        private readonly IPhotoService _photoService;
        private readonly IMapper _mapper;
        private readonly IOptions<CloudinarySettings> _cloudinarySettings;

        private Cloudinary _cloudinary;

        public PhotosController(IPhotoService photoService, IMapper mapper, IOptions<CloudinarySettings> cloudinarySettings)
        {
            _photoService = photoService;
            _mapper = mapper;
            _cloudinarySettings = cloudinarySettings;

            Account account = new Account(
                _cloudinarySettings.Value.CloudName,
                _cloudinarySettings.Value.ApiKey,
                _cloudinarySettings.Value.ApiSecret);

            _cloudinary = new Cloudinary(account);
        }

        [HttpPost("addphoto")]
        public ActionResult AddPhoto([FromBody]PhotoDto photoDto)
        {
            var currentUserId = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier).Value);

            var file = photoDto.File;

            var uploadResult = new ImageUploadResult();

            if (file.Length > 0)
            {
                using (var stream = file.OpenReadStream())
                {
                    var uploadParams = new ImageUploadParams
                    {
                        File = new FileDescription(file.Name, stream)
                    };

                    uploadResult = _cloudinary.Upload(uploadParams);
                }
            }

            photoDto.Url = uploadResult.Uri.ToString();

            photoDto.PublicId = uploadResult.PublicId;

            var photo = _mapper.Map<Photo>(photoDto);

            _photoService.Add(photo);

            if (photo.id > 0)
            {
                var returnPhoto = _mapper.Map<ReturnPhotoDto>(photo);

                return CreatedAtRoute("GetPhoto", new { id = photo.id }, returnPhoto);
            }

            return BadRequest("Could not add the photo!");
        }

        [HttpPost("{id}", Name = "getphoto")]
        public ActionResult GetPhoto(int id)
        {
            var photo = _photoService.FindByID(id);
            var photoDto = _mapper.Map<PhotoDto>(photo);
            return Ok(photoDto);
        }

    }
}