using Microsoft.AspNetCore.Mvc;
using ExpenseManagement.Datalayer;
using ExpenseManagement.Models;
using Microsoft.Identity.Client;

namespace ExpenseManagement.Controllers
{
    public class UserProfileController : Controller
    {
        public readonly DBcontextExpenseMgt _context;

        public UserProfileController(DBcontextExpenseMgt context)
        {
            _context = context;
        }
        public IActionResult Login( string EmailAddress,String Password)
        {
            ViewBag.LoginStatus = "";
            if (ModelState.IsValid)
            {
                var userCheck=_context.UserProfile.FirstOrDefault
                    (a => a.EmailAddress == EmailAddress && a.Password == Password); 
                
                if(userCheck == null)
                {
                    ViewBag.LoginStatus = "Invalid Login User Not found";
                }
                else
                {
                    return RedirectToAction("index", "Home");
                }
            }
            return View();
        }

        public IActionResult Registration(UserProfile userDetails)
        {
           
            if (ModelState.IsValid)
            {
                _context.UserProfile.Add(userDetails);
                _context.SaveChanges();
                return RedirectToAction("Login");
            }
            return View();
        }

        public IActionResult Index()
        {
        
            return View();
        }
    }
}
