using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class EmpController : Controller
    {
        public IActionResult Index()
        {
            Employee empobj1 = new Employee() { Empno =101,Ename="Saikumar",Job="Developer",Salary=50000,Deptno=10 };
            Employee empobj2 = new Employee() { Empno = 101, Ename = "Jaswanth", Job = "Analyst", Salary = 70000, Deptno = 10 };
            Employee empobj3 = new Employee() { Empno = 101, Ename = "Satish", Job = "Web-Developer", Salary = 60000, Deptno = 10 };
            Employee empobj4 = new Employee() { Empno = 101, Ename = "Vinod", Job = "Android-Developer", Salary = 65000, Deptno = 10 };
            List<Employee> empList = new List<Employee>();
            empList.Add(empobj1);
            empList.Add(empobj2);
            empList.Add(empobj3);
            empList.Add(empobj4);
            return View(empList);
        }
    }
}
