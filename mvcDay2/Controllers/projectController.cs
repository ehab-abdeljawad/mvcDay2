using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using mvcDay2.Models;
using System.Runtime.Intrinsics.Arm;

namespace mvcDay2.Controllers
{
	public class projectController : Controller
	{
		banhacontext context=new();
		public IActionResult Display()
		{
			List<Project> list = context.projects.Include(p=>p.Departments).ToList();
			return View("Display", list);
		}

	  public IActionResult Displayproject(int id)
		{
            Project list = context.projects.Include(p => p.Departments).SingleOrDefault(p=>p.Id == id);


            return View(list);
		}

		public IActionResult Addproject() {
			List<Departments> dept=context.departments.ToList();
		
		return View(dept);
		}

		public IActionResult Addprojectdb(string name,string Location,string city,int dept)
		{
			Project prop = new Project()
			{
				Name = name,
				locations = Location,
				city = city,
				Dno = dept


			};
			context.projects.Add(prop);
			context.SaveChanges();
			return RedirectToAction("Display");

		}

		public IActionResult Editprojectform(int id) {
         
			Project  prop = context.projects.SingleOrDefault(p=>p.Id == id);
            List<Departments> dept = context.departments.ToList();
			ViewBag.Departments = dept;

            return View(prop);
		
		  
		
		
		}

		public IActionResult editprojectdb(int id,string name, string Location, string city, int dept)
		{
			Project prop =context.projects.SingleOrDefault(p=> p.Id == id);
			prop.Name= name;
			prop.locations = Location;
			prop.city = city;
			prop.Dno = dept;
			context.SaveChanges();

            return RedirectToAction("Display");
        }

		public IActionResult Deleteproject(int id)
		{
			Project project = context.projects.SingleOrDefault(m=>m.Id == id);
			context.projects.Remove(project);
			context.SaveChanges();
			return RedirectToAction("Display");
		}
	}
}
