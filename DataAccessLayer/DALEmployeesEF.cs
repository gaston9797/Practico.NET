using Shared.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class DALEmployeesEF : IDALEmployees
    {
        public void AddEmployee(Employee emp)
        {
            using (Model.Entity en = new Model.Entity())
            {
                if (emp.GetType() == typeof(Shared.Entities.FullTimeEmployee))
                {
                    FullTimeEmployee em = (FullTimeEmployee)emp;
                    Model.FullTimeEmployee e = new Model.FullTimeEmployee();
                    e.EmployeeId = em.Id;
                    e.Name = em.Name;
                    e.StartDate = em.StartDate;
                    e.Salary = em.Salary;
                    en.Employees.Add(e);
                    en.SaveChanges();
                }
                else {
                    PartTimeEmployee em = (PartTimeEmployee)emp;
                    Model.PartTimeEmployee e = new Model.PartTimeEmployee();
                    e.EmployeeId = em.Id;
                    e.Name = em.Name;
                    e.StartDate = em.StartDate;
                    e.HourlyRate = em.HourlyRate;
                    en.Employees.Add(e);
                    en.SaveChanges();
                }
            }
        }

        public void DeleteEmployee(int id)
        {
            using (Model.Entity en = new Model.Entity())
            {
                en.Employees.Remove(en.Employees.Find(id));
                en.SaveChanges();
            }
        }

        public void UpdateEmployee(Employee emp)
        {
            using (Model.Entity en = new Model.Entity()) {
                if (emp.GetType() == typeof(Shared.Entities.FullTimeEmployee))
                {
                    Model.FullTimeEmployee e = (Model.FullTimeEmployee)en.Employees.Find(emp.Id);
                    FullTimeEmployee em = (FullTimeEmployee)emp;
                    e.EmployeeId = em.Id;
                    e.Name = em.Name;
                    e.StartDate = em.StartDate;
                    e.Salary = em.Salary;
                    en.SaveChanges();
                }
                else {
                    Model.PartTimeEmployee e = (Model.PartTimeEmployee)en.Employees.Find(emp.Id);
                    PartTimeEmployee em = (PartTimeEmployee)emp;
                    e.EmployeeId = em.Id;
                    e.Name = em.Name;
                    e.StartDate = em.StartDate;
                    e.HourlyRate = em.HourlyRate;
                    en.SaveChanges();
                }
            }
        }

        public List<Employee> GetAllEmployees()
        {
            List<Employee> result = new List<Employee>();
            using (Model.Entity en = new Model.Entity())
            {
                en.Employees.ToList().ForEach(x => {
                    if (x.GetType() == typeof(Model.FullTimeEmployee))
                    {
                        Model.FullTimeEmployee e = (Model.FullTimeEmployee)x;
                        result.Add(
                            new FullTimeEmployee()
                            {
                                Id = e.EmployeeId,
                                Name = e.Name,
                                StartDate = e.StartDate,
                                Salary = e.Salary
                            }
                        );
                    }
                    else
                    {
                        Model.PartTimeEmployee e = (Model.PartTimeEmployee)x;
                        result.Add(
                            new PartTimeEmployee()
                            {
                                Id = e.EmployeeId,
                                Name = e.Name,
                                StartDate = e.StartDate,
                                HourlyRate = e.HourlyRate
                            }
                        );
                    }
                });
            }
            return result;
        }

        public Employee GetEmployee(int id)
        {
            using (Model.Entity en = new Model.Entity()) {
                Model.Employee e = en.Employees.Find(id);
                if (e.GetType() == typeof(Model.FullTimeEmployee)) {
                    Model.FullTimeEmployee em = (Model.FullTimeEmployee) e;
                    return new FullTimeEmployee() {
                        Id = em.EmployeeId,
                        Name = em.Name,
                        StartDate = em.StartDate,
                        Salary = em.Salary
                    };
                }
                else {
                    Model.PartTimeEmployee em = (Model.PartTimeEmployee) e;
                    return new PartTimeEmployee()
                    {
                        Id = em.EmployeeId,
                        Name = em.Name,
                        StartDate = em.StartDate,
                        HourlyRate = em.HourlyRate
                    };
                }
            }
        }
    }
}
