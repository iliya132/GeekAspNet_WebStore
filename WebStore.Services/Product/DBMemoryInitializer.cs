using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebStore.Domain.ViewModels;

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

        public IEnumerable<EmployeeViewModel> GetAll() => Employees.Select(i=>new EmployeeViewModel()
        {
            FirstName=i.FirstName,
            Id = i.Id,
            LastName = i.LastName,
            Patronymic = i.Patronymic
        });

        public EmployeeViewModel GetById(int id) => Employees.Select(i => new EmployeeViewModel()
        {
            FirstName = i.FirstName,
            Id = i.Id,
            LastName = i.LastName,
            Patronymic = i.Patronymic
        }).FirstOrDefault(i => i.Id == id);

        public void Commit()
        {
        }

        public void AddNew(EmployeeViewModel employee) => Employees.Add(new Employee() {
            Patronymic=employee.Patronymic,
            LastName=employee.LastName,
            Id=employee.Id,
            FirstName=employee.FirstName});


        public void Delete(int id)
        {
            if (Employees.Any(i => i.Id == id))
            {
                Employees.Remove(
                    Employees.
                        First(i => i.Id == id));
            }
        }

        public EmployeeViewModel UpdateEmployee(int id, EmployeeViewModel entity)
        {

            if (Employees.Any(i => i.Id == id))
            {
                Employee employee = Employees.FirstOrDefault(i => i.Id == id);
                employee.FirstName = entity.FirstName;
                employee.LastName = entity.LastName;
                employee.Patronymic = entity.Patronymic;
                return new EmployeeViewModel()
                {

                    FirstName = employee.FirstName,
                    LastName = employee.LastName,
                    Patronymic = employee.Patronymic
                };
            }
            else
            {
                throw new Exception($"Сотрудник с Id {id} не найден");
            }

        }
    }
}
