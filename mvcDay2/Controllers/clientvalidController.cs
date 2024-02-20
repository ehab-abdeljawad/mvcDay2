using Microsoft.AspNetCore.Mvc;

namespace mvcDay2.Controllers
{
    public class clientvalidController : Controller
    {
        public IActionResult check(decimal sal)
        {
           if (sal < 10000 || sal > 20000) {

                return Json(false);
            }
            else
            {
                return Json(true);
            }
        }
    }
}
