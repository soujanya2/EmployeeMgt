using EmployeeMgmt.Models;
using System;
using System.ComponentModel.Design;

namespace EmployeeMgmt.Repository
{
    public class EmployeeRepository : IEmployeeRepos
    {
        private EmployeeMgtContext edb;

        public EmployeeRepository(EmployeeMgtContext _edb)
        {
            edb = _edb;
        }

        public bool AddEmployee(Employee employee)
        {
            bool userfound;


            if (edb.Employees.Contains(employee))
            {
                userfound = true;
               // throw new exceptions.userfoundException("Username found.....Please enter different UserName");
               return false;

            }

            else
            {
                edb.Employees.Add(employee);
                edb.SaveChanges();
                Console.WriteLine("user added successfully");
                return true;
            }
            throw new NotImplementedException();
        }

        public bool DeleteEmployee()
        {
            throw new NotImplementedException();
        }

        public List<Employee> GetAll()
        {
            throw new NotImplementedException();
        }

        public Employee GetEmployee(int id)
        {
            throw new NotImplementedException();
        }

        public List<Employee> ListbyDept(int id)
        {
            throw new NotImplementedException();
        }

        public bool UpdateEmployee(Employee employee)
        {
            throw new NotImplementedException();
        }
    }
}
