using EmployeeMgmt.Models;

namespace EmployeeMgmt.Repository
{
    public interface IEmployeeRepos
    {
        List<Employee> GetAll();

        bool AddEmployee(Employee employee);

        bool DeleteEmployee(string Email);

        Employee GetEmployee(int id);

        bool UpdateEmployee(Employee employee);

        List<Employee> ListbyDept(int id);


    }
}
