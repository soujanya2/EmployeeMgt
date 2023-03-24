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
            Employee userfound;
            userfound=edb.Employees.FirstOrDefault(e => e.Email == employee.Email);
            if (edb.Employees.Contains(employee))
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
            var emp = edb.Employees.Include(x => x.Dept);
            return emp.ToList();
        }

        public Employee GetEmp(string email)
        {
            //Employee ee = new Employee();
            //var emp = edb.Employees.Include(x => x.Dept);
            var ee =edb.Employees.FirstOrDefault(e => e.Email == email);
            return ee;
         //   throw new NotImplementedException();
        }

        public Employee GetEmployee(Employee id)
        {
            Employee emp = new Employee();
         
            emp=edb.Employees.FirstOrDefault(e => e.DeptId == id.DeptId);
                return emp;
            //throw new NotImplementedException();
        }

        public List<Employee> ListbyDept(Department id)
        {
            List<Employee> employees= new List<Employee>();
            Department dd = new Department();
            dd = edb.Departments.FirstOrDefault(e => e.Deptname == id.Deptname);
            var deptemp = edb.Employees.Include(a => a.Dept);
            var emps =deptemp.Where(x => x.DeptId == dd.Deptid);
            foreach (var item in emps)
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
                emp.Age = employee.Age;
                emp.Role=employee.Role;
                emp.Salary=employee.Salary;
                emp.Phoneno=employee.Phoneno;
                emp.Manager=employee.Manager;
                emp.DeptId=employee.DeptId;
                edb.SaveChanges();
                return true;
            }
            return false;
            //throw new NotImplementedException();
        }
    }
}

