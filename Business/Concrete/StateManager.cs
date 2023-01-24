using AutoMapper;
using Business.Abstract;
using Business.BusinessRules;
using Business.Requests.States;
using Business.Responses.States;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class StateManager : IStateService
    {
        IStateDal _stateDal;
        IMapper _mapper;
        StateBusinessRules _stateBusinessRules;
        public StateManager(IStateDal stateDal, IMapper mapper, StateBusinessRules stateBusinessRules)
        {
            _stateDal = stateDal;
            _mapper = mapper;
            _stateBusinessRules = stateBusinessRules;
        }

        public void Add(CreateStateRequest request)
        {
            State state = _mapper.Map<State>(request);
            _stateBusinessRules.CheckIfStateNotExist(state);
            _stateDal.Add(state);
        }

        public void Delete(DeleteStateRequest request)
        {
            State state = _mapper.Map<State>(request);
            _stateBusinessRules.CheckIfStateExist(state);
            _stateDal.Delete(state);
        }

        public GetStateResponse GetById(int id)
        {
            State state = _stateDal.Get(s=>s.Id== id);
            var response = _mapper.Map<GetStateResponse>(state);
            return response;
        }

        public List<ListStateResponse> GetList()
        {
            List<State> states = _stateDal.GetAll();
            List<ListStateResponse> responses = _mapper.Map<List<ListStateResponse>>(states);
            return responses;
        }

        public void Update(UpdateStateRequest request)
        {
            State state = _mapper.Map<State>(request);
            _stateBusinessRules.CheckIfStateNotExist(state);
            _stateDal.Update(state);
        }
    }
}
