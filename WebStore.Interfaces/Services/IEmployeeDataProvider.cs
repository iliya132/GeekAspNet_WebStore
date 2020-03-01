using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebStore.Models.Interfaces
{
    public interface IEmployeeDataProvider
    {
        IEnumerable<Employee> GetAll();
        Employee GetById(int id);
        void Commit();
        void AddNew(Employee employee);
        void Delete(int id);

    }
}
