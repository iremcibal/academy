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
    public class EmployeeBusinessRules
    {
        IEmployeeDal _employeeDal;
        public EmployeeBusinessRules(IEmployeeDal employeeDal)
        {
            this._employeeDal = employeeDal;
        }
        public void CheckIfEmployeeNotExist(Employee? employee)
        {
            if (employee == null) throw new BusinessException(Messages.EmployeeNotBeExist);
        }
        public void CheckIfEmployeeExist(Employee? employee)
        {
            if (employee != null) throw new BusinessException(Messages.EmployeeAlreadyExist);
        }
        public void CheckIfEmployeeNotExist(int employeeId)
        {
            Employee employee= _employeeDal.Get(e=>e.Id==employeeId);
            CheckIfEmployeeNotExist(employee);
        }
        public void CheckIfEmployeePositionNotExist(string position)
        {
            Employee employee = _employeeDal.Get(e => e.Position == position);
            CheckIfEmployeeExist(employee);
        }


    }
}
