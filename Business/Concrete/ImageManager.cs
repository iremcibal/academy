using AutoMapper;
using Business.Abstract;
using Business.BusinessRules;
using Business.Constants;
using Business.Requests.Images;
using Business.Responses.Images;
using Core.Utilities.Helpers.FileHelper;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class ImageManager : IImageService
    {
        IImageDal _imageDal;
        IFileHelper _fileHelper;
        ImageBusinessRules _imageBusinessRules;
        IMapper _mapper;
        public ImageManager(IImageDal carImageDal, ImageBusinessRules carImageBusinessRules, IMapper mapper, IFileHelper fileHelper)
        {
            _imageDal = carImageDal;
            _imageBusinessRules = carImageBusinessRules;
            _mapper = mapper;
            _fileHelper = fileHelper;
        }

        public IResult Add(IFormFile file)
        {
            Image image = new Image();
            image.ImagePath = _fileHelper.Upload(file, PathConstants.ImagesPath);
            image.Date = DateTime.Now;
            _imageDal.Add(image);
            return new SuccessResult(Messages.AddedData);
        }

        public IResult Delete(DeleteImageRequest request)
        {
            _fileHelper.Delete(PathConstants.ImagesPath + request.ImagePath);
            Image carImage = _mapper.Map<Image>(request);
            _imageDal.Delete(carImage);
            return new SuccessResult(Messages.DeletedData);
        }

        public IDataResult<List<ListImageResponse>> GetAll()
        {
            List<Image> carimages = _imageDal.GetAll();
            List<ListImageResponse> responses = _mapper.Map<List<ListImageResponse>>(carimages);
            return new SuccessDataResult<List<ListImageResponse>>(responses);
        }

        public IDataResult<GetImageResponse> GetByImageId(int imageId)
        {
            Image carImage = _imageDal.Get(ci => ci.Id == imageId);
            GetImageResponse response = _mapper.Map<GetImageResponse>(carImage);
            return new SuccessDataResult<GetImageResponse>(response, Messages.ListedData);
        }

        public IResult Update(IFormFile file, Image image)
        {
            _fileHelper.Update(file, PathConstants.ImagesPath + image.ImagePath, PathConstants.ImagesPath);
            _imageDal.Update(image);
            return new SuccessResult(Messages.UpdatedData);
        }
    }
}
