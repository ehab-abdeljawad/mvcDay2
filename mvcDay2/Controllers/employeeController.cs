using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
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
        //get the page view form
        [HttpGet]
        public IActionResult addform()
        {
            employeevaild emp = new employeevaild()
            {
                departments = new SelectList(banhacontext.departments, nameof(Departments.Dnum), nameof(Departments.Dname))
                

            };
            
            return View(emp);
        }
        
        [HttpPost]
       
        [ValidateAntiForgeryToken]
        public IActionResult addform(employeevaild emp)
        {
            if (ModelState.IsValid)
            {
                employee employee = new employee();
                
                employee.fname = emp.fname;
                employee.lname = emp.lname;
                employee.address = emp.address;
                employee.Dno = emp.Dno;
                employee.salary = emp.salary;
                employee.sex = emp.sex;
                employee.superid = emp.superid;
                employee.Bdate = emp.Bdate;
                 
                banhacontext.employees.Add(employee);
                banhacontext.SaveChanges();

                return RedirectToAction("Index");
            }
            List<Departments> dept = banhacontext.departments.ToList();
            emp.departments = new SelectList(dept, "Dnum", "Dname");
            
            return View(emp);
        }

    }
}
