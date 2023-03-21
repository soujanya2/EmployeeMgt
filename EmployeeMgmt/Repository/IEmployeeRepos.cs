using EmployeeMgmt.Models;

namespace EmployeeMgmt.Repository
{
    public interface IEmployeeRepos
    {
        List<Employee> GetAll();

        bool AddEmployee(Employee employee);

        bool DeleteEmployee(int id);

        Employee GetEmployee(string email);

        bool UpdateEmployee(Employee employee);

        List<Employee> ListbyDept(int id);


    }
}
