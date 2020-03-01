using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebStore.Models
{
    public class InMemoryEmployeeService: Interfaces.IEmployeeDataProvider
    {
        private List<Employee> Employees { get; set; }
        public InMemoryEmployeeService()
        {
            Employees = new List<Employee>();
            Employees.Add(new Employee() { FirstName = "Илья", LastName = "Лебедев", Patronymic = "Викторович", Id=1 });
            Employees.Add(new Employee() { FirstName = "Светлана", LastName = "Лебедева", Patronymic = "Андреевна", Id=2 });
        }

        public IEnumerable<Employee> GetAll() => Employees;

        public Employee GetById(int id) => Employees.FirstOrDefault(i => i.Id == id);

        public void Commit()
        {
        }

        public void AddNew(Employee employee) => Employees.Add(employee);


        public void Delete(int id)
        {
            if (Employees.Any(i => i.Id == id))
            {
                Employees.Remove(
                    Employees.
                        First(i => i.Id == id));
            }
        }
    }
}
