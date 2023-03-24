using EmployeeMgmt.Models;

namespace EmployeeMgmt.Repository
{
    public interface IEmployeeRepos
    {
        List<Employee> GetAll();

        bool AddEmployee(Employee employee);

        bool DeleteEmployee(string id);

        Employee GetEmployee(string email);

        bool UpdateEmployee(Employee employee);

        List<Employee> ListbyDept(Department id);

        Employee GetEmp(string email);
    }
}
