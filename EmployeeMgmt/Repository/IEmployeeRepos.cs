using EmployeeMgmt.Models;

namespace EmployeeMgmt.Repository
{
    public interface IEmployeeRepos
    {
        List<Employee> GetAll();

        bool AddEmployee(Employee employee);

        bool DeleteEmployee(int Empid);

        Employee GetEmployee(int Empid);

        bool UpdateEmployee(Employee employee);

        List<Employee> ListbyDept(int id);


    }
}
