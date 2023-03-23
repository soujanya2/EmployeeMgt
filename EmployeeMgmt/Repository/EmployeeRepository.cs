using EmployeeMgmt.Models;
using Microsoft.EntityFrameworkCore;
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

          
 
            if (edb.Employees.Contains(employee))
            {
                
             return false;

                //userfound = true;
               // throw new exceptions.userfoundException("Username found.....Please enter different UserName");
                
            }
            else
            {
                edb.Employees.Add(employee);
                edb.SaveChanges();
                return true;
            }
            
        }
     
        public bool DeleteEmployee(int id)
        { 
            var deluser = edb.Employees.SingleOrDefault(e => e.EmpId == id);
            if (deluser != null)
            {
                edb.Remove(deluser);
                edb.SaveChanges();
                return true;

            }
            return false;   
            //throw new NotImplementedException();   
        }

        public List<Employee> GetAll()
        {
            
            return edb.Employees.ToList();

            //throw new NotImplementedException();

            List<Employee> list = new List<Employee>();
            list = edb.Employees.ToList();
            return list;
        }
        public Employee GetEmployee(Employee id)
        {
            
            Employee emp = new Employee();
            emp=edb.Employees.FirstOrDefault(e => e.Email == id.Email);
                return emp;
            //throw new NotImplementedException();
        }

        public List<Employee> ListbyDept(int id)
        {
            List<Employee> employees= new List<Employee>();
            var emps=edb.Employees.Where(x=>x.DeptId==id);
            foreach(var item in emps)
            {
                employees.Add(item);
            }
            return employees;
          
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

