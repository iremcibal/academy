using Business.Requests.Images;
using Business.Responses.Images;
using Core.Utilities.Results;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IImageService
    { 
        IResult Add(IFormFile file);
        IResult Update(IFormFile file, Image image);
        IResult Delete(DeleteImageRequest request);
        IDataResult<List<ListImageResponse>> GetAll();
        IDataResult<GetImageResponse> GetByImageId(int imageId);
    }

    

   

    
}
