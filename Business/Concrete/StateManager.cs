using AutoMapper;
using Business.Abstract;
using Business.BusinessRules;
using Business.Constants;
using Business.Requests.States;
using Business.Responses.States;
using Core.Utilities.Results;
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

        public IResult Add(CreateStateRequest request)
        {
            State state = _mapper.Map<State>(request);
            _stateBusinessRules.CheckIfStateNotExist(state);
            _stateDal.Add(state);

            return new SuccessResult(Messages.AddedData);
        }

        public IResult Delete(DeleteStateRequest request)
        {
            State state = _mapper.Map<State>(request);
            _stateBusinessRules.CheckIfStateExist(state);
            _stateDal.Delete(state);

            return new SuccessResult(Messages.DeletedData);
        }

        public IDataResult<GetStateResponse> GetById(int id)
        {
            State state = _stateDal.Get(s=>s.Id== id);
            var response = _mapper.Map<GetStateResponse>(state);
            return new SuccessDataResult<GetStateResponse>(response,Messages.ListedData);
        }

        public IDataResult<List<ListStateResponse>> GetList()
        {
            List<State> states = _stateDal.GetAll();
            List<ListStateResponse> responses = _mapper.Map<List<ListStateResponse>>(states);
            return new SuccessDataResult<List<ListStateResponse>>(responses,Messages.ListedData);
        }

        public IResult Update(UpdateStateRequest request)
        {
            State state = _mapper.Map<State>(request);
            _stateBusinessRules.CheckIfStateNotExist(state);
            _stateDal.Update(state);

            return new SuccessResult(Messages.UpdatedData);
        }
    }
}
