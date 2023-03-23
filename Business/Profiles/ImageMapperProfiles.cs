using AutoMapper;
using Business.Requests.Images;
using Business.Responses.Images;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Profiles
{
    public class ImageMapperProfiles : Profile
    {
        public ImageMapperProfiles()
        {
            CreateMap<DeleteImageRequest, Image>();
            CreateMap<Image, ListImageResponse>();
            CreateMap<Image, GetImageResponse>();
        }
    }
}
