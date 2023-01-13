using Business.Requests.Blacklists;
using Business.Responses.Blacklists;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IBlacklistService
    {
        GetBlacklistResponse GetById(int id);
        List<ListBlacklistResponse> GetList();
        void Add(CreateBlacklistRequest request);
        void Delete(DeleteBlacklistRequest request);
        void Update(UpdateBlacklistRequest request);
    }
}
