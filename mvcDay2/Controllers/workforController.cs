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


	}
}
