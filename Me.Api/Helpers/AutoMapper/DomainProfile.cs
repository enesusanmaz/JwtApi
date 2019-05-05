using AutoMapper;
using Me.Dto.DataTransferObjects;
using Me.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Me.Api.Helpers.AutoMapper
{
    public class DomainProfile : Profile
    {
        public DomainProfile()
        {
            CreateMap<Photo, PhotoDto>();
            CreateMap<ReturnPhotoDto, Photo>();
        }
    }
}
