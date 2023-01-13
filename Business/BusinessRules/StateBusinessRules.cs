using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.BusinessRules
{
    public class StateBusinessRules
    {
        IStateDal _stateDal;
        public StateBusinessRules(IStateDal stateDal)
        {
            this._stateDal = stateDal;
        }
        public void CheckIfStateNotExist(State? state)
        {
            if (state == null) throw new Exception("State not be exist");
        }
        public void CheckIfStateExist(State? state)
        {
            if (state != null) throw new Exception("State already exist");
        }
        public void CheckIfStateNotExist(int stateId)
        {
            State state = _stateDal.Get(s=>s.Id== stateId);
            CheckIfStateNotExist(state);
        }


    }
}
