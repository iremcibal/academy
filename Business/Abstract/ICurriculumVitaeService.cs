using Business.Requests.Bootcamps;
using Business.Requests.CurriculumVitae;
using Business.Responses.Bootcamps;
using Business.Responses.CurriculumVitae;
using Core.Utilities.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface ICurriculumVitaeService
    {
        IDataResult<GetCurriculumVitaeResponse> GetById(int id);
        IDataResult<List<ListCurriculumVitaeResponse>> GetAll();
        IResult Add(CreateCurriculumVitaeRequest request);
        IResult Delete(DeleteCurriculumVitaeRequest request);
        IResult Update(UpdateCurriculumVitaeRequest request);
    }
}
