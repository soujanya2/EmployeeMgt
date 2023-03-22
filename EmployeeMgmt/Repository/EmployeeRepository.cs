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
            Employee userfound;
            userfound=edb.Employees.FirstOrDefault(e => e.Email == employee.Email);

            if (userfound!=null)
            {
                
             return false;

            }
            else
            {
                edb.Employees.Add(employee);
                edb.SaveChanges();
                return true;
            }
            
        }
        public bool DeleteEmployee(int Emid)
        {
            Employee deluser = new Employee();

            deluser = edb.Employees.FirstOrDefault(e => e.EmpId == Emid);
            if (deluser != null)
            {

                edb.Remove(deluser);
                edb.SaveChanges();
                return true;

            }
            return false;   
        }

        public List<Employee> GetAll()
        {
            
            return edb.Employees.ToList();

            //throw new NotImplementedException();

        }

        public Employee GetEmployee(int id)
        {
            
            Employee EmpFound =new Employee();
            EmpFound = edb.Employees.FirstOrDefault(e => e.EmpId == id);
            if (EmpFound != null)
            {
                return EmpFound;
            }
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
