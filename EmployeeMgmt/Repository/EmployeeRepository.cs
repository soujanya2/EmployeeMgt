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
                return true;
            }
            throw new NotImplementedException();
        }
        public bool DeleteEmployee(string EmpEmail)
        {
            Employee deluser = new Employee();

            deluser = edb.Employees.FirstOrDefault(e => e.Email == EmpEmail);
            if (deluser != null)
            {

                edb.Remove(deluser);
                edb.SaveChanges();
                return true;

            }       
            throw new NotImplementedException();   
        }

        public List<Employee> GetAll()
        {
            List<Employee> list = new List<Employee>();
            list=edb.Employees.ToList();
            return list;
        
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
            var emp=edb.Employees.SingleOrDefault(e=>e.Email== employee.Email);
            if(edb.Employees.Contains(employee))
            {
                edb.Employees.Update(employee);
                edb.SaveChanges();
                return true;
            }
            return false;
            //throw new NotImplementedException();
        }
    }
}
