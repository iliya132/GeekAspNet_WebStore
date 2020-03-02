using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebStore.Domain.ViewModels;

namespace WebStore.Models.Interfaces
{
    public interface IEmployeeDataProvider
    {
        IEnumerable<EmployeeViewModel> GetAll();
        EmployeeViewModel GetById(int id);
        void Commit();
        void AddNew(EmployeeViewModel employee);
        void Delete(int id);
        EmployeeViewModel UpdateEmployee(int id, EmployeeViewModel entity);

    }
}
