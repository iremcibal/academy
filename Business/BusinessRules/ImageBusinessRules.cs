using Business.Constants;
using Core.Business.Exceptions;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.BusinessRules
{
    public class ImageBusinessRules
    {
        IImageDal _imageDal;
        public ImageBusinessRules(IImageDal ImageDal)
        {
            _imageDal = ImageDal;
        }
        public void CheckIfImageNotExist(Image? image)
        {
            if (image == null) throw new BusinessException(Messages.NotBeExist);

        }

        public void CheckIfImageExist(Image? image)
        {
            if (image != null) throw new BusinessException(Messages.AlreadyExist);
        }

        public void CheckIfImageNotExist(int carImageId)
        {
            Image carImage = _imageDal.Get(a => a.Id == carImageId);
            CheckIfImageNotExist(carImageId);
        }

    }
}
