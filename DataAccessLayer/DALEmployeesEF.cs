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
            throw new NotImplementedException();
        }

        public void DeleteEmployee(int id)
        {
            throw new NotImplementedException();
        }

        public void UpdateEmployee(Employee emp)
        {
            throw new NotImplementedException();
        }

        public List<Employee> GetAllEmployees()
        {
            List<Employee> result = new List<Employee>();
            using (Model.Entity en = new Model.Entity())
            {
                en.EmployeesTPH.ToList().ForEach(x => {
                    if (x.GetType().Equals("FullTimeEmployye"))
                    {
                        result.Add(
                            new FullTimeEmployee() {
                                Id = x.EmployeeId,
                                Name = x.Name,
                                StartDate = x.StartDate
                            }
                        );
                    }
                    else
                    {
                        result.Add(
                            new PartTimeEmployee()
                            {
                                Id = x.EmployeeId,
                                Name = x.Name,
                                StartDate = x.StartDate
                            }
                        );
                    }
                });
            }
            return result;
        }

        public Employee GetEmployee(int id)
        {
            throw new NotImplementedException();
        }
    }
}
