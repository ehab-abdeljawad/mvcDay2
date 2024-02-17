using Microsoft.AspNetCore.Mvc;
using mvcDay2.Models;
using mvcDay2.viewmodel;

namespace mvcDay2.Controllers
{
    public class employeeController : Controller
    {
        private banhacontext banhacontext;
        public employeeController() {
            banhacontext = new banhacontext();


        }
        public IActionResult Index()
        {
            string name = "ehab abdo";
            //ViewData["name"] = name;
            List<Departments> d = banhacontext.departments.ToList();
            //ViewData["dept"] = d;

            //ViewBag.Name = name;
            //ViewBag.Departments = d;

            List<employee> employee = banhacontext.employees.ToList();

            employeedeptmodelview emp = new();
            emp.employees = employee;
            emp.Departments = d;    
            emp.name = name;


            return View(emp);

        }

        public IActionResult datiels(int id)
        {
            employee employee = banhacontext.employees.SingleOrDefault(e => e.Ssn == id);
            return View("datiels",employee);
        }

        public IActionResult showloginform()
        {
            return View();
        }

        public IActionResult checklogin(employee em)
        {
            employee emp = banhacontext.employees.SingleOrDefault(s=>s.Ssn == em.Ssn && s.fname == em.fname);
            if(emp != null)
            {
                HttpContext.Session.SetString("username", emp.fname);
                HttpContext.Session.SetInt32("id", emp.Ssn);
                return RedirectToAction("Index");
            }
            else
            {
                return RedirectToAction("showloginform");
            }
        }

        public IActionResult logout() { 
        
           HttpContext.Session.Clear();

			return RedirectToAction("showloginform");
		}

        
    }
}
