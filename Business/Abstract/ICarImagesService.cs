using Core.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface ICarImagesService
    {
        IResult Add(CarImages carImages);
        IResult Delete(CarImages carImages);
        IResult Update(CarImages carImages);
        IDataResult<List<CarImages>> GetAll();
        IDataResult<CarImages> GetById(int id);
    }
}
