using EmployeeMgmt.Models;
using Microsoft.EntityFrameworkCore;

namespace EmployeeMgmt.Repository
{
    public class ProjectEmpRepos : IProjectsRepos
    {
        private EmployeeMgtContext edb;
        public ProjectEmpRepos(EmployeeMgtContext _edb)
        {
            edb = _edb;
        }
        public bool AddEmployee(EmployeeProject employeeproj)
        {
            EmployeeProject userfound;
            userfound = edb.EmployeeProjects.FirstOrDefault(e => e.ProjId == employeeproj.ProjId);
            if (edb.EmployeeProjects.Contains(userfound))
            {
                return false;
            }
            else
            {
                edb.EmployeeProjects.Add(employeeproj);
                edb.SaveChanges();
                return true;
            }
        }
        public List<EmployeeProject> ViewAll()

        {

            var emp = edb.EmployeeProjects.Include(x => x.EmpemailNavigation);

            var proj = emp.Include(y => y.Proj);

            return proj.ToList();

        }

        public bool DeleteProject(int id)

        {

            var delproj = edb.EmployeeProjects.SingleOrDefault(e => e.ProjId == id);

            if (delproj != null)

            {

                edb.Remove(delproj);

                edb.SaveChanges();

                return true;



            }

            return false;

            throw new NotImplementedException();

        }



        public List<Employee> GetEmployee(EmployeeProject id)

        {

            List<Employee> emp = new List<Employee>();

            emp = edb.Employees.ToList();

            List<Employee> list = new List<Employee>();

            //var ee = edb.EmployeeProjects.Where(e => e.ProjId == id.ProjId).Include(emp ,x=>x.Epid==emp.EmpId);

            //foreach (var e in ee)

            //{

            //    ee.Empmail

            //}

            //foreach (var item in ee)

            //{



            //    AddEmployee(item);

            //}


            return list;

        }



        public bool UpdateProject(EmployeeProject project)

        {

            throw new NotImplementedException();

        }

    }

}






