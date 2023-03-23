using EmployeeMgmt.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
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
            //bool userfound;
            if (edb.Employees.Contains(employee))
            {
                //userfound = true;
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
        public bool DeleteEmployee(string id)
        { 
            var deluser = edb.Employees.SingleOrDefault(e => e.Email == id);
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
            List<Employee> list = new List<Employee>();
            list = edb.Employees.ToList();
            return list;
        }
        public Employee GetEmployee(Employee id)
        {
            var emp=edb.Employees.SingleOrDefault(x=>x.Email== id.Email);
            return emp;
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
