using Microsoft.AspNetCore.Mvc;

namespace mvcDay2.Controllers
{
    public class testController : Controller
    {
        public IActionResult setdata()
        {
            string user_name = "ehab_abdo";
            int id = 1;
            //TempData["name"]=user_name;
            //TempData["id"]=id;
            //return Content("data is set");
            //CookieOptions op =new CookieOptions()
            //{
            //    Expires = DateTime.Now.AddMinutes(3),
            //};
            //HttpContext.Response.Cookies.Append("name", user_name,op);
            //HttpContext.Response.Cookies.Append("id", "123456",op);
            HttpContext.Session.SetString("user_name", user_name);
            HttpContext.Session.SetInt32("user_id", id);
            return Content("data is set in cookies");
        }

        public IActionResult getdata()
        {
            string? username = HttpContext.Session.GetString("user_name");
            int? id = HttpContext.Session.GetInt32("user_id");

            return Content($"id : {id} , user_name : {username}");

        }

        public IActionResult savedata() {
            HttpContext.Response.Cookies.Delete("id");
            return Content("delete cookies");

        }
    }
}
