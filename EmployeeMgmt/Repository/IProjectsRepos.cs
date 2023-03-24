using EmployeeMgmt.Models;
namespace EmployeeMgmt.Repository
{
    public interface IProjectsRepos
    {
        bool AddEmployee(EmployeeProject employeeproj);
        bool DeleteProject(int id);
        List<Employee> GetEmployee(EmployeeProject id);
        List<EmployeeProject> ViewAll();
        bool UpdateProject(EmployeeProject project);
    }
}






