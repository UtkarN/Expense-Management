using Microsoft.AspNetCore.Mvc;
using ExpenseManagement.Datalayer;
using Microsoft.Identity.Client;
using ExpenseManagement.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ExpenseManagement.Controllers
{
    public class ExpenseController : Controller
    {
        public readonly DBcontextExpenseMgt _context;

        public ExpenseController(DBcontextExpenseMgt context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            IEnumerable<ExpenseEntity> expensesList = _context.Expenses.ToList();
            foreach(var obj in expensesList)
            {
                obj.ExpenseCategory = _context.ExpenseCategory.FirstOrDefault
                    (u => u.ExpenseCategoryId == obj.ExpenseCategoryId);
            }

            return View(expensesList);
        }

        public IActionResult Create(ExpenseEntity expenseDetails)
        {

            IEnumerable<SelectListItem> getExpenseCategoryList = _context.ExpenseCategory.Select(i => new SelectListItem
            {
                Text = i.ExpenseCategoryname,
                Value=i.ExpenseCategoryId.ToString()
            }) ;

            ViewBag.PopulateExpCategory = getExpenseCategoryList;
            

            if (ModelState.IsValid)
            {
                _context.Expenses.Add(expenseDetails);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();
        }
        public IActionResult GetExpenseDetailsForUpdate(int ? Id)
        {
            IEnumerable<SelectListItem> getExpenseCategoryList = _context.ExpenseCategory.Select(i => new SelectListItem
            {
                Text = i.ExpenseCategoryname,
                Value = i.ExpenseCategoryId.ToString()
            });

            ViewBag.PopulateExpCategory = getExpenseCategoryList;

            var _ExpenseDetails = _context.Expenses.Find(Id);

            if(_ExpenseDetails==null)
            {
                return NotFound();  
            }
            
            return View(_ExpenseDetails);
        }
        [HttpPost]
        public IActionResult Update(ExpenseEntity expenseDetails)
        {
            if (ModelState.IsValid)
            {
                _context.Expenses.Update(expenseDetails);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();
        }

        public IActionResult GetExpenseDetailsForDelete(int? Id)
        {
            IEnumerable<SelectListItem> getExpenseCategoryList = _context.ExpenseCategory.Select(i => new SelectListItem
            {
                Text = i.ExpenseCategoryname,
                Value = i.ExpenseCategoryId.ToString()
            });

            ViewBag.PopulateExpCategory = getExpenseCategoryList;


            var _ExpenseDetails = _context.Expenses.Find(Id);
            if (_ExpenseDetails == null)
            {
                return NotFound();
            }

            return View(_ExpenseDetails);
        }

        public IActionResult Delete(int? ExpenseId)
        {
            var _ExpenseDetails = _context.Expenses.Find(ExpenseId);
            if (_ExpenseDetails == null)
            {
                return NotFound();
            }

            _context.Expenses.Remove(_ExpenseDetails);
            _context.SaveChanges();
            return RedirectToAction("Index");

            
        }


    }
}
