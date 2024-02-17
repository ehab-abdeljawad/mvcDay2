using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using mvcDay2.Models;

namespace mvcDay2.Controllers
{
    public class departmentController : Controller
    {
        banhacontext context = new banhacontext();
        
        public IActionResult Index()
        {
            List<Departments> departments = context.departments.Include(d=>d.mangeemp).ToList();
            return View(departments);
        }

        public IActionResult addform()
        {
           


            List<employee> mangers = context.departments.Include(d => d.mangeemp).Select(d => d.mangeemp).ToList();

            //List<employee> restEmps = context.employees.Except(mangers).ToList();
            List<employee> restEmps = context.employees.Where(e => !mangers.Contains(e)).ToList();


            ViewBag.mangeemp = restEmps;


            return View();
        }


        public IActionResult add(Departments dept) {
            
            
            
                context.departments.Add(dept);
                context.SaveChanges();
                return RedirectToAction("Index");
            
            
        }

        public IActionResult editform(int id) {

            List<employee> mangers = context.departments.Include(d => d.mangeemp).Where(d=>d.Dnum!=id).Select(d => d.mangeemp).ToList();

           
            List<employee> restEmps = context.employees.Where(e => !mangers.Contains(e)).ToList();
            Departments dept = context.departments.SingleOrDefault(d=>d.Dnum == id);

             
            ViewBag.mangeemp = restEmps;

            


            return View(dept);

        }

        public IActionResult edit(Departments dept) { 
            context.departments.Update(dept);
            context.SaveChanges(true);
            return RedirectToAction("Index");
        
        }

        public IActionResult delete(int id)
        {
            Departments dept = context.departments.SingleOrDefault(d=>d.Dnum == id);
            context.departments.Remove(dept);
            context.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}
