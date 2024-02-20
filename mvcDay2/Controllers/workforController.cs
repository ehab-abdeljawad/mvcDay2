using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using mvcDay2.Migrations;
using mvcDay2.Models;
using mvcDay2.viewmodel;

namespace mvcDay2.Controllers
{
   
    public class workforController : Controller
	{
		banhacontext context = new banhacontext();
		public IActionResult showhours()
		{
			var hours = context.work_Fors.Include(w=>w.Project).Include(w=>w.employee).ToList();
            var viewproject = hours.Select(h =>
            {
                var color = h.Houres > 50 ? "green" : "red";
                return new WorkForViewModel { Color = color, fname = h.employee.fname,lname = h.employee.lname,hours=h.Houres };
            });

           ViewBag.hours = viewproject;

            return View();
		}


        public IActionResult detailshours(int id)
        {

            var hours = context.work_Fors.Include(w => w.Project).Include(w => w.employee).Where(e=>e.employee.Ssn == id).ToList();
            List<string> colors = new List<string>();
            string name = "";
            foreach (var h in hours)
            {
                name = h.employee.fname + " "+h.employee.lname;
                if (h.Houres > 50)
                {
                    colors.Add("green");
                }
                else
                {
                    colors.Add("red");

                }
            }
            ;
            ViewBag.name = name;
            ViewBag.hours = colors;
            return View(hours);

        }


         public IActionResult emp_proj(int id)
        {

            employee emp = context.employees.Where(e=>e.Ssn == id).SingleOrDefault();
             List<Project> projects = context.work_Fors.Include(w => w.Project).Where(e => e.employee.Ssn == id).Select(p=>p.Project).ToList();
               
            ViewBag.projects = projects;
            ViewBag.name = emp;
            return View();


        }

        public IActionResult gethoures(int id,int id2)
        {
            Work_for  houres = context.work_Fors.Where(h=>h.eSsn == id2 && h.pno == id).SingleOrDefault();
            return PartialView("_hourepartial", houres);
        }


	}
}
